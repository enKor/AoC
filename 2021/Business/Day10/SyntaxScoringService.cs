using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Day10
{
    public class SyntaxScoringService : IService
    {
        private readonly ChunkData _data;

        public SyntaxScoringService(ChunkData data)
        {
            _data = data;
        }

        public object RunTask1() => Count();

        public object RunTask2() => Count2();

        private long Count()
        {
            var data = _data.GetRows();

            var starting = new[] {'(', '<', '{', '['};
            var ending = new[] {')', '>', '}', ']'};
            var points = new[] {3, 25137, 1197, 57};

            var illegals = new List<char>();

            foreach (var row in data)
            {
                var opened = new List<char>();
                foreach (var ch in row)
                {
                    if (starting.Contains(ch))
                    {
                        opened.Add(ch);
                    }
                    else
                    {
                        var idx = Array.IndexOf(ending, ch);
                        if (opened.Last() == starting[idx])
                        {
                            // closing pair
                            opened.RemoveAt(opened.Count - 1);
                        }
                        else
                        {
                            // illegal end
                            illegals.Add(ch);
                            break;
                        }
                    }
                }
            }

            var result = illegals
                .Select(x => points[Array.IndexOf(ending, x)])
                .Aggregate(0, (a, n) => a += n);

            return result;
        }

        private long Count2()
        {
            var data = _data.GetRows();

            var starting = new[] {'(', '<', '{', '['};
            var ending = new[] {')', '>', '}', ']'};
            var points = new[] {1, 4, 3, 2};

            var incompleteList = new List<List<char>>();

            foreach (var row in data)
            {
                var opened = new List<char>();
                var corrupted = false;
                foreach (var ch in row)
                {
                    if (starting.Contains(ch))
                    {
                        opened.Add(ch);
                    }
                    else
                    {
                        var idx = Array.IndexOf(ending, ch);
                        if (opened.Last() == starting[idx])
                        {
                            // closing pair
                            opened.RemoveAt(opened.Count - 1);
                        }
                        else
                        {
                            // illegal end
                            corrupted = true;
                            break;
                        }
                    }
                }

                if (!corrupted && opened.Any())
                {
                    opened.Reverse();
                    incompleteList.Add(opened);
                }
            }

            return incompleteList
                .Select(o => o
                    .Select(x => points[Array.IndexOf(starting, x)])
                    .Aggregate(0L, (a, n) => a * 5L + n)
                )
                .OrderBy(x => x)
                .ToArray()
                [(int) Math.Floor(incompleteList.Count / 2m)];
        }
    }
}