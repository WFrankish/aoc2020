using System;
using System.Linq;

namespace Library
{
    public class TreeLine
    {
        private readonly bool[] _trees;

        public TreeLine(string map)
        {
            _trees = map.Select(c => c == '#').ToArray();
        }

        public void Print(Action<string> writeLine)
        {
            writeLine(string.Join("", _trees.Select((b, i) => b ? '#' : '.')));
        }

        public bool IsTree(int x, Action<string> writeLine)
        {
            var index = x % _trees.Length;

            writeLine(string.Join("", _trees.Select((b, i) => i == index
                ? b ? 'X' : 'O'
                : b ? '#' : '.'
            )));

            return _trees[index];
        }
    }
}
