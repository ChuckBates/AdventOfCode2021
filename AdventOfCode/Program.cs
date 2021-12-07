using System;
using System.IO;
using AdventOfCode;

// var partOne = DayOne.PartOne(File.ReadAllLines("../../../inputs/dayOne.txt"));
// var partTwo = DayOne.PartTwo(File.ReadAllLines("../../../inputs/dayOne.txt"));
// Console.WriteLine("Day one results:");
// Console.WriteLine($"Part one: {partOne}");
// Console.WriteLine($"Part two: {partTwo}");

// var partOne = DayTwo.PartOne(File.ReadAllLines("../../../inputs/dayTwo.txt"));
// var partTwo = DayTwo.PartTwo(File.ReadAllLines("../../../inputs/dayTwo.txt"));
// Console.WriteLine("Day two results:");
// Console.WriteLine($"Part one: {partOne}");
// Console.WriteLine($"Part two: {partTwo}");

// var partOne = DayThree.PartOne(File.ReadAllLines("../../../inputs/dayThree.txt"));
// var partTwo = DayThree.PartTwo(File.ReadAllLines("../../../inputs/dayThree.txt"));
// Console.WriteLine("Day three results:");
// Console.WriteLine($"Part one: {partOne}");
// Console.WriteLine($"Part two: {partTwo}");

// var partOne = DayFour.PartOne(File.ReadAllLines("../../../inputs/dayFour.txt"));
// var partTwo = DayFour.PartTwo(File.ReadAllLines("../../../inputs/dayFour.txt"));
// Console.WriteLine("Day four results:");
// Console.WriteLine($"Part one: {partOne}");
// Console.WriteLine($"Part two: {partTwo}");

// var partOne = DayFive.PartOne(File.ReadAllLines("../../../inputs/dayFive.txt"));
// var partTwo = DayFive.PartTwo(File.ReadAllLines("../../../inputs/dayFive.txt"));
// Console.WriteLine("Day five results:");
// Console.WriteLine($"Part one: {partOne}");
// Console.WriteLine($"Part two: {partTwo}");

var partOne = DaySix.Evaluate(File.ReadAllLines("../../../inputs/daySix.txt"), 80);
var partTwo = DaySix.Evaluate(File.ReadAllLines("../../../inputs/daySix.txt"), 256);
Console.WriteLine("Day six results:");
Console.WriteLine($"Part one: {partOne}");
Console.WriteLine($"Part two: {partTwo}");