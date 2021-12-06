using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class DayFour
    {
        public static int PartOne(string[] input)
        {
            var (moves, boards) = ParseInput(input);
            var score = 0;
            
            foreach (var move in moves)
            {
                foreach (var square in boards.SelectMany(board => board.RowColumns.SelectMany(rowColumn => rowColumn.Squares.Where(square => square.Value == move))))
                {
                    square.Called = true;
                }

                foreach (var board in boards)
                {
                    if (board.RowColumns.Any(x => x.Squares.All(y => y.Called)))
                    {
                        score = board.RowColumns.Take(5).Sum(rowColumn => rowColumn.Squares.Where(x => !x.Called).Sum(y => y.Value)) * move;
                        return score;
                    };
                }
            }

            return score;
        }
        
        public static int PartTwo(string[] input)
        {
            var (moves, boards) = ParseInput(input);
            var score = 0;
            
            foreach (var move in moves)
            {
                foreach (var square in boards.SelectMany(board => board.RowColumns.SelectMany(rowColumn => rowColumn.Squares.Where(square => square.Value == move))))
                {
                    square.Called = true;
                }

                foreach (var board in boards)
                {
                    if (board.RowColumns.Any(x => x.Squares.All(y => y.Called)))
                    {
                        board.Won = true;
                        if (boards.All(x => x.Won))
                        {
                            score = board.RowColumns.Take(5).Sum(rowColumn => rowColumn.Squares.Where(x => !x.Called).Sum(y => y.Value)) * move;
                            return score;
                        }
                    };
                }
            }

            return score;
        }

        public static (List<int>, List<Board>) ParseInput(string[] input)
        {
            var moves = new List<int>();
            var boards = new List<Board>();
            var temp = new List<RowColumn>();
            var firstEmptyLine = false;

            foreach (var line in input)
            {
                if (!firstEmptyLine)
                {
                    if (line == "")
                    {
                        firstEmptyLine = true;
                        continue;
                    }

                    moves.AddRange(line.Split(',').ToList().Where(x => x != "").Select(int.Parse));
                    continue;
                }

                if (line == "")
                {
                    continue;
                }


                temp.Add(
                    new RowColumn
                    {
                        Squares = line.Split(' ').ToList().Where(x => x != "").Select(y => new Square {Value = int.Parse(y)}).ToList()
                    });
            }

            var count = 0;
            while (count < temp.Count)
            {
                var boardRows = temp.Skip(count).Take(5).ToList();
                var column1 = new RowColumn();
                var column2 = new RowColumn();
                var column3 = new RowColumn();
                var column4 = new RowColumn();
                var column5 = new RowColumn();

                foreach (var boardRow in boardRows)
                {
                    column1.Squares.Add(boardRow.Squares[0]);
                    column2.Squares.Add(boardRow.Squares[1]);
                    column3.Squares.Add(boardRow.Squares[2]);
                    column4.Squares.Add(boardRow.Squares[3]);
                    column5.Squares.Add(boardRow.Squares[4]);
                }

                var board = new Board();
                board.RowColumns.AddRange(boardRows);
                board.RowColumns.Add(column1);
                board.RowColumns.Add(column2);
                board.RowColumns.Add(column3);
                board.RowColumns.Add(column4);
                board.RowColumns.Add(column5);
                
                boards.Add(board);
                count += 5;
            }

            return (moves, boards);
        }
    }

    public class Square
    {
        public int Value { get; set; }
        public bool Called { get; set; }
    }

    public class Board
    {
        public List<RowColumn> RowColumns { get; set; } = new List<RowColumn>();
        public bool Won { get; set; }

        public string GetValues()
        {
            var result = "";
            foreach (var rowColumn in RowColumns)
            {
                foreach (var square in rowColumn.Squares)
                {
                    result += square.Value;
                }
            }

            return result;
        }
    }

    public class RowColumn
    {
        public List<Square> Squares { get; set; } = new List<Square>();
    }
}