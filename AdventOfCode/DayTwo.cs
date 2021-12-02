namespace AdventOfCode
{
    public static class DayTwo
    {
        public static int PartOne(string[] input)
        {
            var horizontal = 0;
            var vertical = 0;
            foreach (var movement in input)
            {
                var movementParts = movement.Split(' ');
                switch (movementParts[0])
                {
                    case "forward":
                        horizontal += int.Parse(movementParts[1]);
                        break;
                    case "down":
                        vertical += int.Parse(movementParts[1]);
                        break;
                    case "up":
                        vertical -= int.Parse(movementParts[1]);
                        break;
                }
            }
            return horizontal * vertical;
        }
        
        public static int PartTwo(string[] input)
        {
            var horizontal = 0;
            var vertical = 0;
            var aim = 0;
            foreach (var movement in input)
            {
                var movementParts = movement.Split(' ');
                switch (movementParts[0])
                {
                    case "forward":
                        horizontal += int.Parse(movementParts[1]);
                        vertical += aim * int.Parse(movementParts[1]);
                        break;
                    case "down":
                        aim += int.Parse(movementParts[1]);
                        break;
                    case "up":
                        aim -= int.Parse(movementParts[1]);
                        break;
                }
            }
            return horizontal * vertical;
        }
    }
}