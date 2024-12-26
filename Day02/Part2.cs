using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    internal class Part2 : Day02
    {
        public int Calculate(Stream stream)
        {
            var input = ReadInput(stream);

            var rslt = 0;

            foreach (var i in input)
            {
                if (IsValid(i))
                    rslt += 1;
            }

            return rslt;
        }

        private bool IsValid(InputLine line)
        {
            if (base.IsValid(line.Values!))
                return true;

            var input = line.Values;

            for (var i = 0; i < input.Count; i++)
            {
                var values = new List<int>(input);
                values.RemoveAt(i);
                
                if (base.IsValid(values))
                    return true;
            }

            return false;
        }
    }
}
