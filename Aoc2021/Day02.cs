using System;
using System.Collections.Generic;

namespace Aoc2020
{
    public class Day02 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => true;

        public long Solve1(IList<string> input)
        {
            var position = 0;
            var depth = 0;

            foreach (var command in input)
            {
                var commandParts = command.Split(' ');
                var commandDirection = commandParts[0];
                var commandAmount = Convert.ToInt32(commandParts[1]);

                switch(commandDirection)
                {
                    case "forward":
                        position += commandAmount;
                        break;
                    case "up":
                        depth += -1 * commandAmount;
                        break;
                    case "down":
                        depth += commandAmount;
                        break;
                }
            }

            return position * depth;
        }

        public long Solve2(IList<string> input)
        {
            var position = 0;
            var depth = 0;
            var aim = 0;

            foreach (var command in input)
            {
                var commandParts = command.Split(' ');
                var commandDirection = commandParts[0];
                var commandAmount = Convert.ToInt32(commandParts[1]);

                switch (commandDirection)
                {
                    case "forward":
                        position += commandAmount;
                        depth += commandAmount * aim;
                        break;
                    case "up":
                        aim += -1 * commandAmount;
                        break;
                    case "down":
                        aim += commandAmount;
                        break;
                }
            }

            return position * depth;
        }
    }
}
