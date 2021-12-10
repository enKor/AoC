using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Day10
{
    public class SyntaxScoringService : IService
    {
        private readonly ChunkData _data;
        private static readonly char[] Starting = {'(', '<', '{', '['};
        private static readonly char[] Ending = { ')', '>', '}', ']' };

        public SyntaxScoringService(ChunkData data)
        {
            _data = data;
        }

        public object RunTask1() => Count();

        public object RunTask2() => Count2();

        private long Count()
        {
            var illegals = Analyse().Illegal; 
            var points = new[] {3, 25137, 1197, 57};

            var result = illegals
                .Select(x => points[Array.IndexOf(Ending, x)])
                .Aggregate(0, (a, n) => a += n);

            return result;
        }

        private long Count2()
        {
            var incompleteList = Analyse().Incomplete;
            var points = new[] { 1, 4, 3, 2 };

            return incompleteList
                .Select(o => o
                    .Select(x => points[Array.IndexOf(Starting, x)])
                    .Aggregate(0L, (a, n) => a * 5L + n)
                )
                .OrderBy(x => x)
                .ToArray()
                [(int)Math.Floor(incompleteList.Count / 2m)];
        }

        private (List<char> Illegal, List<List<char>> Incomplete) Analyse()
        {
            var data = _data.GetRows();

            var illegals = new List<char>();
            var incompleteList = new List<List<char>>();

            foreach (var row in data)
            {
                var opened = new List<char>();
                var corrupted = false;

                foreach (var ch in row)
                {
                    if (Starting.Contains(ch))
                    {
                        opened.Add(ch);
                    }
                    else
                    {
                        var idx = Array.IndexOf(Ending, ch);
                        if (opened.Last() == Starting[idx])
                        {
                            // closing pair
                            opened.RemoveAt(opened.Count - 1);
                        }
                        else
                        {
                            // illegal end
                            illegals.Add(ch);
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

            return (illegals, incompleteList);
        }

    }
}