﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    internal class Part1 : Day1
    {
        internal int Calculate()
        {
            var input = ReadInput();

            var lst1Ordered = input.List1.Order().ToList();
            var lst2Ordered = input.List2.Order().ToList();

            var total = 0;

            for(var i = 0; i< lst1Ordered.Count; i++)
            {
                total += Math.Abs(lst1Ordered[i] - lst2Ordered[i]);
            }

            return total;
        }
    }
}
