﻿
using Day09;
using System.IO;
using System.Reflection;

//var exampleStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Day09.Example.txt")!;
//var exampleRslt = new Part2().Calculate(exampleStream);
//Console.WriteLine(exampleRslt);

var inputStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Day09.Input.txt")!;
var rslt = new Part2().Calculate(inputStream);
Console.WriteLine(rslt);