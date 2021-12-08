using System.IO;
using AdventOfCode;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    public class DaySevenTests
    {
        [Test]
        public void When_evaluation_part_one()
        {
            var input = File.ReadAllLines("../../../../AdventOfCode/inputs/test/daySeven.txt");
            var result = DaySeven.PartOne(input);
            Assert.That(result, Is.EqualTo(37));
        }
        
        [TestCase(0, 5, 15)]
        [TestCase(1, 5, 10)]
        [TestCase(2, 5, 6)]
        [TestCase(3, 5, 3)]
        [TestCase(4, 5, 1)]
        [TestCase(5, 5, 0)]
        [TestCase(6, 5, 1)]
        [TestCase(7, 5, 3)]
        [TestCase(8, 5, 6)]
        [TestCase(9, 5, 10)]
        [TestCase(10, 5, 15)]
        [TestCase(16, 5, 66)]
        public void When_evaluation_cost(int start, int end, int expected)
        {
            var result = DaySeven.GetCost(start, end);
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void When_evaluation_part_two()
        {
            var input = File.ReadAllLines("../../../../AdventOfCode/inputs/test/daySeven.txt");
            var result = DaySeven.PartTwo(input);
            Assert.That(result, Is.EqualTo(168));
        }
    }
}