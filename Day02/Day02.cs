using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    internal class Day02
    {
        protected List<InputLine> ReadInput(Stream stream)
        {
            var rslt = new List<InputLine>();

            using var sr = new StreamReader(stream);

            while(sr.Peek() >= 0)
            {
                var line = sr.ReadLine();
                var split = line.Split(" ");
                var inputLine = new InputLine()
                {
                    Values = split.Select(s => int.Parse(s)).ToList()
                };
                rslt.Add(inputLine);
            }

            return rslt;
        }

        protected class InputLine
        {
            public IList<int>? Values;
        }

        private enum Direction
        {
            Undetermined,
            Increasing,
            Decreasing
        }

        private Direction GetDirection(int v1, int v2)
        {
            if (v1 > v2)
                return Direction.Decreasing;
            else
                return Direction.Increasing;
        }

        protected bool IsValid(IList<int> ints)
        {
            var direction = Direction.Undetermined;

            var first = ints![0];

            for (var i = 1; i < ints.Count; i++)
            {
                var current = ints[i];
                var newDirection = GetDirection(first, current);

                if (direction != Direction.Undetermined)
                {
                    if (direction != newDirection)
                        return false;
                }

                var abs = Math.Abs(current - first);
                if (abs > 3 || abs < 1)
                    return false;

                first = current;
                direction = newDirection;
            }

            return true;
        }
    }
}
