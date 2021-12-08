using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class DayEight
    {
        public static int PartOne(string[] input)
        {
            return input
                .Select(line => line.Split('|')[1].Split(' ').ToList())
                .Select(parts => parts.Count(x => x.Length is 2 or 4 or 3 or 7))
                .Sum();
        }

        public static int PartTwo(string[] input)
        {
            var count = 0;
            foreach (var line in input)
            {
                count += int.Parse(Decode(line));
            }

            return count;
        }

        public static string Decode(string line)
        {
            var result = string.Empty;
            var parts = line.Split('|');
            var patterns = parts[0].Trim().Split(' ').ToList();
            var outputs = parts[1].Trim().Split(' ').ToList();
            var map = new Dictionary<string, int>();

            var one = patterns.First(x => x.Length == 2);
            patterns.Remove(one);
            map.Add(string.Concat(one.OrderBy(x => x)), 1);
            
            var four = patterns.First(x => x.Length == 4);
            patterns.Remove(four);
            map.Add(string.Concat(four.OrderBy(x => x)), 4);
            
            var seven = patterns.First(x => x.Length == 3);
            patterns.Remove(seven);
            map.Add(string.Concat(seven.OrderBy(x => x)), 7);
            
            var eight = patterns.First(x => x.Length == 7);
            patterns.Remove(eight);
            map.Add(string.Concat(eight.OrderBy(x => x)), 8);

            var three = patterns.First(x => one.All(x.Contains) && x.Length == 5);
            patterns.Remove(three);
            map.Add(string.Concat(three.OrderBy(x => x)), 3);

            var nine = patterns.First(x => four.All(x.Contains) && x.Length == 6);
            patterns.Remove(nine);
            map.Add(string.Concat(nine.OrderBy(x => x)), 9);

            var zero = patterns.First(x => one.All(x.Contains));
            patterns.Remove(zero);
            map.Add(string.Concat(zero.OrderBy(x => x)), 0);

            var six = patterns.First(x => x.Length == 6);
            patterns.Remove(six);
            map.Add(string.Concat(six.OrderBy(x => x)), 6);

            var five = patterns.First(x => x.All(six.Contains) && x.Length == 5);
            patterns.Remove(five);
            map.Add(string.Concat(five.OrderBy(x => x)), 5);

            var two = patterns.First();
            map.Add(string.Concat(two.OrderBy(x => x)), 2);

            foreach (var output in outputs)
            {
                result += map[string.Concat(output.OrderBy(x => x))];
            }
            
            return result;
        }
    }
}