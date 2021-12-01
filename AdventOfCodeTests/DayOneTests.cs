using System.IO;
using AdventOfCode;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    public class DayOneTests
    {
        [Test]
        public void When_evaluating_part_one_for_two_measurements()
        {
            var measurements = new[] { "1", "2" };
            var result = DayOne.PartOne(measurements);
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void When_evaluation_part_one_for_test_input()
        {
            var measurements = File.ReadAllLines("../../../../AdventOfCode/inputs/test/dayOne.txt");
            var result = DayOne.PartOne(measurements);
            Assert.That(result, Is.EqualTo(7));
        }
    }
}