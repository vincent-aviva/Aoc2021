using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Aoc2020.Tests
{
    public class Day05Tests
    {
        private readonly IDay _day;
        private readonly List<string> _input;

        public Day05Tests()
        {
            _input = new List<string>
            {
                "0,9 -> 5,9",
                "8,0 -> 0,8",
                "9,4 -> 3,4",
                "2,2 -> 2,1",
                "7,0 -> 7,4",
                "6,4 -> 2,0",
                "0,9 -> 2,9",
                "3,4 -> 1,4",
                "0,0 -> 8,8",
                "5,5 -> 8,2"
            };
            _day = new Day05();
        }

        [Fact]
        public void Part1()
        {
            _day.Solve1(_input).Should().Be(5);
        }

        [Fact]
        public void Part2()
        {
            _day.Solve2(_input).Should().Be(12);
        }
    }
}
