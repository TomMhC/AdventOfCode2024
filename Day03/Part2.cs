using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    internal class Part2
    {
        internal int Calculate(Stream stream)
        {
            var rslt = 0;

            var sr = new StreamReader(stream);
            var instructions = sr.ReadToEnd();

            var indOfMul = instructions.IndexOf("mul(");
            var indOfDont = instructions.IndexOf("don't()");
            var indOfDo = instructions.IndexOf("do()");

            var enabled = true;

            while (indOfMul > -1)
            {
                if (indOfDo > -1 && (indOfDo < indOfDont | indOfDont == -1) && indOfDo < indOfMul)
                {
                    // To do
                    instructions = instructions.Substring(indOfDo + 4);
                    enabled = true;
                }
                else if (indOfDont > -1 && indOfDont < indOfMul)
                {
                    // To don't
                    instructions = instructions.Substring(indOfDont + 6);
                    enabled = false;
                }
                else
                {
                    instructions = instructions.Substring(indOfMul + 4);

                    var indOfClosing = instructions.IndexOf(")");

                    if (indOfClosing == -1)
                        return rslt;

                    var instruction = instructions.Substring(0, indOfClosing);

                    var t = Parse(instruction);
                    if (t > -1 && enabled)
                    {
                        rslt += t;
                    }
                }

                indOfMul = instructions.IndexOf("mul(");
                indOfDont = instructions.IndexOf("don't()");
                indOfDo = instructions.IndexOf("do()");
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
