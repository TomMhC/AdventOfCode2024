using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    internal class Day02
    {
        protected List<InputLine> ReadInput(Stream stream)
        {
            var rslt = new List<InputLine>();

            using var sr = new StreamReader(stream);

            while(sr.Peek() >= 0)
            {
                var line = sr.ReadLine();
                var split = line.Split(" ");
                var inputLine = new InputLine()
                {
                    Values = split.Select(s => int.Parse(s)).ToList()
                };
                rslt.Add(inputLine);
            }

            return rslt;
        }

        protected class InputLine
        {
            public IList<int>? Values;
        }
    }
}
