using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020
{
    public class Day04 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => true;

        private IEnumerable<int> bingoNumbers;
        private List<BingoBoard> boards;

        public long Solve1(IList<string> input)
        {
            Create(input);

            foreach(var bingoNumber in bingoNumbers)
            {
                foreach(var board in boards)
                {
                    board.CallNumber(bingoNumber);
                    if(board.HasBingo())
                    {
                        var sum = board.HorizontalRows.Select(row => row.Where(number => !number.Selected).Sum(number => number.Number)).Sum();
                        return sum * bingoNumber;
                    }
                }
            }

            return 0;
        }

        public long Solve2(IList<string> input)
        {
            Create(input);

            foreach (var bingoNumber in bingoNumbers)
            {
                foreach (var board in boards)
                {
                    board.CallNumber(bingoNumber);
                    if (board.HasBingo() && boards.Where(x => x.BoardId != board.BoardId).All(x => x.HasBingo()))
                    {
                        var sum = board.HorizontalRows.Select(row => row.Where(number => !number.Selected).Sum(number => number.Number)).Sum();
                        return sum * bingoNumber;
                    }
                }
            }

            return 0;
        }

        private void Create(IList<string> input)
        {
            bingoNumbers = input.First().Split(',').Select(x => Convert.ToInt32(x));

            var rowCursor = 2;
            boards = new List<BingoBoard>();
            while (rowCursor < input.Count)
            {
                boards.Add(new BingoBoard(((rowCursor - 2) / 6), input.Skip(rowCursor).Take(5).ToList()));
                rowCursor += 6;
            }
        }
    }

    public class BingoBoard
    {
        public BingoBoard(int boardId, IList<string> boardRows)
        {
            BoardId = boardId;

            var boardNumbers = boardRows.Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => new BingoNumber(x)).ToList()).ToList();

            HorizontalRows = boardNumbers;
            for(int i=0; i<boardNumbers.Count; i++)
            {
                VerticalRows.Add(boardNumbers.SelectMany(x => x.Skip(i).Take(1)).ToList());
            }
        }

        public int BoardId { get; set; }
        public List<List<BingoNumber>> HorizontalRows { get; private set; }
        public List<List<BingoNumber>> VerticalRows { get; private set; } = new List<List<BingoNumber>>();

        public void CallNumber(int calledNumber)
        {
            foreach(var row in HorizontalRows)
            {
                foreach(var number in row)
                {
                    if(number.Number == calledNumber)
                    {
                        number.Selected = true;
                    }
                }
            }
            foreach (var row in VerticalRows)
            {
                foreach (var number in row)
                {
                    if (number.Number == calledNumber)
                    {
                        number.Selected = true;
                    }
                }
            }
        }

        public bool HasBingo()
        {
            if(HorizontalRows.Any(row => row.All(number => number.Selected)) || VerticalRows.Any(row => row.All(number => number.Selected)))
            {
                return true;
            }

            return false;
        }
    }

    public class BingoNumber
    {
        public BingoNumber(string number)
        {
            Number = Convert.ToInt32(number);
        }

        public int Number { get; }
        public bool Selected { get; set; }

    }
}
