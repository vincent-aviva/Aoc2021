using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020
{
    public class Day03 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => true;

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
            var oxygenGeneratorItems = input;
            var co2ScrubberItems = input;

            var rowCount = input.Count;
            var charCount = input.First().Length;
            for (var i = 0; i < charCount; i++)
            {
                if(oxygenGeneratorItems.Count > 1)
                {
                    var sum = oxygenGeneratorItems.Select(x => Convert.ToInt16(x.Substring(i, 1))).Sum(x => x);
                    var character = sum >= oxygenGeneratorItems.Count / 2.0 ? 1 : 0;
                    oxygenGeneratorItems = oxygenGeneratorItems.Where(x => x.Substring(i, 1) == character.ToString()).ToList();
                }
                if (co2ScrubberItems.Count > 1)
                {
                    var sum = co2ScrubberItems.Select(x => Convert.ToInt16(x.Substring(i, 1))).Sum(x => x);
                    var character = sum >= co2ScrubberItems.Count / 2.0 ? 0 : 1;
                    co2ScrubberItems = co2ScrubberItems.Where(x => x.Substring(i, 1) == character.ToString()).ToList();
                }
            }

            var oxygenGenerator = Convert.ToInt32(oxygenGeneratorItems.First(), 2);
            var co2Scrubber = Convert.ToInt32(co2ScrubberItems.First(), 2);
            return oxygenGenerator * co2Scrubber;
        }
    }
}
