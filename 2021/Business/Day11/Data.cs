using System;
using System.Linq;

namespace Business.Day11
{
    public class Data : IData
    {
        public Data()
        {
            Source = TestData;
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

        private const string SampleData = @"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";
    }
}