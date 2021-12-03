using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class DayThree
    {
        public static int PartOne(string[] report)
        {
            var columns = new List<string>();

            columns.AddRange(
                report[0].ToCharArray()
                    .Select(value => value.ToString()));

            columns = report.Aggregate(columns,
                (current, measurement) => current
                    .Zip(measurement, (x, y) => x + y).ToList());

            var gammaList = new List<string>();
            var epsilonList = new List<string>();

            foreach (var column in columns)
            {
                gammaList.Add(
                    column.GroupBy(x => x)
                        .OrderByDescending(y => y.Count())
                        .Select(z => z.Key)
                        .First().ToString());
                epsilonList.Add(
                    column.GroupBy(x => x)
                        .OrderBy(y => y.Count())
                        .Select(z => z.Key)
                        .First().ToString());
            }

            var gamma = Convert.ToInt32(string.Join("", gammaList), 2);
            var epsilon = Convert.ToInt32(string.Join("", epsilonList), 2);

            return gamma * epsilon;
        }
    }
}