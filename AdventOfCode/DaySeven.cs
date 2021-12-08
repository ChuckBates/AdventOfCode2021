using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class DaySeven
    {
        public static int PartOne(string[] input)
        {
            var positions = input[0].Split(',').ToList().Select(int.Parse).OrderBy(x => x).ToList();
            var median = GetMedian(positions);

            return CalculateFuel(positions, median);
        }

        private static int CalculateFuel(List<int> positions, int median)
        {
            var fuel = 0;
            foreach (var position in positions)
            {
                fuel += Math.Abs(position - median);
            }

            return fuel;
        }

        private static int GetMedian(List<int> positions)
        {
            var even = positions.Count % 2 == 0;
            int median;
            if (even)
            {
                var middleOne = positions[positions.Count / 2 - 1];
                var middleTwo = positions[positions.Count / 2];
                median = (middleOne + middleTwo) / 2;
            }
            else
            {
                median = positions[positions.Count / 2];
            }

            return median;
        }

        public static int PartTwo(string[] input)
        {
            var positions = input[0].Split(',').ToList().Select(int.Parse).OrderBy(x => x).ToList();

            var bestCost = int.MaxValue;
            foreach (var i in Enumerable.Range(positions.First(), positions.Last()))
            {
                var cost = positions.Sum(position => GetCost(i, position));
                if (cost < bestCost)
                {
                    bestCost = cost;
                }
            }
            return bestCost;
        }

        public static int GetCost(int start, int end)
        {
            var difference = Math.Abs(start - end);
            return difference * (difference + 1) / 2;
        }
    }
}