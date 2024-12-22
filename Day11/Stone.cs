using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public class Stone
    {
        public long Value { get; set; }

        public Stone(long v)
        {
            this.Value = v;
        }

        public static bool Divide(long val, out long v1, out long v2)
        {
            var valStr = val.ToString();

            var lgt = valStr.Length;

            if (lgt % 2 != 0)
            {
                v1 = -1;
                v2 = -1;
                return false;
            }

            var div = lgt / 2;

            v1 = int.Parse(valStr.Substring(0, div));
            v2 = int.Parse(valStr.Substring(div));

            return true;
        }

        public static List<Stone> ApplyRules(long Value)
        {
            var rslt = new List<Stone>();

            if (Value == 0)
            {
                return new List<Stone>() { new(1) };
            }
            else if (Divide(Value, out long v1, out long v2))
            {
                return new List<Stone>() { new(v1), new(v2) };
            }
            else
            {
                return new List<Stone>() { new(Value * 2024) };
            }
        }

        public List<Stone> ApplyRules()
        {
            return ApplyRules(this.Value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
