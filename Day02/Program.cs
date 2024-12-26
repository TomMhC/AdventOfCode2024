﻿
using Day02;
using System.Reflection;

var exampleStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Day02.Example.txt");
var exampleRslt = new Part2().Calculate(exampleStream);
Console.WriteLine(exampleRslt);

var inputStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Day02.Input.txt");
var rslt = new Part2().Calculate(inputStream);
Console.WriteLine(rslt);