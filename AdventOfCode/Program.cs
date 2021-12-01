using System;
using System.IO;
using AdventOfCode;

var partOne = DayOne.PartOne(File.ReadAllLines("../../../inputs/dayOne.txt"));
var partTwo = DayOne.PartTwo(File.ReadAllLines("../../../inputs/dayOne.txt"));
Console.WriteLine("Day one results:");
Console.WriteLine($"Part one: {partOne}");
Console.WriteLine($"Part two: {partTwo}");