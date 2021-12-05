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

        public object RunTask1() => StrongVentsCount(false);

        public object RunTask2() => StrongVentsCount(true);

        private int StrongVentsCount(bool includeDiagonals)
        {
            var activeVents = new List<Vector2>();

            foreach (var (a, b) in _data.GetVents())
            {
                if(a.X == b.X 
                   || a.Y == b.Y 
                   || (includeDiagonals && IsDiagonal(a, b)))
                {
                    for (int x = a.X, y = a.Y;
                        Compare(a.X, b.X, x) && Compare(a.Y, b.Y, y);
                        Iterate(a.X, b.X, ref x), Iterate(a.Y, b.Y, ref y))
                    {
                        activeVents.Add(new Vector2(x, y));
                    }
                }
            }

            return CountDangerous(activeVents);
        }

        /// <summary>
        /// Checks if points are positioned in 45°
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        internal static bool IsDiagonal(Vector2 a, Vector2 b) => Math.Abs(a.X - b.X) == Math.Abs(a.Y - b.Y);
        
        private static bool Compare(int a, int b, int n) => a < b ? n <= b : n >= b;
        
        private static int Iterate(int a, int b, ref int i) =>
            a == b
                ? i
                : a < b
                    ? i++
                    : i--;

        private static int CountDangerous(IEnumerable<Vector2> activeVents)
        {
            return activeVents
                .GroupBy(x => x)
                .Select(x => (x.Key, x.Count()))
                .Count(x => x.Item2 > 1);
        }
    }
}
