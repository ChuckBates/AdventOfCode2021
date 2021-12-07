using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class DayFive
    {
        public static int PartOne(string[] input)
        {
            var coordinates = ParseInput(input);
            var map = new int[1000, 1000];
            foreach (var coordinate in coordinates)
            {
                for (var i = coordinate[0]; i <= coordinate[2]; i++)
                {
                    for (var j = coordinate[1]; j <= coordinate[3]; j++)
                    {
                        map[i, j]++;
                    }
                }
            }

            return map.Cast<int>().Count(value => value > 1);
        }
        
        public static int PartTwo(string[] input)
        {
            var coordinates = ParseInputPartTwo(input);
            var map = new int[1000, 1000];
            foreach (var coordinate in coordinates)
            {
                var x1 = coordinate[0];
                var y1 = coordinate[1];
                var x2 = coordinate[2];
                var y2 = coordinate[3];
                
                if (IsDiagonal(x1, y1, x2, y2))
                {
                    var path = GetPath(x1, y1, x2, y2);
                    for (var i = 0; i < path.Length; i += 2)
                    {
                        var x = path[i];
                        var y = path[i + 1];
                        map[x, y]++;
                    }
                }
                else
                {
                    for (var i = x1; i <= x2; i++)
                    {
                        for (var j = y1; j <= y2; j++)
                        {
                            map[i, j]++;
                        }
                    }
                }
            }

            return map.Cast<int>().Count(value => value > 1);
        }

        public static List<int[]> ParseInput(string[] input)
        {
            var result = new List<int[]>();
            foreach (var line in input)
            {
                var parts = line.Split(' ');
                var x1 = int.Parse(parts[0].Split(',')[0]);
                var y1 = int.Parse(parts[0].Split(',')[1]);
                var x2 = int.Parse(parts[2].Split(',')[0]);
                var y2 = int.Parse(parts[2].Split(',')[1]);
                if (x1 == x2 || y1 == y2)
                {
                    if (x1 > x2)
                    {
                        result.Add(new [] {x2, y2, x1, y1});
                    }
                    else if (y1 > y2)
                    {
                        result.Add(new [] {x2, y2, x1, y1});
                    }
                    else
                    {
                        result.Add(new[] {x1, y1, x2, y2});
                    }
                }
            }

            return result;
        }
        
        public static List<int[]> ParseInputPartTwo(string[] input)
        {
            var result = new List<int[]>();
            foreach (var line in input)
            {
                var parts = line.Split(' ');
                var x1 = int.Parse(parts[0].Split(',')[0]);
                var y1 = int.Parse(parts[0].Split(',')[1]);
                var x2 = int.Parse(parts[2].Split(',')[0]);
                var y2 = int.Parse(parts[2].Split(',')[1]);
                if (x1 == x2 || y1 == y2 || IsDiagonal(x1, y1, x2, y2))
                {
                    if (x1 > x2)
                    {
                        result.Add(new [] {x2, y2, x1, y1});
                    }
                    else if (y1 > y2)
                    {
                        result.Add(new [] {x2, y2, x1, y1});
                    }
                    else
                    {
                        result.Add(new[] {x1, y1, x2, y2});
                    }
                }
            }

            return result;
        }

        public static bool IsDiagonal(int x1, int y1, int x2, int y2)
        {
            if (Math.Abs(x2 - x1) == Math.Abs(y2 - y1))
            {
                return true;
            }
            return false;
        }

        public static int[] GetPath(int x1, int y1, int x2, int y2)
        {
            var result = new List<int>();

            if (x1 < x2 && y1 < y2)
            {
                for (var i = 0; i <= x2 - x1; i++)
                {
                    result.Add(x1 + i);
                    result.Add(y1 + i );
                }
            }
            else
            {
                var xIncreasing = x1 < x2;
                var yIncreasing = y1 < y2;

                result.Add(x1);
                result.Add(y1);
                while (true)
                {
                    x1 = xIncreasing ? ++x1 : --x1;
                    y1 = yIncreasing ? ++y1 : --y1;
                    
                    result.Add(x1);
                    result.Add(y1);

                    if (x1 == x2)
                    {
                        break;
                    }
                }
            }

            return result.ToArray();
        }
    }
}