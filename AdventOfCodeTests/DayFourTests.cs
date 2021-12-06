using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    public class DayFourTests
    {
        [Test]
        public void When_evaluating_part_one_parse_input()
        {
            var expectedMoves = new List<int>
                {7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1};
            var expectedBoards = new List<Board>
            {
                new()
                {
                    RowColumns = new List<RowColumn>
                    {
                        new() {Squares = new List<Square> {new() {Value = 22}, new() {Value = 13}, new() {Value = 17}, new() {Value = 11}, new() {Value = 0}}},
                        new() {Squares = new List<Square> {new() {Value = 8}, new() {Value = 2}, new() {Value = 23}, new() {Value = 4}, new() {Value = 24}}},
                        new() {Squares = new List<Square> {new() {Value = 21}, new() {Value = 9}, new() {Value = 14}, new() {Value = 16}, new() {Value = 7}}},
                        new() {Squares = new List<Square> {new() {Value = 6}, new() {Value = 10}, new() {Value = 3}, new() {Value = 18}, new() {Value = 5}}},
                        new() {Squares = new List<Square> {new() {Value = 1}, new() {Value = 12}, new() {Value = 20}, new() {Value = 15}, new() {Value = 19}}},
                        
                        new() {Squares = new List<Square> {new() {Value = 22}, new() {Value = 8}, new() {Value = 21}, new() {Value = 6}, new() {Value = 1}}},
                        new() {Squares = new List<Square> {new() {Value = 13}, new() {Value = 2}, new() {Value = 9}, new() {Value = 10}, new() {Value = 12}}},
                        new() {Squares = new List<Square> {new() {Value = 17}, new() {Value = 23}, new() {Value = 14}, new() {Value = 3}, new() {Value = 20}}},
                        new() {Squares = new List<Square> {new() {Value = 11}, new() {Value = 4}, new() {Value = 16}, new() {Value = 18}, new() {Value = 15}}},
                        new() {Squares = new List<Square> {new() {Value = 0}, new() {Value = 24}, new() {Value = 7}, new() {Value = 5}, new() {Value = 19}}},
                    }
                },
                new()
                {
                    RowColumns = new List<RowColumn>
                    {
                        new() {Squares = new List<Square> {new() {Value = 3}, new() {Value = 15}, new() {Value = 0}, new() {Value = 2}, new() {Value = 22}}},
                        new() {Squares = new List<Square> {new() {Value = 9}, new() {Value = 18}, new() {Value = 13}, new() {Value = 17}, new() {Value = 5}}},
                        new() {Squares = new List<Square> {new() {Value = 19}, new() {Value = 8}, new() {Value = 7}, new() {Value = 25}, new() {Value = 23}}},
                        new() {Squares = new List<Square> {new() {Value = 20}, new() {Value = 11}, new() {Value = 10}, new() {Value = 24}, new() {Value = 4}}},
                        new() {Squares = new List<Square> {new() {Value = 14}, new() {Value = 21}, new() {Value = 16}, new() {Value = 12}, new() {Value = 6}}},
                        
                        new() {Squares = new List<Square> {new() {Value = 3}, new() {Value = 9}, new() {Value = 19}, new() {Value = 20}, new() {Value = 14}}},
                        new() {Squares = new List<Square> {new() {Value = 15}, new() {Value = 18}, new() {Value = 8}, new() {Value = 11}, new() {Value = 21}}},
                        new() {Squares = new List<Square> {new() {Value = 0}, new() {Value = 13}, new() {Value = 7}, new() {Value = 10}, new() {Value = 16}}},
                        new() {Squares = new List<Square> {new() {Value = 2}, new() {Value = 17}, new() {Value = 25}, new() {Value = 24}, new() {Value = 12}}},
                        new() {Squares = new List<Square> {new() {Value = 22}, new() {Value = 5}, new() {Value = 23}, new() {Value = 4}, new() {Value = 6}}},
                    }
                },
                new()
                {
                    RowColumns = new List<RowColumn>
                    {
                        new() {Squares = new List<Square> {new() {Value = 14}, new() {Value = 21}, new() {Value = 17}, new() {Value = 24}, new() {Value = 4}}},
                        new() {Squares = new List<Square> {new() {Value = 10}, new() {Value = 16}, new() {Value = 15}, new() {Value = 9}, new() {Value = 19}}},
                        new() {Squares = new List<Square> {new() {Value = 18}, new() {Value = 8}, new() {Value = 23}, new() {Value = 26}, new() {Value = 20}}},
                        new() {Squares = new List<Square> {new() {Value = 22}, new() {Value = 11}, new() {Value = 13}, new() {Value = 6}, new() {Value = 5}}},
                        new() {Squares = new List<Square> {new() {Value = 2}, new() {Value = 0}, new() {Value = 12}, new() {Value = 3}, new() {Value = 7}}},
                        
                        new() {Squares = new List<Square> {new() {Value = 14}, new() {Value = 10}, new() {Value = 18}, new() {Value = 22}, new() {Value = 2}}},
                        new() {Squares = new List<Square> {new() {Value = 21}, new() {Value = 16}, new() {Value = 8}, new() {Value = 11}, new() {Value = 0}}},
                        new() {Squares = new List<Square> {new() {Value = 17}, new() {Value = 15}, new() {Value = 23}, new() {Value = 13}, new() {Value = 12}}},
                        new() {Squares = new List<Square> {new() {Value = 24}, new() {Value = 9}, new() {Value = 26}, new() {Value = 6}, new() {Value = 3}}},
                        new() {Squares = new List<Square> {new() {Value = 4}, new() {Value = 19}, new() {Value = 20}, new() {Value = 5}, new() {Value = 7}}},
                    }
                }
            };
            var input = File.ReadAllLines("../../../../AdventOfCode/inputs/test/dayFour.txt");
            var (moves, boards) = DayFour.ParseInput(input);
            Assert.That(moves, Is.EqualTo(expectedMoves));
            Assert.That(boards[0].GetValues(), Is.EqualTo(expectedBoards[0].GetValues()));
            Assert.That(boards[1].GetValues(), Is.EqualTo(expectedBoards[1].GetValues()));
            Assert.That(boards[2].GetValues(), Is.EqualTo(expectedBoards[2].GetValues()));
        }

        [Test]
        public void When_evaluating_part_one()
        {
            var input = File.ReadAllLines("../../../../AdventOfCode/inputs/test/dayFour.txt");
            var result = DayFour.PartOne(input);
            Assert.That(result, Is.EqualTo(4512));
        }

        [Test]
        public void When_evaluating_part_two()
        {
            var input = File.ReadAllLines("../../../../AdventOfCode/inputs/test/dayFour.txt");
            var result = DayFour.PartTwo(input);
            Assert.That(result, Is.EqualTo(1924));
        }
    }
}