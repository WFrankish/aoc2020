using Inputs;
using Library;
using System;
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

            for(int i = 25; true; i++)
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
