using Inputs;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Day7 : Day
    {
        public Day7(Action<string> writeLine) : base(writeLine, InputHelper.Open(7))
        {
        }

        public int PuzzleA()
        {
            var rules = InputLines
                .Select(line => new BagRule(line))
                .ToArray();

            var bags = new Stack<string>();
            bags.Push("shiny gold");

            var foundBags = new HashSet<string>();
            while (bags.Any())
            {
                var bag = bags.Pop();
                var newBags = rules
                    .Where(r => r.AllowedBags(bag) > 0)
                    .Select(r => r.Title)
                    .ToArray();

                foreach(var newBag in newBags)
                {
                    if (!foundBags.Contains(newBag))
                    {
                        foundBags.Add(newBag);
                        bags.Push(newBag);
                    }                    
                }
            }

            return foundBags.Count;
        }

        public int PuzzleB()
        {
            var rules = InputLines
                .Select(line => new BagRule(line))
                .ToDictionary(r => r.Title);

            var bags = new Stack<(int number, string bag)>();
            bags.Push((1, "shiny gold"));

            int result = 0;
            while (bags.Any())
            {
                var (number, bag) = bags.Pop();
                var rule = rules[bag];

                foreach (var kvp in rule.GetContents())
                {
                    var newBag = kvp.Key;
                    var count = number * kvp.Value;
                    result += count;
                    bags.Push((count, newBag));
                }
            }

            return result;
        }
    }
}
