using Business.Day5;

namespace Tests
{
    public class Day6Test : TestBase
    {
        public Day6Test() 
            : base(new Service(new FloorData{Source=TestData}), -1, -1)
        {
        }

        private const string TestData = @"";
    }
}