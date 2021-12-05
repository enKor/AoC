using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Day5
{
    public class Service : IService
    {
        private readonly FloorData _data;

        public Service(FloorData data)
        {
            _data = data;
        }

        public object RunTask1() => StrongVentsBasicCount();

        public object RunTask2() => StrongVentsDiagonalCount();

        private int StrongVentsBasicCount()
        {
            var activeVents = new List<Vector2>();

            foreach (var (a, b) in _data.GetVents())
            {
                if (a.X == b.X)
                {
                    // refactor this to Range Add with Enumerable generator
                    for (int y = a.Y; Compare(a.Y, b.Y, y); IterationFormula(a.Y, b.Y, ref y))
                    {
                        activeVents.Add(new Vector2(a.X, y));
                    }
                }
                else if (a.Y == b.Y)
                {
                    // refactor this to Range Add with Enumerable generator
                    for (int x = a.X; Compare(a.X, b.X, x); IterationFormula(a.X, b.X, ref x))
                    {
                        activeVents.Add(new Vector2(x, a.Y));
                    }
                }
            }

            return CountDangerous(activeVents);
        }

        // TODO refactor this 
        private int StrongVentsDiagonalCount()
        {
            var activeVents = new List<Vector2>();

            foreach (var (a, b) in _data.GetVents())
            {
                if (a.X == b.X)
                {
                    // TODO refactor this to Range Add with Enumerable generator
                    for (int y = a.Y; Compare(a.Y, b.Y, y); IterationFormula(a.Y, b.Y, ref y))
                    {
                        activeVents.Add(new Vector2(a.X, y));
                    }
                }
                else if (a.Y == b.Y)
                {
                    for (int x = a.X; Compare(a.X, b.X, x); IterationFormula(a.X, b.X, ref x))
                    {
                        activeVents.Add(new Vector2(x, a.Y));
                    }
                }
                else if(IsDiagonal(a,b))
                {
                    for (int x = a.X, y = a.Y;
                        Compare(a.X, b.X, x) && Compare(a.Y, b.Y, y);
                        IterationFormula(a.X, b.X, ref x), IterationFormula(a.Y, b.Y, ref y))
                    {
                        activeVents.Add(new Vector2(x, y));
                    }
                }
            }

            return CountDangerous(activeVents);

        }

        private static bool IsDiagonal(Vector2 a, Vector2 b) => Math.Abs(a.X - b.X) == Math.Abs(a.Y - b.Y);
        private static bool Compare(int a, int b, int n) => a < b ? n <= b : n >= b;
        private static int IterationFormula(int a, int b, ref int i) => a < b ? i++ : i--;

        private static int CountDangerous(IEnumerable<Vector2> activeVents)
        {
            return activeVents
                .GroupBy(x => x)
                .Select(x => (x.Key, x.Count()))
                .Count(x => x.Item2 > 1);
        }
    }
}
