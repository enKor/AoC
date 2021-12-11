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