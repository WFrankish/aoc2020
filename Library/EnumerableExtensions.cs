using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Given a collection that may be enumerated, return an enumerated version of that collection.
        /// Does not guarantee a copy.
        /// </summary>
        public static IReadOnlyCollection<T> AsEnumerated<T>(this IEnumerable<T> source)
        {
            return source is IReadOnlyCollection<T> enumerated ? enumerated : source.ToArray();
        }

        /// <summary>
        /// Given a collection of items, return every unique pair of items.
        /// E.g. for [a, b, c], return [(a,b), (a,c) and (b,c)].
        /// </summary>
        public static IEnumerable<(T, T)> AllUniquePairs<T>(this IReadOnlyCollection<T> source)
        {
            return source.SelectMany((a, i) => source.Skip(i + 1).Select(b => (a, b)));
        }

        /// <summary>
        /// Given a collection of items, return every unique 3-tuple of items.
        /// E.g. for [a, b, c, d], return [(a,b,c), (a,b,d), (a,c,d) ... ].
        /// </summary>
        public static IEnumerable<(T, T, T)> AllUniqueTriplets<T>(this IReadOnlyCollection<T> source)
        {
            return source.SelectMany((a, i) => source.Skip(i + 1)
                .SelectMany((b, j) => source.Skip(i + j + 2)
                    .Select(c => (a, b, c))
                )
            );
        }

        /// <summary>
        /// Split a collection of items into subcollections
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="isDivider"></param>
        /// <returns></returns>
        public static IEnumerable<IReadOnlyCollection<T>> Split<T>(
            this IEnumerable<T> source,
            Func<T, bool> isDivider
        )
        {
            var result = new List<T>();
            foreach (var obj in source)
            {
                if (isDivider(obj))
                {
                    if (result.Any())
                    {
                        yield return result;
                        result = new List<T>();
                    }
                }
                else
                {
                    result.Add(obj);
                }
            }

            if (result.Any())
            {
                yield return result;
            }
        }
    }
}
