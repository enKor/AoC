using System.Collections.Generic;

namespace Business.Day8
{
    public class Day8Data : IData
    {
        public Day8Data()
        {
            Source = SampleData;
        }

        public string Source { get; set; }

        public IEnumerable<int> GetData() => Source.SelectNumbers(",");

        private const string SampleData = @"";

    }
}