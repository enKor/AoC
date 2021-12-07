using Business.Day6;

namespace Tests
{
    public class Day6ServiceTest : ServiceTestBase
    {
        public Day6ServiceTest() 
            : base(new LanternfishService(new FishData{Source=TestData}), 5934, 26984457539)
        {
        }

        private const string TestData = @"3,4,3,1,2";
    }
}