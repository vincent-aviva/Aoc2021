using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020
{
    public class Day08 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => false;

        public long Solve1(IList<string> input)
        {
            var inputLines = input.Select(x => new InputLine(x));
            return inputLines.Select(x => x.OutputValue.Count(y => y.Length == 2 || y.Length == 3 || y.Length == 4 || y.Length == 7)).Sum();
        }

        public long Solve2(IList<string> input)
        {
            //throw new NotImplementedException();
            return 0;
        }
    }

    public class InputLine
    {
        public List<string> SignalPatters { get; set; }
        public List<string> OutputValue { get; set; }

        public InputLine(string input)
        {
            var splitted = input.Split(" | ");
            SignalPatters = splitted[0].Split(' ').ToList();
            OutputValue = splitted[1].Split(' ').ToList();
        }
    }
}
