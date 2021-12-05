using System.Collections.Generic;
using System.Linq;

namespace Business.Day1
{
    public class Sonar
    {
        private readonly SonarData _sonarData;

        public Sonar(SonarData sonarData)
        {
            _sonarData = sonarData;
        }

        public int GetIncreasesCount()
        {
            var measurements = _sonarData.GetMeasurements();

            return GetIncreaseCountCommon(measurements);
        }

        public int GetIncreasesWithNoiseCount()
        {
            var measurements = _sonarData.GetMeasurements();
            var windows = GetWindows(measurements);

            return GetIncreaseCountCommon(windows.Select(x => x.sum).ToArray());
        }

        internal static int GetIncreaseCountCommon(IReadOnlyList<int> measurements)
        {
            var increasesCount = 0;

            for (var i = 0; i < measurements.Count; i++)
            {
                if (i == 0) continue;

                if (measurements[i] > measurements[i - 1]) increasesCount++;
            }

            return increasesCount;
        }

        private static IEnumerable<(int grp, int sum)> GetWindows(IReadOnlyList<int> measurements)
        {
            var groupIds = new List<int>();
            var windows = new List<(int grp, int depth)>();

            for (var i = 0; i < measurements.Count; i++)
            {
                groupIds.Add(i);
                windows.AddRange(groupIds.TakeLast(3).Select(groupId => (groupId, measurements[i])));
            }

            return windows
                .GroupBy(x => x.grp)
                .Select(x => (x.Key, x.Sum(m => m.depth)))
                .ToList();
        }

    }
}
