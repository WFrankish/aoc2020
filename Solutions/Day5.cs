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

        public int PuzzleB()
        {
            var seatSet = new HashSet<int>();

            int max = GetSeatId("BBBBBBBRRR");
            for(int i = 0; i <= max; i++)
            {
                seatSet.Add(i);
            }

            foreach(var seatId in InputLines.Select(GetSeatId))
            {
                seatSet.Remove(seatId);
            }

            foreach (var seatId in seatSet.ToArray())
            {
                seatSet.Remove(seatId);
                if (!seatSet.Contains(seatId + 1))
                {
                    break;
                }
            }

            foreach (var seatId in seatSet.Reverse().ToArray())
            {
                seatSet.Remove(seatId);
                if (!seatSet.Contains(seatId - 1))
                {
                    break;
                }
            }

            return seatSet.Single();
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
