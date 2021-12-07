using System.Linq;

namespace AdventOfCode
{
    public class DaySix
    {
        public static long Evaluate(string[] input, int days)
        {
            var timers = new long[9];
            foreach (var fish in input[0].Split(',').ToList().Select(int.Parse))
            {
                timers[fish]++;
            }

            for (var day = 0; day < days; day++)
            {
                var newTimers = new long[9];
                newTimers[6] = timers[0];
                newTimers[8] = timers[0];
                for (var i = 0; i < 8; i++)
                {
                    newTimers[i] += timers[i + 1];
                }

                timers = newTimers;
            }

            long count = 0;
            for (var i = 0; i < 9; i++)
            {
                count += timers[i];
            }

            return count;
        }
    }
}