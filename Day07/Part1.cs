using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    internal class Part1
    {
        public long Calculate(Stream stream)
        {
            long rslt = 0;

            var equations = ReadEquations(stream);

            for(var i =0; i < equations.Count(); i++)
            {
                Console.WriteLine($"{i}/{equations.Count()}");
                var equation = equations[i];
                if (IsValidEquation(equation)) rslt += equation.Result;
            }

            return rslt;
        }

        private bool IsValidEquation(Equation equation)
        {
            var start = (long)equation.Values.First();

            if (Check(equation.Result, start, equation.Values.Skip(1)))
                return true;
            else
                return false;
        }

        private bool Check(long rslt, long start, IEnumerable<int> values)
        {
            if (values.Count() == 0)
                return rslt == start;

            var plus = start + values.First();
            if (Check(rslt, plus, values.Skip(1)))
                return true;

            var mult = start * values.First();
            if (Check(rslt, mult, values.Skip(1)))
                return true;

            return false;
        }

        private List<Equation> ReadEquations(Stream stream)
        {
            var rslt = new List<Equation>();

            using var sr = new StreamReader(stream);    
            while (sr.Peek() > -1)
            {
                var equation = new Equation();

                var line = sr.ReadLine();
                var indOfColon = line.IndexOf(":");

                equation.Result = long.Parse( line.Substring(0, indOfColon));

                var rest = line.Substring(indOfColon + 1);

                equation.Values = rest.Split(" ").Where(r => !string.IsNullOrWhiteSpace(r)).Select(r => int.Parse(r)).ToList();

                rslt.Add(equation);
            }

            return rslt;
        }

        private class Equation
        {
            public long Result;

            public List<int> Values;
        }
    }
}
