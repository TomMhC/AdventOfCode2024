using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    internal class Part2 : Day07
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

            var concat = long.Parse(start.ToString() + values.First().ToString());
            if (Check(rslt, concat, values.Skip(1)))
                return true;

            return false;
        }
    }
}
