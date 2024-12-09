﻿
using Day07;
using System.IO;
using System.Reflection;

var exampleStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Day07.Example.txt")!;
var exampleRslt = new Part1().Calculate(exampleStream);
Console.WriteLine(exampleRslt);

var inputStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Day07.Input.txt")!;
var rslt = new Part1().Calculate(inputStream);
Console.WriteLine(rslt);