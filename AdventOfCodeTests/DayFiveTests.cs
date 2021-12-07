using System.Collections.Generic;
using System.IO;
using AdventOfCode;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    public class DayFiveTests
    {
        [Test]
        public void When_evaluating_part_one_parsing_input()
        {
            var input = File.ReadAllLines("../../../../AdventOfCode/inputs/test/dayFive.txt");
            var expected = new List<int[]>
            {
                new []{0,9,5,9},
                new []{3,4,9,4},
                new []{2,1,2,2},
                new []{7,0,7,4},
                new []{0,9,2,9},
                new []{1,4,3,4}
            };
            var result = DayFive.ParseInput(input);
            Assert.That(expected, Is.EqualTo(result));
        }
        
        [Test]
        public void When_evaluating_part_one_for_crossing_horizontal_and_vertical_line()
        {
            var input = new[] { "7,0 -> 7,4", "9,4 -> 3,4" };
            var result = DayFive.PartOne(input);
            Assert.That(result, Is.EqualTo(1));
        }
        
        [Test]
        public void When_evaluating_part_one_for_crossing_horizontal_and_vertical_line_where_vertical_is_given_backwards()
        {
            var input = new[] { "7,4 -> 7,0", "9,4 -> 3,4" };
            var result = DayFive.PartOne(input);
            Assert.That(result, Is.EqualTo(1));
        }
        
        [Test]
        public void When_evaluating_part_one()
        {
            var input = File.ReadAllLines("../../../../AdventOfCode/inputs/test/dayFive.txt");
            var result = DayFive.PartOne(input);
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void When_determining_if_entry_is_diagonal()
        {
            var result = DayFive.IsDiagonal(1, 1, 3, 3);
            Assert.That(result, Is.True);
            
            result = DayFive.IsDiagonal(9, 7, 7, 9);
            Assert.That(result, Is.True);
        }

        [TestCase(1, 1, 3, 3, new [] {1, 1, 2, 2, 3, 3})]
        [TestCase(9, 7, 7, 9, new [] {9, 7, 8, 8, 7, 9})]
        public void When_determining_path_of_diagonal(int x1, int y1, int x2, int y2, int[] expected)
        {
            var result = DayFive.GetPath(x1, y1, x2, y2);
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void When_evaluating_part_two()
        {
            var input = File.ReadAllLines("../../../../AdventOfCode/inputs/test/dayFive.txt");
            var result = DayFive.PartTwo(input);
            Assert.That(result, Is.EqualTo(12));
        }
    }
}