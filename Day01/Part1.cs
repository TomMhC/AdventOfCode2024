using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    internal class Part1
    {
        internal int Calculate()
        {
            var input = ReadInput();

            var lst1Ordered = input.List1.Order().ToList();
            var lst2Ordered = input.List2.Order().ToList();

            var total = 0;

            for(var i = 0; i< lst1Ordered.Count; i++)
            {
                total += Math.Abs(lst1Ordered[i] - lst2Ordered[i]);
            }

            return total;
        }

        private class Input
        {
            public List<int> List1 { get; set; } = new List<int>();
            public List<int> List2 { get; set; } = new List<int>();
        }

        private Input ReadInput()
        {
            var input = new Input();

            using (var fo = File.OpenRead("Input.txt"))
            {
                using (var sr = new StreamReader(fo))
                {
                    while (sr.Peek() != -1)
                    {
                        var line = sr.ReadLine();

                        var val1 = int.Parse(line.Substring(0, 5));
                        var val2 = int.Parse(line.Substring(8));

                        input.List1.Add(val1);
                        input.List2.Add(val2);
                    }
                }
            }

            return input;
        }
    }
}
