using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Aoc2020
{
    public class Day05 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => true;

        private Dictionary<Point, int> touchedPoints;

        public long Solve1(IList<string> input)
        {
            var ventLines = input.Select(x => new VentLine(x));
            var currentVentLines = ventLines.Where(x => x.StartX == x.StopX || x.StartY == x.StopY).ToList();
            ProcessVentLines(currentVentLines);

            return touchedPoints.Count(x => x.Value > 1);
        }

        public long Solve2(IList<string> input)
        {
            var ventLines = input.Select(x => new VentLine(x));
            ProcessVentLines(ventLines);

            return touchedPoints.Count(x => x.Value > 1);
        }

        private void ProcessVentLines(IEnumerable<VentLine> ventLines)
        {
            touchedPoints = new Dictionary<Point, int>();
            foreach (var line in ventLines)
            {
                var moveY = 0;
                if (line.StartY < line.StopY) { moveY = +1; }
                if (line.StartY > line.StopY) { moveY = -1; }

                var moveX = 0;
                if (line.StartX < line.StopX) { moveX = +1; }
                if (line.StartX > line.StopX) { moveX = -1; }

                while (true)
                {
                    TouchPoint(line.StartX, line.StartY);

                    line.StartX += moveX;
                    line.StartY += moveY;

                    if (line.StartX == line.StopX && line.StartY == line.StopY)
                    {
                        TouchPoint(line.StartX, line.StartY); //Process last point as well.
                        break;
                    }
                }
            }
        }

        private void TouchPoint(int x, int y)
        {
            var currentPoint = new Point(x, y);
            if (touchedPoints.ContainsKey(currentPoint))
            {
                touchedPoints[currentPoint]++;
            }
            else
            {
                touchedPoints.Add(currentPoint, 1);
            }
        }
    }

    public class VentLine
    {
        public VentLine(string input)
        {
            var startStop = input.Split(" -> ");
            var splitStart = startStop[0].Split(',');
            var splitStop = startStop[1].Split(',');

            StartX = Convert.ToInt32(splitStart[0]);
            StartY = Convert.ToInt32(splitStart[1]);
            StopX = Convert.ToInt32(splitStop[0]);
            StopY = Convert.ToInt32(splitStop[1]);
        }

        public int StartX { get; set; }
        public int StartY { get; set; }

        public int StopX { get; set; }
        public int StopY { get; set; }
    }
}
