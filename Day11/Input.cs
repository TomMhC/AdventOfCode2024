using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    internal class Input
    {
        private Input() { }

        public required List<int> values;

        public static Input From(Stream stream)
        {
            using var sr = new StreamReader(stream);
            var text = sr.ReadToEnd();

            var rslt = new Input()
            {
                values = text.Split(" ").Select(s => int.Parse(s)).ToList()
            };

            return rslt;
        }
    }
}
