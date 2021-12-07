using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020
{
    public class Day06 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => true;

        public long Solve1(IList<string> input)
        {
            return Calculate(input.First(), 80);
        }

        public long Solve2(IList<string> input)
        {
            return Calculate(input.First(), 256);
        }

        private long Calculate(string input, int daysToCalculate)
        {
            var startFishes = input.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x));
            long day0Count = startFishes.Count(x => x == 0);
            long day1Count = startFishes.Count(x => x == 1);
            long day2Count = startFishes.Count(x => x == 2);
            long day3Count = startFishes.Count(x => x == 3);
            long day4Count = startFishes.Count(x => x == 4);
            long day5Count = startFishes.Count(x => x == 5);
            long day6Count = startFishes.Count(x => x == 6);
            long day7Count = startFishes.Count(x => x == 7);
            long day8Count = startFishes.Count(x => x == 8);

            for (var dayCount = 0; dayCount < daysToCalculate; dayCount++)
            {
                long newFishes = day0Count;
                day0Count = day1Count;
                day1Count = day2Count;
                day2Count = day3Count;
                day3Count = day4Count;
                day4Count = day5Count;
                day5Count = day6Count;
                day6Count = day7Count + newFishes;
                day7Count = day8Count;
                day8Count = newFishes;
            }

            return day0Count + day1Count + day2Count + day3Count + day4Count + day5Count + day6Count + day7Count + day8Count;
        }
    }
}
