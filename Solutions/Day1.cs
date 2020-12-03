using Inputs;
using Library;
using System;
using System.Linq;

namespace Solutions
{
    public class Day1
    {
        private readonly Action<string> _writeLine;

        public Day1(Action<string> writeLine)
        {
            _writeLine = writeLine;
        }

        public int PuzzleA()
        {
            var file = InputHelper.Open(1);

            var numbers = file
                .Select(str => str.Trim())
                .Select(int.Parse);

            var pairs = numbers
                .AsEnumerated()
                .AllUniquePairs();

            var match = pairs
                .First(p => p.Item1 + p.Item2 == 2020);

            var result = match.Item1 * match.Item2;

            return result;
        }
    }
}
