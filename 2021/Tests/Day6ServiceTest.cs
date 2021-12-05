using Business.Day5;

namespace Tests
{
    public class Day6ServiceTest : ServiceTestBase
    {
        public Day6ServiceTest() 
            : base(new Service(new FloorData{Source=TestData}), -1, -1)
        {
        }

        private const string TestData = @"";
    }
}