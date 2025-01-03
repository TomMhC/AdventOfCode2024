﻿using System;
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

        private bool IsValid(InputLine line)
        {
            return base.IsValid(line.Values!);
        }
    }
}
