using System.IO;
using AdventOfCode;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    public class DayNineTests
    {
        [Test]
        public void When_evaluating_part_one()
        {
            var input = File.ReadAllLines("../../../../AdventOfCode/inputs/test/dayNine.txt");
            var result = DayNine.PartOne(input);
            Assert.That(result, Is.EqualTo(15));
        }
        
        [Test]
        public void When_evaluating_part_two()
        {
            var input = File.ReadAllLines("../../../../AdventOfCode/inputs/test/dayNine.txt");
            var result = DayNine.PartTwo(input);
            Assert.That(result, Is.EqualTo(1134));
        }
        
        [Test]
        public void When_finding_low_points()
        {
            var input = File.ReadAllLines("../../../../AdventOfCode/inputs/test/dayNine.txt");
            var result = DayNine.FindLows(input);
            var expected = new[] { (0,1),(0,9),(2,2),(4,6) };
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void When_finding_basin_one()
        {
            var input = new int[3,3];
            input[0, 0] = 2;
            input[1, 0] = 1;
            input[2, 0] = 9;
            input[0, 1] = 3;
            input[1, 1] = 9;
            input[2, 1] = 8;
            input[0, 2] = 9;
            input[1, 2] = 8;
            input[2, 2] = 5;
            var result = DayNine.FindBasin(input, (1,0));
            Assert.That(result, Is.EqualTo(new [] {(1,0),(0,0),(0,1)}));
        }

        [Test]
        public void When_finding_basin_two()
        {
            var input = new int[6,4];
            input[0, 0] = 9;
            input[1, 0] = 4;
            input[2, 0] = 3;
            input[3, 0] = 2;
            input[4, 0] = 1;
            input[5, 0] = 0;
            
            input[0, 1] = 8;
            input[1, 1] = 9;
            input[2, 1] = 4;
            input[3, 1] = 9;
            input[4, 1] = 2;
            input[5, 1] = 1;
            
            input[0, 2] = 7;
            input[1, 2] = 8;
            input[2, 2] = 9;
            input[3, 2] = 8;
            input[4, 2] = 9;
            input[5, 2] = 2;
            
            input[0, 3] = 8;
            input[1, 3] = 9;
            input[2, 3] = 6;
            input[3, 3] = 7;
            input[4, 3] = 8;
            input[5, 3] = 9;
            var result = DayNine.FindBasin(input, (1,0));
            var expected = new [] { (1,0), (2,0), (2,1), (3,0), (4,0), (4,1), (5,1), (5,0), (5,2) };
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void When_getting_neighbors()
        {
            var input = new int[3,3];
            input[0, 0] = 2;
            input[1, 0] = 1;
            input[2, 0] = 9;
            input[0, 1] = 3;
            input[1, 1] = 9;
            input[2, 1] = 8;
            input[0, 2] = 9;
            input[1, 2] = 8;
            input[2, 2] = 5;
            var result = DayNine.GetNeighborsAtLocation( 0, 1, input);
            Assert.That(result, Is.EqualTo(new [] {(0,0), (0,2), (1,1) }));
        }
    }
}