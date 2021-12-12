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

        private long WalkaboutWaysCount()
        {
            var paths = new Collection<string>();

            GoThroughLonger("start", "start-", paths, null, false);

            return paths.Distinct().Count();
        }

        private void GoThroughLonger(string start, string currentPath, ICollection<string> paths, string doubleCave, bool alreadyDouble)
        {
            foreach (var cave in GetCaves(start))
            {
                var count = Regex.Match(currentPath, $"-{cave}-").Captures.Count;
                var doubleSpecified = doubleCave != null && doubleCave == cave;
                var couldBeDouble = char.IsLower(cave[0]) && !alreadyDouble && count == 1;

                if (cave == "start") continue;
                //if (currentPath.Contains($"{start}-{cave}") && !couldBeDouble) continue;
                if (char.IsLower(cave[0]))
                {
                    if (alreadyDouble && count == 1) 
                        continue;
                    if (doubleSpecified && count == 2) 
                        continue;
                    //if(!doubleSpecified && !couldBeDouble) 
                    //    continue;
                }

                if (cave == "end")
                {
                    paths.Add($"{currentPath}{cave}");
                }
                else
                {
                    GoThroughLonger(
                        cave,
                        $"{currentPath}{cave}-", paths,
                        couldBeDouble || doubleSpecified ? cave : null,
                        couldBeDouble || alreadyDouble);

                }
            }
        }

        private void GoThroughDirectly(string start, string currentPath, ICollection<string> paths)
        {
            foreach (var cave in GetCaves(start))
            {
                if (cave == "start") continue;
                if (currentPath.Contains($"{start}-{cave}")) continue;
                if (char.IsLower(cave[0]) && currentPath.Contains($"-{cave}-")) continue;

                if (cave == "end")
                {
                    paths.Add($"{currentPath}{cave}");
                }
                else
                {
                    GoThroughDirectly(cave, $"{currentPath}{cave}-", paths);
                }
            }
        }

        private IEnumerable<string> GetCaves(string from)
        {
            var a = _pairs.Where(x => x[0] == from).Select(x => x[1]);
            var b = _pairs.Where(x => x[1] == from).Select(x => x[0]);
            var targets = a.Union(b).Distinct().ToArray();
            return targets;
        }
    }
}