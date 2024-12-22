
using Day11;
using System.IO;
using System.Reflection;


//var testStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Day11.Test.txt")!;
//var testRslt = new Part2().Calculate(testStream, 5);
//Console.WriteLine(testRslt);

//var exampleStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Day11.Example1.txt")!;
//var exampleRslt = new Part2().Calculate(exampleStream, 1);
//Console.WriteLine(exampleRslt);

//var example2Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Day11.Example2.txt")!;
//var example2Rslt = new Part2().Calculate(example2Stream, 6);
//Console.WriteLine(example2Rslt);

//var inputStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Day11.Input.txt")!;
//var rslt = new Part2().Calculate(inputStream, 25);
//Console.WriteLine(rslt);
//inputStream.Close();

var inputStream2 = Assembly.GetExecutingAssembly().GetManifestResourceStream("Day11.Input.txt")!;
var rslt2 = new Part2().Calculate(inputStream2, 75);
Console.WriteLine(rslt2);