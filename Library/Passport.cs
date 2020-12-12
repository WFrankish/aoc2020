using System.Collections.Generic;
using System.Linq;

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
    }
}
