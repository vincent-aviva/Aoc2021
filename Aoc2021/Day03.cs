using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020
{
    public class Day03 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => false;

        public long Solve1(IList<string> input)
        {
            var gammaArray = "";
            var epsilonArray = "";
            var rowCount = input.Count;
            var charCount = input.First().Length;

            for(var i = 0; i < charCount; i++)
            {
                var sum = input.Select(x => Convert.ToInt16(x.Substring(i, 1))).Sum(x => x);
                if(sum > rowCount/2)
                {
                    gammaArray += "1";
                    epsilonArray += "0";
                }
                else
                {
                    gammaArray += "0";
                    epsilonArray += "1";
                }
            }

            var gamma = Convert.ToInt32(gammaArray, 2);
            var epsilon = Convert.ToInt32(epsilonArray, 2);

            return gamma * epsilon;
        }

        public long Solve2(IList<string> input)
        {
            throw new NotImplementedException();
        }
    }
}
