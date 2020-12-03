using Inputs;
using Library;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Solutions
{
    public class Day2 : Day
    {
        private readonly Regex _regex;

        public Day2(Action<string> writeLine) : base(writeLine, InputHelper.Open(2))
        {
            _regex = new Regex(@"(\d+)-(\d+) ([a-z]): ([a-z]+)");
        }

        public int PuzzleA()
        {
            var matchingPasswords = InputLines
                .Select(str => _regex.Match(str))
                .Select(Parse)
                .Select(t => t.Rule.Match(t.Password));

            var result = matchingPasswords.Count(b => b);

            return result;
        }

        public int PuzzleB()
        {
            var matchingPasswords = InputLines
                .Select(str => _regex.Match(str))
                .Select(Parse)
                .Select(t => t.Rule.MatchAlternate(t.Password));

            var result = matchingPasswords.Count(b => b);

            return result;
        }

        private (PasswordRule Rule, string Password) Parse(Match match)
        {
            // group 0 is the full match
            var min = int.Parse(match.Groups[1].Value);
            var max = int.Parse(match.Groups[2].Value);
            var character = match.Groups[3].Value.Single();
            var password = match.Groups[4].Value;

            var rule = new PasswordRule(min, max, character);

            return (rule, password);
        }
    }
}
