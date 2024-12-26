using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    internal class Part1 : Day02
    {
        public int Calculate(Stream stream)
        {
            var input = ReadInput(stream);

            var rslt = 0;

            foreach (var i in input)
            {
                if (IsValid(i))
                    rslt += 1;
            }

            return rslt;
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

        private bool IsValid(InputLine input)
        {
            var direction = Direction.Undetermined;

            var first = input.Values![0];

            for (var i = 1; i < input.Values.Count; i++)
            {
                var current = input.Values[i];
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
