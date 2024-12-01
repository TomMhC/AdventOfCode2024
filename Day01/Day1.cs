using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    internal class Day1
    {
        protected class Input
        {
            public List<int> List1 { get; set; } = new List<int>();
            public List<int> List2 { get; set; } = new List<int>();
        }

        protected Input ReadInput()
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
