using Inputs;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Day10 : Day
    {
        public Day10(Action<string> writeLine) : base(writeLine, InputHelper.Open(10))
        {
        }

        public long PuzzleA()
        {
            var joltages = GetJoltages();

            int ones = 0;
            int threes = 0;

            for (int i = 0; i + 1 < joltages.Count; i++)
            {
                var lower = joltages[i];
                var upper = joltages[i + 1];

                var diff = upper - lower;
                if(diff == 1)
                {
                    ones++;
                }
                else if (diff == 3)
                {
                    threes++;
                }
            }

            return ones * threes;
        }

        public long PuzzleB()
        {
            var joltages = GetJoltages();

            // differences are always 1 and 3
            // if there's a difference of 3 we NEED that pair
            // split into sections were we have some leeway
            var sections = joltages
                .Split((lower, upper) => upper - lower == 3);

            // return the product of combinations in subsections
            return sections
                .Select(GetPossibleCombinationCount)
                .Aggregate((a, b) => a * b);
        }

        private IReadOnlyList<int> GetJoltages()
        {
            var joltages = InputLines
                .Select(int.Parse)
                .OrderBy(i => i)
                .ToList();

            var builtInRating = 3 + joltages.Last();

            joltages.Insert(0, 0);
            joltages.Add(builtInRating);

            return joltages;
        }

        private long GetPossibleCombinationCount(IReadOnlyCollection<int> joltages)
        {
            // so, we know that the joltage differences between each adjacent pair is 1
            // so their values don't actually matter
            // return the number of subsets where we do not remove more than 2 connectors in a row
            switch (joltages.Count)
            {
                case 1:
                case 2:
                    return 1;
                case 3:
                    return 2;
                case 4:
                    return 4;
                case 5:
                    return 7;
                default:
                    throw new NotImplementedException("I have not figured out how to program this and did it by hand.");
            }
        }
    }
}
