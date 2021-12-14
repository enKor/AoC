using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Day9
{
    public class SmokeBasinService : IService
    {
        private readonly MapData _data;

        public SmokeBasinService(MapData data)
        {
            _data = data;
        }

        public object RunTask1() => GetLows();

        public object RunTask2() => GetBasins();

        private long GetLows()
        {
            var arr = _data.GetMap();
            var lowests = new List<int>();

            for (int y = 0; y < arr.Length; y++)
            {
                for (int x = 0; x < arr[y].Length; x++)
                {
                    if (IsLowestAround(arr, x, y))
                    {
                        lowests.Add(arr[y][x]);
                    }
                }
            }

            var danger = lowests.Sum(x => x) + lowests.Count;

            return danger;
        }

        private long GetBasins()
        {
            var arr = _data.GetMap();
            var basins = new List<int>();

            for (int y = 0; y < arr.Length; y++)
            {
                for (int x = 0; x < arr[y].Length; x++)
                {
                    Console.WriteLine($"-------{x},{y}:");
                    if (IsLowestAround(arr, x, y))
                    {
                        Console.WriteLine($"Floor ({x},{y}) {arr[y][x]}");
                        var size = GetBasinSize(arr, x, y);
                        basins.Add(size);
                        
                        //DrawOne(arr, x, y);

                        Map.Add(((x, y), true));
                    }
                }
            }

            DrawAll(arr);

            return basins
                .OrderByDescending(o => o)
                .Take(3)
                .Aggregate(1, (a, n) => a * n);
        }

        private static readonly List<((int x, int y), bool start)> Map = new();



        private static void DrawAll(int[][] arr)
        {
            var defaultColor = Console.ForegroundColor;

            for (var _y = 0; _y < arr.Length; _y++)
            {
                for (var _x = 0; _x < arr[_y].Length; _x++)
                {
                    var p = Map.SingleOrDefault(a => a.Item1.x == _x && a.Item1.y == _y);
                    if (p != default && p.start)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(arr[_y][_x]);
                        Console.ForegroundColor = defaultColor;
                    }
                    else if (p != default)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(arr[_y][_x]);
                        Console.ForegroundColor = defaultColor;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(arr[_y][_x]);
                        Console.ForegroundColor = defaultColor;
                    }
                }

                Console.Write("\r\n");
            }
        }

        private static void DrawOne(int[][] arr, int x, int y)
        {
            var basin = new List<(int x, int y)> { (x, y) };
            FindBasinPoints(arr, x, y, basin);

            var defaultColor = Console.ForegroundColor;

            for (var _y = 0; _y < arr.Length; _y++)
            {
                for (var _x = 0; _x < arr[_y].Length; _x++)
                {
                    if (_x == x && y == _y)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(arr[_y][_x]);
                        Console.ForegroundColor = defaultColor;
                    }
                    else if (basin.Contains((_x, _y)))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(arr[_y][_x]);
                        Console.ForegroundColor = defaultColor;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(arr[_y][_x]);
                        Console.ForegroundColor = defaultColor;
                    }
                }

                Console.Write("\r\n");
            }
        }

        private static int GetBasinSize(int[][] arr, int x, int y)
        {
            var basin = new List<(int x, int y)> { (x, y) };

            FindBasinPoints(arr, x, y, basin);

            return basin.Count;
        }

        private static bool Comparison(int current, int last) =>
            current > last && current != 9;

        private static void FindBasinPoints(int[][] arr, int x, int y, List<(int x, int y)> basin)
        {
            Console.WriteLine($"({x},{y}) {arr[y][x]}");

            try
            {
                var lastValue = arr[y][x];
                //x--
                var ix = x - 1;
                while (Comparison(arr[y][ix],lastValue))
                {
                    if (ProcessPoint(arr, ix, y, ref lastValue, basin)) break;

                    ix--;
                }
            }
            catch { }

            try
            {
                var lastValue = arr[y][x];
                //x++
                var ix = x + 1;
                while (Comparison(arr[y][ix], lastValue))
                {
                    if (ProcessPoint(arr, ix, y, ref lastValue, basin)) break;

                    ix++;
                }
            }
            catch { }

            try
            {
                var lastValue = arr[y][x];
                //y++
                var iy = y + 1;
                while (Comparison(arr[iy][x], lastValue))
                {
                    if (ProcessPoint(arr, x, iy, ref lastValue, basin)) break;

                    iy++;
                }
            }
            catch { }

            try
            {
                var lastValue = arr[y][x];
                //y
                var iy = y - 1;
                while (Comparison(arr[iy][x], lastValue))
                {
                    if (ProcessPoint(arr, x, iy, ref lastValue, basin)) break;

                    iy--;
                }
            }
            catch { }
        }

        private static bool ProcessPoint(int[][] arr, int x, int y, ref int lastValue, List<(int x, int y)> basin)
        {
            if (!basin.Contains((x, y)))
            {
                Map.Add(((x, y), false));


                basin.Add((x, y));
                lastValue = arr[y][x];
                FindBasinPoints(arr, x, y, basin);
            }
            else
            {
                return true;
            }

            return false;
        }


        private static bool IsLowestAround(int[][] arr, int x, int y)
        {
            var middle = arr[y][x];
            if (IsHigher(middle, arr, x - 1, y)) return false;
            if (IsHigher(middle, arr, x + 1, y)) return false;
            if (IsHigher(middle, arr, x, y - 1)) return false;
            if (IsHigher(middle, arr, x, y + 1)) return false;
            return true;
        }

        private static bool IsHigher(int point, int[][] arr, int x, int y)
        {
            try
            {
                var p = arr[y][x];
                return point >= p;
            }
            catch (IndexOutOfRangeException e)
            {
                return false;
            }
        }
    }
}