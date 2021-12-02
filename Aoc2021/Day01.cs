using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020
{
    public class Day01 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => true;

        public long Solve1(IList<string> input)
        {
            var numbers = input.Select(x => Convert.ToInt32(x)).ToList();
            var count = numbers.Skip(1).Where((number, index) => number > numbers[index]).Count();
            return count;
        }

        public long Solve2(IList<string> input)
        {
            var numbers = input.Select(x => Convert.ToInt32(x)).ToList();
            var windows = numbers.Skip(2).Select((number, index) => number + numbers[index] + numbers[index + 1]).ToList();
            var count = windows.Skip(1).Where((number, index) => number > windows[index]).Count();
            return count;
        }
    }
}
