using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Day6
{
    public class Service : IService
    {
        private readonly FishData _data;

        public Service(FishData data)
        {
            _data = data;
        }

        public object RunTask1() =>  FishCount(80, _data.GetFish().ToArray());

        public object RunTask2() => FishCount(256, _data.GetFish().ToArray());

        private static long FishCount(int days, Fish[] fish, bool isPrimaryRun = true)
        {
            var total = fish.LongCount();

            for (var f = 0; f < fish.Length; f++)
            {
                for (var day = 1; day <= days; day++)
                {
                    if(isPrimaryRun)Console.WriteLine($"{f}.{day}");

                    if (fish[f].DaysLeft == 0)
                    {
                        fish[f].DaysLeft = 6;

                        total += FishCount(days - day, new Fish[] {new(day)}, false);
                        continue;
                    }

                    fish[f].DaysLeft--;
                }
            }

            return total;
        }
    }
}
