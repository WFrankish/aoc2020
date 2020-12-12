using Inputs;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Day9 : Day
    {
        public Day9(Action<string> writeLine) : base(writeLine, InputHelper.Open(9))
        {
        }

        public long PuzzleA()
        {
            var inputs = InputLines
                .Select(long.Parse)
                .ToArray();

            return FindFirstInvalidInput(inputs);
        }

        public long PuzzleB()
        {
            var inputs = InputLines
                .Select(long.Parse)
                .ToArray();

            var target = FindFirstInvalidInput(inputs);

            var sum = inputs[0];
            var min = 0;
            var max = 0;
            while (true)
            {
                if(sum < target || min == max)
                {
                    max++;
                    sum += inputs[max];
                }
                else if (sum > target)
                {
                    sum -= inputs[min];
                    min++;
                }
                else
                {
                    var values = inputs
                        .Skip(min)
                        .Take(max - min)
                        .ToArray();

                    return values.Min() + values.Max();
                }
            }
        }

        private long FindFirstInvalidInput(IReadOnlyList<long> inputs)
        {
            for (int i = 25; true; i++)
            {
                var input = inputs[i];

                var preamble = inputs
                    .Skip(i - 25)
                    .Take(25)
                    .ToArray();

                var valid = preamble
                    .AllUniquePairs()
                    .Any(t => t.Item1 + t.Item2 == input);

                if (!valid)
                {
                    return input;
                }
            }
        }
    }
}
