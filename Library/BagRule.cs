using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Library
{
    public class BagRule
    {
        private static readonly Regex _titleRegex = new Regex(@"^([a-z ]+) bags contain");

        private static readonly Regex _rulesRegex = new Regex(@"(\d+) ([a-z ]+) bags?");

        private readonly Dictionary<string, int> _dict;

        public string Title { get; }

        public BagRule(string line)
        {
            var titleMatch = _titleRegex.Match(line);

            Title = titleMatch.Groups[1].Value;

            var rulesMatch = _rulesRegex.Matches(line);

            _dict = rulesMatch.ToDictionary(
                m => m.Groups[2].Value, 
                m => int.Parse(m.Groups[1].Value)
            );
        }

        public int AllowedBags(string bagType)
        {
            return _dict.TryGetValue(bagType, out int value) ? value : 0;
        }
    }
}
