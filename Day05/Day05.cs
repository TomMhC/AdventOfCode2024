using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    internal class Day05
    {
        protected int Middle(List<int> line)
        {
            return line[(int)Math.Floor(line.Count / 2D)];
        }

        protected BrokenRule? IsValid(Source source, List<int> line)
        {
            for (var i = 1; i < line.Count; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    foreach (var r in source.Rules)
                    {
                        if (!r.Evaluate(line[j], line[i]))
                            return new BrokenRule()
                            {
                                Before = r.Before,
                                After = r.After,
                                I = i,
                                J = j
                            };
                    }
                }
            }

            return null;
        }

        protected Source LoadSource(Stream stream)
        {
            var rslt = new Source();

            using var sr = new StreamReader(stream);

            var rules = true;

            while (sr.Peek() > -1)
            {
                var line = sr.ReadLine();

                if (string.IsNullOrEmpty(line))
                    rules = false;
                else
                {
                    if (rules)
                    {
                        rslt.Rules.Add(Rule.Parse(line));
                    }
                    else
                    {
                        var pages = line.Split(",").Select(c => int.Parse(c)).ToList();
                        rslt.Pages.Add(pages);
                    }
                }
            }

            return rslt;
        }

        protected partial class Source
        {
            public List<Rule> Rules { get; set; } = new List<Rule>();
            public List<List<int>> Pages { get; set; } = new List<List<int>>();
        }

        protected class BrokenRule : Rule
        {
            public int I { get; set; }
            public int J { get; set; }
            public List<int> Line { get; set; }
        }

        protected class Rule
        {
            public int Before { get; set; }
            public int After { get; set; }
            public static Rule Parse(string line)
            {
                var rule = new Rule();

                var split = line.Split("|");

                rule.Before = int.Parse(split[0]);
                rule.After = int.Parse(split[1]);

                return rule;
            }

            public bool Evaluate(int p, int a)
            {
                if (a == Before && p == After) return false;

                return true;
            }

            public override string ToString()
            {
                return $"{Before} -> {After}";
            }
        }
    }
}
