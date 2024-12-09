using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
    internal class Day04
    {
        protected char? GetVal(char[,] matrix, int i, int j)
        {
            if (i < 0) return null;
            if (j < 0) return null;

            if (i > matrix.GetLength(0) - 1) return null;
            if (j > matrix.GetLength(1) - 1) return null;

            return matrix[i, j];
        }

        protected char[,] GetMatrix(IList<string> lines)
        {
            var rslt = new char[lines.Count(), lines[0].Length];

            for (var i = 0; i < lines.Count; i++)
            {
                for (var j = 0; j < lines[0].Length; j++)
                {
                    rslt[i, j] = lines[i][j];
                }
            }

            return rslt;
        }

        protected IList<string> GetLines(Stream stream)
        {
            var rslt = new List<string>();

            using var sr = new StreamReader(stream);

            while (sr.Peek() > -1)
            {
                var line = sr.ReadLine();
                if (!string.IsNullOrWhiteSpace(line)) rslt.Add(line);
            }

            return rslt;
        }
    }
}
