using Business.Day5;

namespace Tests
{
    public class Day6ServiceTest : ServiceTestBase
    {
        public Day6ServiceTest() 
            : base(new Service(new FloorData{Source=TestData}), 5934, -1)
        {
        }

        private const string TestData = @"3,4,3,1,2";
    }
}