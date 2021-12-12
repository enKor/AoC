using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Business.Day12
{
    public class CavePathwayService : IService
    {
        private readonly CaveData _caveData;

        public CavePathwayService(CaveData caveData)
        {
            _caveData = caveData;
            _pairs = _caveData.GetPairs();

        }

        private readonly string[][] _pairs;

        public object RunTask1() => DirectWaysCount();

        public object RunTask2() => WalkaboutWaysCount();

        private long DirectWaysCount()
        {
            var paths = new Collection<string>();

            GoThroughDirectly("start", "start-", paths);

            return paths.Count;
        }

        // TODO
        private long WalkaboutWaysCount()
        {
            var paths = new Collection<string>();

            GoThroughLonger("start", "start-", paths, false);
            GoThroughLonger("start", "start-", paths, true);

            return paths.Count;
        }

        //TODO
        private void GoThroughLonger(string start, string currentPath, ICollection<string> paths, bool tryDoubled)
        {
            foreach (var target in GetTargets(start))
            {
                if (target == "start") continue;
                if (tryDoubled)
                {
                    if (currentPath.Contains($"{start}-{target}")) continue;
                    if (char.IsLower(target[0]) && Regex.Matches(currentPath, $"-{target}-").Count < 2) continue;
                }
                else
                {
                    if (currentPath.Contains($"{start}-{target}")) continue;
                    if (char.IsLower(target[0]) && Regex.Matches(currentPath, $"-{target}-").Count < 2) continue;
                }

                if (target == "end")
                {
                    paths.Add($"{currentPath}{target}");
                }
                else
                {
                    GoThroughLonger(target, $"{currentPath}{target}-", paths, true);
                    GoThroughLonger(target, $"{currentPath}{target}-", paths, false);
                }
            }
        }

        private void GoThroughDirectly(string start, string currentPath, ICollection<string> paths)
        {
            foreach (var target in GetTargets(start))
            {
                if (target == "start") continue;
                if (currentPath.Contains($"{start}-{target}")) continue;
                if (char.IsLower(target[0]) && currentPath.Contains($"-{target}-")) continue;

                if (target == "end")
                {
                    paths.Add($"{currentPath}{target}");
                }
                else
                {
                    GoThroughDirectly(target, $"{currentPath}{target}-", paths);
                }
            }
        }

        private IEnumerable<string> GetTargets(string from)
        {
            var a = _pairs.Where(x => x[0] == from).Select(x => x[1]);
            var b = _pairs.Where(x => x[1] == from).Select(x => x[0]);
            var targets = a.Union(b).Distinct().ToArray();
            return targets;
        }
    }
}