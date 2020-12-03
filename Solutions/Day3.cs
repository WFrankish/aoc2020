using Inputs;
using Library;
using System;
using System.Collections.Generic;
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

            return GetCollisionCount(trees, 3, 1);
        }

        public int PuzzleB()
        {
            var trees = InputLines
                .Select(str => new TreeLine(str))
                .ToList();

            var collisionProduct = 1;

            collisionProduct *= GetCollisionCount(trees, 1, 1);

            WriteLine("");

            collisionProduct *= GetCollisionCount(trees, 3, 1);

            WriteLine("");

            collisionProduct *= GetCollisionCount(trees, 5, 1);

            WriteLine("");

            collisionProduct *= GetCollisionCount(trees, 7, 1);

            WriteLine("");

            collisionProduct *= GetCollisionCount(trees, 1, 2);

            WriteLine("");

            return collisionProduct;
        }

        public int GetCollisionCount(IEnumerable<TreeLine> trees, int xSpeed, int ySpeed)
        {
            int collisions = 0;
            int x = 0;
            int y = 0;
            foreach (var treeline in trees)
            {
                if(y % ySpeed != 0)
                {
                    treeline.Print(WriteLine);
                }
                else if(treeline.IsTree(x, WriteLine))
                {
                    collisions += 1;
                }

                x += xSpeed;
                y += 1;
            }

            return collisions;
        }
    }
}
