using System;
using System.Threading.Tasks.Dataflow;

namespace Business.Day11
{
    public class Service : IService
    {
        private readonly Data _data;

        public Service(Data data)
        {
            _data = data;
        }

        public object RunTask1() => CountFlashes();

        public object RunTask2() => -1;

        private long CountFlashes()
        {
            var octopuses = _data.GetMap();
            var flashed = 0L;

            for (int i = 1; i <= 100; i++)
            {
                flashed += RunStep(octopuses);
            }

            return flashed;
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
                    if (octopus.Value == 10)
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

        private static int ResetFlashing(Octopus[][] octs)
        {
            var flashing = 0;
            for (int y = 0; y < octs.Length; y++)
                for (int x = 0; x < octs[0].Length; x++)
                {
                    if (octs[y][x].Value > 9)
                    {
                        flashing++;
                        octs[y][x].Discharge();
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
            //return;

            for (var _y = 0; _y < arr.Length; _y++)
            {
                for (var _x = 0; _x < arr[_y].Length; _x++)
                {
                    var octopus = arr[_y][_x];

                    if (octopus.Changed)
                    {
                        Write(isStep ? octopus.Value : 0, ConsoleColor.Blue);
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
                        Write(arr[_y][_x].Value, ConsoleColor.White);
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
        private static string Format(int i) => $"{i,2:##} ";

    }
}