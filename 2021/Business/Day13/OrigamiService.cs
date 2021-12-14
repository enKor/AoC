using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Business.Day13
{
    public class OrigamiService : IService
    {
        private readonly PaperData _paperData;

        public OrigamiService(PaperData paperData)
        {
            _paperData = paperData;

        }

        public object RunTask1() => PointsCount();

        public object RunTask2() => -1;

        private long PointsCount()
        {
            var folds = _paperData.GetFolds();
            var points = _paperData.GetPoints().ToImmutableArray();

            var maxX = points.Select(v => v.X).Max();
            var maxY = points.Select(v => v.Y).Max();

            var arr = new bool[maxY + 1, maxX + 1];

            //Draw(arr);

            foreach (var p in points)
            {
                arr[p.Y, p.X] = true;
            }

            foreach (var f in folds)
            {
                //Draw(arr);

                arr = Fold(f, arr);

                //Draw(arr);
            }
            Draw(arr);
            var marked = arr.Cast<bool>().Where(x => x);

            return marked.Count();
        }

        private static bool[,] FoldByX(int p, bool[,] arr)
        {
            var maxIdxY = arr.GetUpperBound(0);
            var maxIdxX = arr.GetUpperBound(1);

            var a = new bool[maxIdxY + 1, p];

            for (int y = 0; y <= a.GetUpperBound(0); y++)
            {
                for (int x = 0; x <= a.GetUpperBound(1); x++)
                {
                    a[y, x] = arr[y, x] || arr[y, maxIdxX - x];
                }
            }
            return a;
        }


        private static bool[,] FoldByY(int p, bool[,] arr)
        {
            var maxIdxY = arr.GetUpperBound(0);
            var maxIdxX = arr.GetUpperBound(1);

            var a = new bool[p, maxIdxX + 1];

            for (int y = 0; y <= a.GetUpperBound(0); y++)
            {
                for (int x = 0; x <= a.GetUpperBound(1); x++)
                {
                    a[y, x] = arr[y, x] || arr[maxIdxY - y, x];
                }
            }
            return a;
        }

        private static bool[,] Fold(Vector2 f, bool[,] arr) =>
            f.X == 0 ? FoldByY(f.Y, arr) : FoldByX(f.X, arr);


        private static void Draw(bool[,] arr)
        {
            //return;
            for (int x = 0; x < arr.GetUpperBound(0) + 1; x++)
            {
                for (int y = 0; y < arr.GetUpperBound(1) + 1; y++)
                {
                    Console.Write(Format(arr[x, y]));
                }
                Console.Write("\r\n");
            }
            Console.Write("\r\n--------------\r\n\r\n");
        }

        private static string Format(bool b) => b ? "#" : ".";
    }
}