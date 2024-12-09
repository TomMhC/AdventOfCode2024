using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    internal class Day07
    {
        protected List<Equation> ReadEquations(Stream stream)
        {
            var rslt = new List<Equation>();

            using var sr = new StreamReader(stream);
            while (sr.Peek() > -1)
            {
                var equation = new Equation();

                var line = sr.ReadLine();
                var indOfColon = line.IndexOf(":");

                equation.Result = long.Parse(line.Substring(0, indOfColon));

                var rest = line.Substring(indOfColon + 1);

                equation.Values = rest.Split(" ").Where(r => !string.IsNullOrWhiteSpace(r)).Select(r => int.Parse(r)).ToList();

                rslt.Add(equation);
            }

            return rslt;
        }

        protected class Equation
        {
            public long Result;

            public List<int> Values;
        }
    }
}
