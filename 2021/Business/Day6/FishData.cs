using System.Collections.Generic;
using System.Linq;

namespace Business.Day6
{
    public class FishData : IData
    {
        public FishData()
        {
            Source = SampleData;
        }

        public string Source { get; set; }

        public IEnumerable<Fish> GetFish() => Source.SelectNumbers(",").Select(x => new Fish(1) {DaysLeft = x});

        private const string SampleData = @"3,4,3,1,2";

    }
}