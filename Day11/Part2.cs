using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    internal class Part2
    {
        public long Calculate(Stream stream, long maxLevel)
        {
            var input = Input.From(stream);

            var set = new Set() { Combos = input.values.Select(v => new Combo(1, [new Stone(v)])).ToList() };

            for (var i = 0; i < maxLevel; i++)
            {
                set = set.Calculate();

                Console.WriteLine($"Level: {i + 1} -> {(long)set.Combos.Select(c => (long)c.Count * (long)c.Stones.Count).Sum()}");
                //Console.WriteLine(string.Join(" ", set.Combos.SelectMany(c => c.Stones.Select(s => s.Value.ToString()))));
            }

            return set.Combos.Select(c => (long)c.Count * (long)c.Stones.Count).Sum();
        }

        public class Combo
        {
            public List<Stone> Stones { get; set; } = [];
            public long Count { get; set; }
            public Combo(long count, List<Stone> stones)
            {
                this.Count = count;
                this.Stones = stones;
            }
        }

        public class Set
        {
            public List<Combo> Combos { get; set; } = [];

            public Set Calculate()
            {
                var set = new Set();

                var dict = ToDict();

                foreach (var kvp in dict)
                {
                    var applied = Stone.ApplyRules(kvp.Key);

                    set.Combos.Add(new Combo(kvp.Value, applied));
                }

                return set;
            }

            public Dictionary<long, long> ToDict()
            {
                var rslt = new Dictionary<long, long>();

                foreach(var c in Combos)
                {
                    foreach(var s in c.Stones)
                    {
                        if (rslt.ContainsKey(s.Value))
                        {
                            rslt[s.Value]+= c.Count;
                        }
                        else
                        {
                            rslt.Add(s.Value, c.Count);
                        }
                    }
                }

                return rslt;
            }
        }
    }
}
