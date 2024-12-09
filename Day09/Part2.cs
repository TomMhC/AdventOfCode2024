using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day09
{
    internal class Part2 : Day09
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
            var attempted = new List<int>();

            for (var i = elements.Count - 1; i >= 0; i--)
            {
                Console.WriteLine($"{i} / {elements.Count}");

                if (elements[i] is File)
                {
                    var file = (File) elements[i];
                    if (!attempted.Contains(file.FileId))
                    {
                        attempted.Add(file.FileId);
                        AttemptToMove(elements, i - file.Count + 1, file);
                    }

                    // Skip unnecessary checks
                    i -= (file.Count - 1);
                }
            }
        }

        private void AttemptToMove(List<Element> elements, int index, Element file)
        {
            for(var i = 0; i < index; i++)
            {
                if (elements[i] is Space)
                {
                    var cnt = 1;
                    while (i + cnt < elements.Count && elements[i + cnt] is Space)
                    {
                        cnt += 1;
                    }

                    if (i + cnt > index) continue;

                    if (cnt >= file.Count)
                    {
                        // Move
                        Move(elements, file, index, i);

                        //Console.WriteLine(TryPrint(elements));

                        return;
                    }

                    i += (cnt - 1);
                }
            }
        }

        private void Move(List<Element> elements, Element file, int lastFileInd, int i)
        {
            for (var j = 0; j < file.Count; j++)
            {
                file = elements[lastFileInd + j];
                var lastSpace = elements[i + j];

                if (lastSpace is not Space)
                    throw new Exception();

                elements.RemoveAt(lastFileInd + j);
                elements.RemoveAt(i + j);

                elements.Insert(i + j, file);
                elements.Insert(lastFileInd + j, lastSpace);
            }
        }
    }
}
