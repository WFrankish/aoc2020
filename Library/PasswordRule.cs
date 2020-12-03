using System.Linq;

namespace Library
{
    public class PasswordRule
    {
        public int Min { get; }
        public int Max { get; }
        public char Character { get; }

        public PasswordRule(int min, int max, char character)
        {
            Min = min;
            Max = max;
            Character = character;
        }

        public bool Match(string password)
        {
            var count = password.Count(c => c == Character);

            return count >= Min && count <= Max;
        }

        public bool MatchAlternate(string password)
        {
            var match1 = password[Min-1] == Character;
            var match2 = password[Max-1] == Character;

            return match1 ^ match2;
        }
    }
}
