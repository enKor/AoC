using System;
using System.Linq;

namespace Business.Day11
{
    public class Data : IData
    {
        public Data()
        {
            Source = SampleData;
        }

        public string Source { get; set; }

        public Octopus[][] GetMap() =>
            Source
                .Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s
                    .Select(c => new Octopus(Convert.ToInt32(c.ToString())))
                    .ToArray())
                .ToArray();


        private const string TestData = @"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";

        private const string SampleData = @"3322874652
5636588857
7755117548
5854121833
2856682477
3124873812
1541372254
8634383236
2424323348
2265635842";
    }
}