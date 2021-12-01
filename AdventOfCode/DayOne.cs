using System.Linq;

namespace AdventOfCode
{
    public static class DayOne
    {
        public static int PartOne(string[] input)
        {
            return input.Where((t, i) => i > 0 && int.Parse(t) > int.Parse(input[i - 1])).Count();
        }
    }
}