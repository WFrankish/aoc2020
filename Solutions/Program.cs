using System;

namespace Solutions
{
    class Program
    {
        static void Main(string[] _)
        {
            var puzzle = new Day7(Console.WriteLine);

            Console.WriteLine(puzzle.PuzzleA());
        }
    }
}
