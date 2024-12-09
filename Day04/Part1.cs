using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
    internal class Part1 : Day04
    {
        internal int Calculate(Stream stream)
        {
            var lines = GetLines(stream);

            var matrix = GetMatrix(lines);

            return CalculateXmas(matrix);
        }

        int CalculateXmas(char[,] matrix)
        {
            var rslt = 0;

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    var v = GetVal(matrix, i, j);
                    if (v == 'X')
                    {
                        if (GetVal(matrix, i + 1, j) == 'M' &&
                            GetVal(matrix, i + 2, j) == 'A' &&
                            GetVal(matrix, i + 3, j) == 'S')
                            rslt += 1;


                        if (GetVal(matrix, i - 1, j) == 'M' &&
                            GetVal(matrix, i - 2, j) == 'A' &&
                            GetVal(matrix, i - 3, j) == 'S')
                            rslt += 1;

                        if (GetVal(matrix, i, j + 1) == 'M' &&
                            GetVal(matrix, i, j + 2) == 'A' &&
                            GetVal(matrix, i, j + 3) == 'S')
                            rslt += 1;

                        if (GetVal(matrix, i, j - 1) == 'M' &&
                            GetVal(matrix, i, j - 2) == 'A' &&
                            GetVal(matrix, i, j - 3) == 'S')
                            rslt += 1;

                        if (GetVal(matrix, i + 1, j - 1) == 'M' &&
                            GetVal(matrix, i + 2, j - 2) == 'A' &&
                            GetVal(matrix, i + 3, j - 3) == 'S')
                            rslt += 1;

                        if (GetVal(matrix, i - 1, j - 1) == 'M' &&
                            GetVal(matrix, i - 2, j - 2) == 'A' &&
                            GetVal(matrix, i - 3, j - 3) == 'S')
                            rslt += 1;

                        if (GetVal(matrix, i + 1, j + 1) == 'M' &&
                            GetVal(matrix, i + 2, j + 2) == 'A' &&
                            GetVal(matrix, i + 3, j + 3) == 'S')
                            rslt += 1;

                        if (GetVal(matrix, i - 1, j + 1) == 'M' &&
                            GetVal(matrix, i - 2, j + 2) == 'A' &&
                            GetVal(matrix, i - 3, j + 3) == 'S')
                            rslt += 1;

                    }


                }
            }

            return rslt;
        }        
    }
}
