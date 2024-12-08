
using Day03;
using System.Reflection;

var exampleStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Day03.Example2.txt");
var exampleRslt = new Part2().Calculate(exampleStream);
Console.WriteLine(exampleRslt);

var inputStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Day03.Input.txt");
var rslt = new Part2().Calculate(inputStream);
Console.WriteLine(rslt);