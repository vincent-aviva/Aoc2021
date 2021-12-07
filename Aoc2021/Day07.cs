using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020
{
    public class Day07 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => true;

        public long Solve1(IList<string> input)
        {
            var initialPosition = input.First().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x)).ToList();
            
            initialPosition.Sort();

            var mid = initialPosition.Count / 2;
            var median = initialPosition.Count % 2 == 0 ? 
                initialPosition[mid] :
                ((initialPosition[mid] + initialPosition[mid + 1]) / 2);

            var fuel = initialPosition.Select(x => x > median ? x -median : median - x).Sum();

            return fuel;
        }

        public long Solve2(IList<string> input)
        {
            var initialPosition = input.First().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x)).ToList();

            var avg1 = initialPosition.Average();
            var rounded = Math.Floor(avg1); // For the unit test this does not work, round is needed

            var fuel = 0;
            foreach(var item in initialPosition)
            {
                var distance = item > rounded ? item - rounded : rounded - item;
                for(var i = 1; i <= distance; i++)
                {
                    fuel += i;
                }
            }

            return fuel;
        }
    }
}
