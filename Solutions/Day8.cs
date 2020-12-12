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
            var codeLines = InputLines
                .Select(line => new CodeLine(line))
                .ToArray();

            TryRunProgram(codeLines, out int result);

            return result;
        }

        public int PuzzleB()
        {
            var codeLines = InputLines
                .Select(line => new CodeLine(line))
                .ToArray();

            var alternatives = codeLines
                .Where(line => line.Command != "acc")
                .Select(line => codeLines.Select(l => l == line
                        ? new CodeLine(l.Command == "nop" ? "jmp" : "nop", l.Value)
                        : l
                    )
                    .ToArray()
                );

            foreach(var alternative in alternatives)
            {
                if(TryRunProgram(alternative, out int result))
                {
                    return result;
                }
            }

            throw new Exception("No alternatives were valid");
        }

        private bool TryRunProgram(IReadOnlyList<CodeLine> codeLines, out int accumator)
        {
            var visitedLines = new HashSet<int>();

            var index = 0;
            accumator = 0;
            while (index < codeLines.Count)
            {
                if (visitedLines.Contains(index))
                {
                    return false;
                }
                else
                {
                    visitedLines.Add(index);
                }

                var codeLine = codeLines[index];
                switch (codeLine.Command)
                {
                    case "nop":
                        index++;
                        break;
                    case "acc":
                        accumator += codeLine.Value;
                        index++;
                        break;
                    case "jmp":
                        index += codeLine.Value;
                        break;
                }
            }

            return true;
        }
    }
}
