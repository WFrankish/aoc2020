using Inputs;
using Library;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Solutions
{
    public class Day5 : Day
    {
        public Day5(Action<string> writeLine) : base(writeLine, InputHelper.Open(5))
        {
        }

        public int PuzzleA()
        {
            return InputLines
                .Select(GetSeatId)
                .Max();
        }

        private int GetSeatId(string instructions)
        {
            var rowInstructions = instructions
                .Take(7)
                .Select(c => c == 'B');

            var row = BinarySearch(127, rowInstructions);

            var columnInstructions = instructions
                .Skip(7)
                .Select(c => c == 'R');

            var column = BinarySearch(7, columnInstructions);

            WriteLine($"{instructions}, {row}, {column} {row * 8 + column}");

            return row * 8 + column;
        }

        private int BinarySearch(int maximum, IEnumerable<bool> instructions)
        {
            var (min, max) = instructions
                .Aggregate((0, maximum), (tuple, takeUpper) => BinarySearchInner(tuple, takeUpper));

            Debug.Assert(min + 1 >= max);

            return max;
        }
         
        private (int min, int max) BinarySearchInner((int, int) tuple, bool takeUpper)
        {
            (int min, int max) = tuple;

            int mid = ((max - min) / 2) + min;

            return takeUpper
                ? (mid, max)
                : (min, mid);
        }
    }
}
