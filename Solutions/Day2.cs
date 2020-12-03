using Inputs;
using Library;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Solutions
{
    public class Day2 : Day
    {
        public Day2(Action<string> writeLine) : base(writeLine, InputHelper.Open(2))
        {
        }

        public int PuzzleA()
        {
            var regex = new Regex(@"(\d+)-(\d+) ([a-z]): ([a-z]+)");

            var matchingPasswords = InputLines
                .Select(str => regex.Match(str))
                .Select(ParseAndMatch);

            var result = matchingPasswords.Count(b => b);

            return result;
        }

        private bool ParseAndMatch(Match match)
        {
            // group 0 is the full match
            var min = int.Parse(match.Groups[1].Value);
            var max = int.Parse(match.Groups[2].Value);
            var character = match.Groups[3].Value.Single();
            var password = match.Groups[4].Value;

            var rule = new PasswordRule(min, max, character);

            return rule.Match(password);
        }
    }
}
