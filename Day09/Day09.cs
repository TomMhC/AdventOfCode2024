using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day09
{
    internal class Day09
    {
        protected class Element
        {
            public int Count;
        }

        protected class File : Element
        {
            public int FileId;
        }

        protected class Space : Element { }

        protected string TryPrint(List<Element> elements)
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

        protected long Sum(List<Element> elements)
        {
            var rslt = 0L;

            for (var i = 0; i < elements.Count; i++)
            {
                var element = elements[i];

                if (element is Space) continue;

                rslt += ((File)element).FileId * i;
            }

            return rslt;
        }

        protected List<Element> uncompact(string line)
        {
            var rslt = new List<Element>();

            var fileId = 0;

            for (var i = 0; i < line.Length; i++)
            {
                var cnt = int.Parse(line[i].ToString());

                if (i % 2 == 0)
                {
                    for (var j = 0; j < cnt; j++)
                    {
                        rslt.Add(new File() { FileId = fileId, Count = cnt });
                    }
                    fileId += 1;
                }
                else
                {
                    for (var j = 0; j < cnt; j++)
                    {
                        rslt.Add(new Space() { Count = cnt });
                    }
                }
            }

            return rslt;
        }
    }
}
