using System;
using System.Linq;

namespace Business.Day11
{
    public class Service : IService
    {
        private readonly Data _data;

        public Service(Data data)
        {
            _data = data;
        }

        public object RunTask1() => CountFlashes(100);

        public object RunTask2() => GetStep();

        private long CountFlashes(int steps)
        {
            var octopuses = _data.GetMap();
            var flashed = 0L;

            for (int i = 1; i <= steps; i++)
            {
                flashed += RunStep(octopuses);
            }

            return flashed;
        }

        private long GetStep()
        {
            var octopuses = _data.GetMap();
            var totalCount = octopuses
                .Select(x => x.Length)
                .Sum();

            var i = 1;
            while (true)
            {
                if (RunStep(octopuses) == totalCount)
                    return i;

                i++;
            }
        }

        private static long RunStep(Octopus[][] octopuses)
        {
            Draw(octopuses);
            IncreaseAll(octopuses);
            Draw(octopuses); 
            Flash(octopuses);
            Draw(octopuses);
            return ResetFlashing(octopuses);
        }

        private static void Flash(Octopus[][] octopuses)
        {
            for (int y = 0; y < octopuses.Length; y++)
                for (int x = 0; x < octopuses[0].Length; x++)
                {
                    var octopus = octopuses[y][x];
                    if (octopus.Value > 9)
                    {
                        BoostAdjacent(octopuses, x, y);
                    }
                }
        }

        private static void BoostAdjacent(Octopus[][] octopuses, int x, int y)
        {
            if (octopuses[y][x].HasBoostedAdjacent) return;
            octopuses[y][x].HasBoostedAdjacent = true;

            var adjacent = new (int _x, int _y)[]
            {
                (x - 1, y - 1),
                (x, y - 1),
                (x + 1, y - 1),

                (x - 1, y),
                (x + 1, y),

                (x - 1, y + 1),
                (x, y + 1),
                (x + 1, y + 1)
            };

            foreach (var adj in adjacent)
            {
                try
                {
                    var octopus = octopuses[adj._y][adj._x];
                    octopus.IncreaseEnergy();
                    Draw(octopuses,true);
                    if (octopus.Value >9)
                    {
                        BoostAdjacent(octopuses, adj._x, adj._y);
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    // do nothing - octopus does not exist there
                }
            }
            Draw(octopuses);
        }

        private static int ResetFlashing(Octopus[][] octopuses)
        {
            var flashing = 0;
            for (int y = 0; y < octopuses.Length; y++)
                for (int x = 0; x < octopuses[0].Length; x++)
                {
                    var octopus = octopuses[y][x];
                    if (octopus.Value > 9)
                    {
                        flashing++;
                        octopus.Discharge();
                    }
                }

            return flashing;
        }

        private static void IncreaseAll(Octopus[][] octopuses)
        {
            for (int y = 0; y < octopuses.Length; y++)
                for (int x = 0; x < octopuses[0].Length; x++)
                {
                    octopuses[y][x].IncreaseEnergy();
                }
        }

        private static void Draw(Octopus[][] arr, bool isStep = false)
        {
            return;

            for (var _y = 0; _y < arr.Length; _y++)
            {
                for (var _x = 0; _x < arr[_y].Length; _x++)
                {
                    var octopus = arr[_y][_x];

                    if (octopus.Boosted)
                    {
                        Write(octopus.Value, ConsoleColor.Blue);
                        octopus.SetUnchanged();
                    }
                    else if (octopus.Value > 9)
                    {
                        if (isStep)
                        {
                            Write(octopus.Value , ConsoleColor.Red);
                        }
                        else
                        {
                            Write(0, ConsoleColor.Green);
                        }
                    }
                    else
                    {
                        Write(arr[_y][_x].Value, ConsoleColor.Gray);
                    }
                }

                Console.Write("\r\n");
            }

            Console.Write("\r\n");
        }

        private static void Write(int val, ConsoleColor color)
        {
            var defaultColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.Write(Format(val));
            Console.ForegroundColor = defaultColor;
        }

        private static string Format(int i) => i == 0 ? " 0 " : string.Format("{0,2:##}", i) + " ";

    }
}