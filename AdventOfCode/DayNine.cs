using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class DayNine
    {
        public static int PartOne(string[] input)
        {
            var lows = FindLows(input);
            var grid = BuildGrid(input);

            return lows.Sum(low => grid[low.Item1, low.Item2] + 1);
        }

        public static int PartTwo(string[] input)
        {
            var lows = FindLows(input);
            var grid = BuildGrid(input);
            var basins = new List<List<(int, int)>>();
            foreach (var low in lows)
            {
                basins.Add(FindBasin(grid,(low.Item1, low.Item2)));
            }

            var topThreeBasins = basins.OrderByDescending(x => x.Count).Take(3);
            return topThreeBasins.Aggregate(1, (current, basin) => current * basin.Count);
        }

        public static (int,int)[] FindLows(string[] input)
        {
            var grid = BuildGrid(input);

            var lows = new List<(int,int)>();
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    var neighbors = GetNeighborsAtLocation(i, j, grid);
                    if (neighbors.All(x => grid[x.Item1, x.Item2] > grid[i,j]))
                    {
                        lows.Add((i,j));
                    }
                }
            }

            return lows.ToArray();
        }

        private static int[,] BuildGrid(string[] input)
        {
            var grid = new int[input.Length, input[0].Length];
            for (var i = 0; i < input.Length; i++)
            {
                var line = input[i].ToCharArray();
                for (var j = 0; j < input[0].Length; j++)
                {
                    grid[i, j] = int.Parse(line[j].ToString());
                }
            }

            return grid;
        }

        public static List<(int, int)> FindBasin(int[,] grid, (int,int) low)
        {
            var basin = new List<(int,int)>();
            basin.Add((low.Item1,low.Item2));
            TraverseNeighbors(low.Item1, low.Item2, grid, basin);
            return basin;
        }

        public static void TraverseNeighbors(int x, int y, int[,] grid, List<(int,int)> basin)
        {
            var neighbors = GetNeighborsAtLocation(x, y, grid);
            foreach (var neighbor in neighbors)
            {
                var height = grid[neighbor.Item1, neighbor.Item2];
                if (height < 9 && !basin.Contains((neighbor.Item1, neighbor.Item2)))
                {
                    basin.Add((neighbor.Item1, neighbor.Item2));
                    TraverseNeighbors(neighbor.Item1, neighbor.Item2, grid, basin);
                }
            }
        }
        
        public static (int,int)[] GetNeighborsAtLocation(int x, int y, int[,] grid)
        {
            var rows = grid.GetLength(0);
            var columns = grid.GetLength(1);
            var neighbors = new List<(int,int)>();
            for (var i = x - 1; i <= x + 1; i++)
            {
                if (i < 0 || i >= rows)
                {
                    continue;
                }
                for (var j = y - 1; j <= y + 1; j++)
                {
                    if (j < 0 || j >= columns)
                    {
                        continue;
                    }
                    if (i != x && j != y)
                    {
                        continue;
                    }
                    if (i == x && j == y)
                    {
                        continue;
                    }
                    neighbors.Add((i,j));
                }
            }

            return neighbors.ToArray();
        }
    }
}