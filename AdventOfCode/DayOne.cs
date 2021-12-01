using System.Linq;

namespace AdventOfCode
{
    public static class DayOne
    {
        public static int PartOne(string[] input)
        {
            return input.Where((t, i) => i > 0 && int.Parse(t) > int.Parse(input[i - 1])).Count();
        }

        public static int PartTwo(string[] input)
        {
            return input.Where((t, i) =>
            {
                if (i > 2)
                {
                    var latterThree = int.Parse(t) + int.Parse(input[i - 1]) + int.Parse(input[i - 2]);
                    var formerThree = int.Parse(input[i - 1]) + int.Parse(input[i - 2]) + int.Parse(input[i - 3]);

                    return latterThree > formerThree;
                }

                return false;
            }).Count();
        }
    }
}