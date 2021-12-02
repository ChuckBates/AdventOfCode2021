using System.IO;
using AdventOfCode;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    public class DayTwoTests
    {
        [Test]
        public void When_evaluating_part_one_single_movement_forward()
        {
            var measurements = new[] { "forward 5" };
            var result = DayTwo.PartOne(measurements);
            Assert.That(result, Is.EqualTo(0));
        }
        
        [Test]
        public void When_evaluating_part_one_single_movement_forward_and_single_movement_down()
        {
            var measurements = new[] { "forward 5", "down 5" };
            var result = DayTwo.PartOne(measurements);
            Assert.That(result, Is.EqualTo(25));
        }
        
        [Test]
        public void When_evaluating_part_one_multiple_movements()
        {
            var measurements = File.ReadAllLines("../../../../AdventOfCode/inputs/test/dayTwo.txt");
            var result = DayTwo.PartOne(measurements);
            Assert.That(result, Is.EqualTo(150));
        }
    }
}