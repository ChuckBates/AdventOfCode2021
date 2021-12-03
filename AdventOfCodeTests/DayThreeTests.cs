using System.IO;
using AdventOfCode;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    public class DayThreeTests
    {
        [Test]
        public void When_evaluating_part_one_for_a_single_numbers()
        {
            var report = new[] { "00100" };
            var result = DayThree.PartOne(report);
            Assert.That(result, Is.EqualTo(16));
        }
        
        [Test]
        public void When_evaluating_part_one_for_multiple_numbers()
        {
            var report = File.ReadAllLines("../../../../AdventOfCode/inputs/test/dayThree.txt");
            var result = DayThree.PartOne(report);
            Assert.That(result, Is.EqualTo(198));
        }
        
        [Test]
        public void When_evaluating_part_two_oxy_for_a_single_number()
        {
            var report = new[] { "00100" };
            var result = DayThree.GetOxygenGeneratorRating(report);
            Assert.That(result, Is.EqualTo(4));
        }
        
        [Test]
        public void When_evaluating_part_two_oxy_for_test_input()
        {
            var report = File.ReadAllLines("../../../../AdventOfCode/inputs/test/dayThree.txt");
            var result = DayThree.GetOxygenGeneratorRating(report);
            Assert.That(result, Is.EqualTo(23));
        }
        
        [Test]
        public void When_evaluating_part_two_co2_for_test_input()
        {
            var report = File.ReadAllLines("../../../../AdventOfCode/inputs/test/dayThree.txt");
            var result = DayThree.GetCO2ScrubberRating(report);
            Assert.That(result, Is.EqualTo(10));
        }
        
        [Test]
        public void When_evaluating_part_two_for_test_input()
        {
            var report = File.ReadAllLines("../../../../AdventOfCode/inputs/test/dayThree.txt");
            var result = DayThree.PartTwo(report);
            Assert.That(result, Is.EqualTo(230));
        }
    }
}