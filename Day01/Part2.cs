using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    internal class Part2 : Day1
    {
        internal int Calculate()
        {
            var input = ReadInput();

            var total = 0;

            foreach(var i in input.List1)
            {
                total += input.List2.Where(i2 => i2 == i).Count() * i;
            }

            return total;
        }
    }
}
