using Inputs;
using Library;
using System;
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
            var joltages = InputLines
                .Select(int.Parse)
                .OrderBy(i => i)
                .ToList();

            var builtInRating = 3 + joltages.Last();

            joltages.Insert(0, 0);
            joltages.Add(builtInRating);

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
    }
}
