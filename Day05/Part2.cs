using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    internal class Part2 : Day05
    {
        internal int Calculate(Stream stream)
        {
            var rslt = 0;

            var source = LoadSource(stream);

            foreach(var line in source.Pages)
            {
                if (IsValid(source, line) != null)
                {
                    var fxd = Fix(source, line);
                    rslt += Middle(fxd);

                    Console.WriteLine(rslt);
                }
            };

            return rslt;
        }

        List<int> Fix(Source source, List<int> ints)
        {
            var rslt = new List<int>(ints);

            var brokenRule = IsValid(source, rslt);

            while (brokenRule != null)
            {
                (rslt[brokenRule.I], rslt[brokenRule.J]) = (rslt[brokenRule.J], rslt[brokenRule.I]);

                brokenRule = IsValid(source, rslt);
            }

            return rslt.ToList();
        }
    }
}
