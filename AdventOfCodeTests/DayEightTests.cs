using System.IO;
using AdventOfCode;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    public class DayEightTests
    {
        [Test]
        public void When_evaluating_part_one()
        {
            var input = File.ReadAllLines("../../../../AdventOfCode/inputs/test/dayEight.txt");
            var result = DayEight.PartOne(input);
            Assert.That(result, Is.EqualTo(26));
        }
        
        [Test]
        public void When_evaluating_part_two()
        {
            var input = File.ReadAllLines("../../../../AdventOfCode/inputs/test/dayEight.txt");
            var result = DayEight.PartTwo(input);
            Assert.That(result, Is.EqualTo(61229));
        }
    }
}