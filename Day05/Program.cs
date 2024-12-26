
using Day05;
using System.Diagnostics;
using System.IO;
using System.Reflection;

var stopwatch = new Stopwatch();
stopwatch.Start();

var exampleStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Day05.Example.txt");
var exampleRslt = new Part2().Calculate(exampleStream);
Console.WriteLine(exampleRslt);

var inputStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Day05.Input.txt");
var rslt = new Part2().Calculate(inputStream); // 4507
Console.WriteLine(rslt);

stopwatch.Stop();

Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds}ms");