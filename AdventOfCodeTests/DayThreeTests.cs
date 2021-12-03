using System.IO;
using AdventOfCode;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    public class DayThreeTests
    {
        [Test]
        public void When_evaluating_day_three_for_a_single_number()
        {
            var report = File.ReadAllLines("../../../../AdventOfCode/inputs/test/dayThree.txt");
            var result = DayThree.PartOne(report);
            Assert.That(result, Is.EqualTo(198));
        }
    }
}