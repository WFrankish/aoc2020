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
            return source.SelectMany((a, i) => source.Skip(i+1).Select(b => (a, b)));
        }
    }
}
