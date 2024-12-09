using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day09
{
    internal class Part1 : Day09
    {
        public long Calculate(Stream stream)
        {
            using var sr = new StreamReader(stream);
            var line = sr.ReadToEnd();

            var elements = uncompact(line);

            //Console.WriteLine(TryPrint(elements));

            Reorder(elements);

            //Console.WriteLine(TryPrint(elements));

            return Sum(elements);
        }

        private void Reorder(List<Element> elements)
        {
            for (var i = 0; i < elements.Count; i++)
            {
                if (elements[i] is Space)
                {
                    var lastFileInd = FindLastFile(elements, i);

                    if (lastFileInd == -1) break;

                    var lastFile = elements[lastFileInd];

                    elements.RemoveAt(lastFileInd);
                    elements.RemoveAt(i);

                    elements.Insert(i, lastFile);
                    elements.Insert(lastFileInd, new Space());
                }
            }
        }

        private int FindLastFile(List<Element> elements, int min)
        {
            for (var i = elements.Count - 1; i > min; i--)
            {
                if (elements[i] is File)
                    return i;
            }

            return -1;
        }
    }
}
