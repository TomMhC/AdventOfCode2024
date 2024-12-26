using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Point other) return false;

            return other.X == this.X && other.Y == this.Y;
        }

        public override string ToString()
        {
            return $"Point: ({X}, {Y})";
        }
    }
}
