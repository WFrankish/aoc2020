using Inputs;
using Library;
using System;
using System.Linq;

namespace Solutions
{
    public class Day3 : Day
    {
        public Day3(Action<string> writeLine) : base(writeLine, InputHelper.Open(3))
        {
        }

        public int PuzzleA()
        {
            var trees = InputLines
                .Select(str => new TreeLine(str))
                .ToList();

            int collisions = 0;
            int x = 0;
            int y = 0;
            foreach(var treeline in trees)
            {
                if(treeline.IsTree(x, WriteLine))
                {
                    collisions += 1;
                }

                x += 3;
                y += 1;
            }

            return collisions;
        }
    }
}
