using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Aoc2020.Tests
{
    public class Day03Tests
    {
        private readonly IDay _day;
        private readonly List<string> _input;

        public Day03Tests()
        {
            _input = new List<string>
            {
                "00100",
                "11110",
                "10110",
                "10111",
                "10101",
                "01111",
                "00111",
                "11100",
                "10000",
                "11001",
                "00010",
                "01010"
            };

            _day = new Day03();
        }

        [Fact]
        public void Part1()
        {
            _day.Solve1(_input).Should().Be(198);
        }

        [Fact]
        public void Part2()
        {
            _day.Solve2(_input).Should().Be(230);
        }
    }
}
