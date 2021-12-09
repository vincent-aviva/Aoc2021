using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Aoc2020
{
    public class Day09 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => false;
        public bool IsPart2Complete => false;

        private List<BasinPoint> BasinPoints;

        public long Solve1(IList<string> input)
        {
            BasinPoints = new List<BasinPoint>();
            for (var y = 0; y < input.Count; y++)
            {
                var line = input[y].ToCharArray();
                for (var x = 0; x < line.Length; x++)
                {
                    BasinPoints.Add(new BasinPoint
                    {
                        Point = new Point(x, y),
                        Number = Convert.ToInt32(line[x].ToString()),
                        IsLowPoint = false
                    });
                }
            }

            foreach (var basinPoint in BasinPoints)
            {
                basinPoint.IsLowPoint =
                    basinPoint.Number < GetBasinPointNumber(basinPoint.Point.X - 1, basinPoint.Point.Y) &&
                    basinPoint.Number < GetBasinPointNumber(basinPoint.Point.X + 1, basinPoint.Point.Y) &&
                    basinPoint.Number < GetBasinPointNumber(basinPoint.Point.X, basinPoint.Point.Y - 1) &&
                    basinPoint.Number < GetBasinPointNumber(basinPoint.Point.X, basinPoint.Point.Y + 1);
            }

            var lowPoints = BasinPoints.Where(x => x.IsLowPoint).ToList();
            return lowPoints.Sum(x => x.Number) + lowPoints.Count;
        }

        public long Solve2(IList<string> input)
        {
            throw new NotImplementedException();
        }

        private int GetBasinPointNumber(int x, int y)
        {
            var searchedPoint = BasinPoints.FirstOrDefault(basinPoint => basinPoint.Point.X == x && basinPoint.Point.Y == y);
            return searchedPoint?.Number ?? 99;
        }
    }

    public class BasinPoint
    {
        public Point Point { get; set; }
        public int Number { get; set; }
        public bool IsLowPoint{ get; set; }
    }
}
