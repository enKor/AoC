using System.Collections.Generic;
using System.Linq;

namespace Day1
{
    internal class Sonar
    {
        public static int GetIncreasesCount()
        {
            var measurements = SonarData.GetMeasurements();

            return GetIncreaseCountCommon(measurements);
        }

        public static int GetIncreasesWithNoiseCount()
        {
            var measurements = SonarData.GetMeasurements();
            var windows = GetWindows(measurements);

            return GetIncreaseCountCommon(windows.Select(x => x.sum).ToArray());
        }

        private static int GetIncreaseCountCommon(int[] measurements)
        {
            var increasesCount = 0;

            for (var i = 0; i < measurements.Length; i++)
            {
                if (i == 0) continue;

                if (measurements[i] > measurements[i - 1]) increasesCount++;
            }

            return increasesCount;
        }

        private static List<(int grp, int sum)> GetWindows(int[] measurements)
        {
            var groups = new List<int>();
            var windows = new List<(int grp, int depth)>();

            for (var i = 0; i < measurements.Length; i++)
            {
                groups.Add(i);

                foreach (var group in groups.TakeLast(3))
                {
                    windows.Add((group, measurements[i]));
                }
            }

            return windows
                .GroupBy(x => x.grp)
                .Select(x => (x.Key, x.Sum(m => m.depth)))
                .ToList();
        }

    }
}
