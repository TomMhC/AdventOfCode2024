using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day09
{
    internal class Part1
    {
        public long Calculate(Stream stream)
        {
            using var sr = new StreamReader(stream);
            var line = sr.ReadToEnd();

            var rslt = 0;

            var elements = uncompact(line);

            //Console.WriteLine(TryPrint(elements));

            Reorder(elements);

            //Console.WriteLine(TryPrint(elements));

            return Sum(elements);
        }

        string TryPrint(List<Element> elements)
        {
            var sb = new StringBuilder();

            foreach (var element in elements)
            {
                if (element is Space)
                    sb.Append(".");
                else
                    sb.Append(((File)element).FileId);
            }

            return sb.ToString();
        }

        protected class Element
        {

        }

        protected class File : Element
        {
            public int FileId;
        }

        protected class Space : Element { }

        protected long Sum(List<Element> elements)
        {
            var rslt = 0L;

            for (var i = 0; i < elements.Count; i++)
            {
                var element = elements[i];

                if (element is Space) break;

                rslt += ((File)element).FileId * i;
            }

            return rslt;
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

        List<Element> uncompact(string line)
        {
            var rslt = new List<Element>();

            var fileId = 0;

            for (var i = 0; i < line.Length; i++)
            {
                if (i % 2 == 0)
                {
                    for (var j = 0; j < int.Parse(line[i].ToString()); j++)
                    {
                        rslt.Add(new File() { FileId = fileId });
                    }
                    fileId += 1;
                }
                else
                {
                    for (var j = 0; j < int.Parse(line[i].ToString()); j++)
                    {
                        rslt.Add(new Space());
                    }
                }
            }

            return rslt;
        }
    }
}
