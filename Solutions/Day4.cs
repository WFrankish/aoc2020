using Inputs;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Day4 : Day
    {
        public Day4(Action<string> writeLine) : base(writeLine, InputHelper.Open(4))
        {
        }

        public int PuzzleA()
        {
            var passports = GetPassports();

            return passports.Count(p => p.IsValid());
        }

        public int PuzzleB()
        {
            var passports = GetPassports();

            return passports.Count(p => p.IsReallyValid());
        }

        private IEnumerable<Passport> GetPassports()
        {
            return InputLines
                .Split(string.IsNullOrEmpty)
                .Select(lines => lines
                    .SelectMany(str => str.Split(' '))
                    .Where(str => !string.IsNullOrEmpty(str))
                )
                .Select(lines => new Passport(lines));
        }
    }
}
