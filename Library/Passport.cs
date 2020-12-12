using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Library
{
    public class Passport
    {
        public string? BirthYear { get; }

        public string? IssueYear { get; }

        public string? ExpirationYear { get; }

        public string? Height { get; }

        public string? HairColour { get; }

        public string? EyeColour { get; }

        public string? PassportId { get; }

        public string? CountryId { get; }

        public Passport(IEnumerable<string> lines)
        {
            foreach(string line in lines)
            {
                var parts = line.Split(':');
                var value = parts[1];
                switch (parts[0])
                {
                    case "byr":
                        BirthYear = value;
                        break;
                    case "iyr":
                        IssueYear = value;
                        break;
                    case "eyr":
                        ExpirationYear = value;
                        break;
                    case "hgt":
                        Height = value;
                        break;
                    case "hcl":
                        HairColour = value;
                        break;
                    case "ecl":
                        EyeColour = value;
                        break;
                    case "pid":
                        PassportId = value;
                        break;
                    case "cid":
                        CountryId = value;
                        break;
                }
            }
        }

        public bool IsValid()
        {
            return new[]
            {
                BirthYear, IssueYear, ExpirationYear, Height, HairColour, EyeColour,
                PassportId, /* CountryId */
            }
            .All(obj => obj != null);
        }

        public bool IsReallyValid()
        {
            if (!IsValid())
            {
                return false;
            }

            if(!InRange(BirthYear!, 1920, 2002))
            {
                return false;
            }

            if (!InRange(IssueYear!, 2010, 2020))
            {
                return false;
            }

            if (!InRange(ExpirationYear!, 2020, 2030))
            {
                return false;
            }

            if (!ValidateHeight(Height!))
            {
                return false;
            }

            if (!_colourRegex.IsMatch(HairColour!))
            {
                return false;
            }

            if (!_validEyeColours.Contains(EyeColour!)){
                return false;
            }

            if (!_passportRegex.IsMatch(PassportId!)){
                return false;
            }

            return true;
        }

        private bool InRange(string integer, int minInclusive, int maxExclusive)
        {
            return int.TryParse(integer, out int value) &&
                value >= minInclusive && value <= maxExclusive;
        }

        private Regex _heightRegex = new Regex(@"^(\d+)(in|cm)$");

        private bool ValidateHeight(string height)
        {
            var match = _heightRegex.Match(height);

            if (!match.Success)
            {
                return false;
            }

            var value = match.Groups[1].Value;
            var unit = match.Groups[2].Value;

            return unit == "cm"
                ? InRange(value, 150, 193)
                : InRange(value, 59, 76);
        }

        private Regex _colourRegex = new Regex(@"^#[a-f0-9]{6}$");

        private string[] _validEyeColours = new[] {
            "amb", "blu", "brn", "gry", "grn", "hzl", "oth"
        };

        private Regex _passportRegex = new Regex(@"^\d{9}$");
    }
}
