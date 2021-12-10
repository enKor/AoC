namespace Business.Day11
{
    public class Data : IData
    {
        public Data()
        {
            Source = SampleData;
        }

        public string Source { get; set; }

        private const string SampleData = @"";
    }
}