using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    internal class Part1 : Day05
    {
        internal int Calculate(Stream stream)
        {
            var rslt = 0;

            var source = LoadSource(stream);

            Parallel.ForEach(source.Pages, (line) =>
            {
                if (IsValid(source, line) != null)
                {
                    rslt += Middle(line);
                }
            });

            return rslt;
        }
    }
}
