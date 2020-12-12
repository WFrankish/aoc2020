using System.Text.RegularExpressions;

namespace Library
{
    public class CodeLine
    {
        private static readonly Regex _regex = new Regex(@"(\w{3}) (\+|-)(\d+)");

        public string Command { get; }

        public int Value { get; }

        public CodeLine(string line)
        {
            var match = _regex.Match(line);

            Command = match.Groups[1].Value;

            Value = int.Parse(match.Groups[3].Value);

            if(match.Groups[2].Value == "-")
            {
                Value = -Value;
            }
        }
    }
}
