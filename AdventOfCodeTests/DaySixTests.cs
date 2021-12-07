using System.IO;
using System.Linq;
using AdventOfCode;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    public class DaySixTests
    {
        [TestCase(18, 26)]
        [TestCase(80, 5934)]
        [TestCase(256, 26984457539)]
        public void When_evaluating_part_one(int duration, long expected)
        {
            var input = File.ReadAllLines("../../../../AdventOfCode/inputs/test/daySix.txt");
            var result = DaySix.Evaluate(input, duration);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}