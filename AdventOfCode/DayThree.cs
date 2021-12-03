using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class DayThree
    {
        public static int PartOne(string[] report)
        {
            var columns = GenerateColumns(report);

            var gammaList = new List<string>();
            var epsilonList = new List<string>();

            foreach (var column in columns)
            {
                gammaList.Add(GetMostCommon(column));
                epsilonList.Add(GetLeastCommon(column));
            }

            var gamma = Convert.ToInt32(string.Join("", gammaList), 2);
            var epsilon = Convert.ToInt32(string.Join("", epsilonList), 2);

            return gamma * epsilon;
        }

        public static int PartTwo(string[] report)
        {
            return GetOxygenGeneratorRating(report) * GetCO2ScrubberRating(report);
        }

        private static List<string> GenerateColumns(string[] report)
        {
            var columns = new List<string>();

            columns.AddRange(
                report[0].ToCharArray()
                    .Select(value => value.ToString()));

            columns = report.Skip(1).Aggregate(columns,
                (current, measurement) => current
                    .Zip(measurement, (x, y) => x + y).ToList());

            return columns;
        }

        public static int GetOxygenGeneratorRating(string[] report)
        {
            var rating = Filter(GenerateColumns(report)[0], report.ToList(), 0, "oxy");
            
            return Convert.ToInt32(string.Join("", rating), 2);
        }

        public static int GetCO2ScrubberRating(string[] report)
        {
            var rating = Filter(GenerateColumns(report)[0], report.ToList(), 0, "co2");
            
            return Convert.ToInt32(string.Join("", rating), 2);
        }

        private static List<string> Filter(string columns, List<string> input, int postion, string type)
        {
            if (input.Count == 1)
            {
                return input;
            }
            
            var keep = new List<string>();
            string filter;
            if (columns.Count(x => x == '0') == columns.Count(y => y == '1'))
            {
                filter = type == "oxy" ? "1" : "0";
            }
            else
            {
                filter = type == "oxy" ? GetMostCommon(columns) : GetLeastCommon(columns);
            }
            
            for (var i = 0; i < columns.Length; i++)
            {
                if (input[i][postion].ToString() == filter)
                {
                    keep.Add(input[i]);
                }
            }

            if (postion == input[0].Length - 1)
            {
                return keep;
            }

            return Filter(GenerateColumns(keep.ToArray())[postion + 1], keep, postion + 1, type);
        }

        private static string GetMostCommon(string column)
        {
            return column.GroupBy(x => x)
                .OrderByDescending(y => y.Count())
                .Select(z => z.Key)
                .First().ToString();
        }

        private static string GetLeastCommon(string column)
        {
            return column.GroupBy(x => x)
                .OrderBy(y => y.Count())
                .Select(z => z.Key)
                .First().ToString();
        }
    }
}