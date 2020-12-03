using System;
using System.Collections.Generic;

namespace Library
{
    public abstract class Day
    {
        protected Action<string> WriteLine { get; }

        protected IReadOnlyCollection<string> InputLines { get; }

        protected Day(Action<string> writeLine, IReadOnlyCollection<string> inputLines)
        {
            WriteLine = writeLine;
            InputLines = inputLines;
        }
    }
}
