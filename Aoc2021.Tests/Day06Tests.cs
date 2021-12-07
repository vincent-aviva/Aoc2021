using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Aoc2020.Tests
{
    public class Day06Tests
    {
        private readonly IDay _day;
        private readonly List<string> _input;

        public Day06Tests()
        {
            _input = new List<string>
            {
                "3,4,3,1,2"
            };
            _day = new Day06();
        }

        [Fact]
        public void Part1()
        {
            _day.Solve1(_input).Should().Be(5934);
        }

        [Fact]
        public void Part2()
        {
            _day.Solve2(_input).Should().Be(26984457539);
        }
    }
}
