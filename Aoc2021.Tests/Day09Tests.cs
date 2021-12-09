using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Aoc2020.Tests
{
    public class Day09Tests
    {
        private readonly IDay _day;
        private readonly List<string> _input;

        public Day09Tests()
        {
            _input = new List<string>
            {
                "2199943210",
                "3987894921",
                "9856789892",
                "8767896789",
                "9899965678"
            };
            _day = new Day09();
        }

        [Fact]
        public void Part1()
        {
            _day.Solve1(_input).Should().Be(15);
        }

        [Fact]
        public void Part2()
        {
            _day.Solve2(_input).Should().Be(168);
        }
    }
}
