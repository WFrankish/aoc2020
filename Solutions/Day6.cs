using Inputs;
using Library;
using System;
using System.Linq;

namespace Solutions
{
    public class Day6 : Day
    {
        public Day6(Action<string> writeLine) : base(writeLine, InputHelper.Open(6))
        {
        }

        public int PuzzleA()
        {
            return InputLines
                .Split(string.IsNullOrEmpty)
                .Select(lines => lines
                    .SelectMany(str => str)
                    .Distinct()
                    .Count()
                )
                .Sum();
        }

        public int PuzzleB()
        {
            return InputLines
                .Split(string.IsNullOrEmpty)
                .Select(lines => lines
                    .Select(line => line.Cast<char>())
                    .Aggregate((l1, l2) => l1.Intersect(l2))
                    .Count()
                )
                .Sum();
        }
    }
}
