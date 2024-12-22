using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    internal class Part1
    {
        public long Calculate(Stream stream, long maxLevel)
        {
            var input = Input.From(stream);

            var stones = input.values.Select(v => new Stone(v)).ToList();

            var rslt = 0;

            foreach (var s in stones)
            {
                rslt += Calculate(1, maxLevel, s).Count();
            }

            return rslt;
        }

        public List<Stone> Calculate(long level, long maxLevel, Stone s)
        {
            var applied = s.ApplyRules();

            if (level == maxLevel)
            {
                return applied;
            }
            else
            {
                var rslt = new List<Stone>();

                foreach (var a in applied)
                {
                    rslt.AddRange(Calculate(level + 1, maxLevel, a));
                }

                return rslt;
            }
        }
    }
}
