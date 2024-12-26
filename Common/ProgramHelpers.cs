using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ProgramHelpers
    {
        public static void CalculateResult(Assembly asm, string streamName, ICalculatorI calculator)
        {
            var stream = asm.GetManifestResourceStream(streamName);
            var rslt = calculator.Calculate(stream);
            Console.WriteLine(rslt);
        }
    }
}
