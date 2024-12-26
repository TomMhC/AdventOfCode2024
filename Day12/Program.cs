using Day12;
using Common;
using System.Reflection;

Day12.Day12 calculator = new Part1();

var thisAssembly = Assembly.GetExecutingAssembly();

ProgramHelpers.CalculateResult(thisAssembly, "Day12.Example.txt", calculator);
ProgramHelpers.CalculateResult(thisAssembly, "Day12.Example2.txt", calculator);
ProgramHelpers.CalculateResult(thisAssembly, "Day12.Example3.txt", calculator);
ProgramHelpers.CalculateResult(thisAssembly, "Day12.Input.txt", calculator);
