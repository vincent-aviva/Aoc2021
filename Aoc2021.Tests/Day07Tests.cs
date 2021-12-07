using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Aoc2020.Tests
{
    public class Day07Tests
    {
        private readonly IDay _day;
        private readonly List<string> _input;

        public Day07Tests()
        {
            _input = new List<string>
            {
                "16,1,2,0,4,2,7,1,2,14"
            };
            _day = new Day07();
        }

        [Fact]
        public void Part1()
        {
            _day.Solve1(_input).Should().Be(37);
        }

        [Fact]
        public void Part2()
        {
            _day.Solve2(_input).Should().Be(168);
        }
    }
}
