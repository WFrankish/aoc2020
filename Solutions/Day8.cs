using Inputs;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Day8 : Day
    {
        public Day8(Action<string> writeLine) : base(writeLine, InputHelper.Open(8))
        {
        }

        public int PuzzleA()
        {
            var lines = InputLines
                .Select(line => new CodeLine(line))
                .ToArray();

            var visitedLines = new HashSet<int>();

            var index = 0;
            var result = 0;
            while (true)
            {
                if (visitedLines.Contains(index))
                {
                    break;
                } else
                {
                    visitedLines.Add(index);
                }

                var codeLine = lines[index];
                switch (codeLine.Command)
                {
                    case "nop":
                        index++;
                        break;
                    case "acc":
                        result += codeLine.Value;
                        index++;
                        break;
                    case "jmp":
                        index += codeLine.Value;
                        break;
                }
            }

            return result;
        }
    }
}
