using Inputs;
using Library;
using System;
using System.Linq;

namespace Solutions
{
    public class Day1 : Day
    {
        public Day1(Action<string> writeLine) : base(writeLine, InputHelper.Open(1))
        {
        }

        public int PuzzleA()
        {
            var numbers = InputLines
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

        public int PuzzleB()
        {
            var numbers = InputLines
                .Select(str => str.Trim())
                .Select(int.Parse);

            var triplets = numbers
                .AsEnumerated()
                .AllUniqueTriplets();

            var match = triplets
                .First(p => p.Item1 + p.Item2 + p.Item3 == 2020);

            var result = match.Item1 * match.Item2 * match.Item3;

            return result;
        }
    }
}
