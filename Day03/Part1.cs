using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    internal class Part1
    {
        internal int Calculate(Stream stream)
        {
            var rslt = 0;

            var sr = new StreamReader(stream);
            var instructions = sr.ReadToEnd();

            var indOfMul = instructions.IndexOf("mul(");
            while (indOfMul > -1)
            {
                instructions = instructions.Substring(indOfMul + 4);

                var indOfClosing = instructions.IndexOf(")");
                    
                if (indOfClosing == -1)
                    return rslt;

                var instruction = instructions.Substring(0, indOfClosing);

                var t = Parse(instruction);
                if (t > -1)
                {
                    rslt += t;
                }

                indOfMul = instructions.IndexOf("mul(");
            }

            return rslt;
        }

        int Parse(string str)
        {
            var indOfComma = str.IndexOf(",");
            if (indOfComma == -1)
                return -1;

            var x = str.Substring(0, indOfComma);
            var y = str.Substring(indOfComma + 1);

            int xi, yi;
            if (!int.TryParse(x, out xi)) return -1;
            if (!int.TryParse(y, out yi)) return -1;

            if (xi > 999 | yi > 999) return -1;

            return xi * yi;
        }
    }
}
