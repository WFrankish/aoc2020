using System;

namespace Solutions
{
    class Program
    {
        static void Main(string[] _)
        {
            var puzzle = new Day1(Console.WriteLine);

            Console.WriteLine(puzzle.PuzzleB());
        }
    }
}
