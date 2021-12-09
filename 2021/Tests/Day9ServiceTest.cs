using Business.Day9;

namespace Tests
{
    public class Day9ServiceTest : ServiceTestBase
    {
        public Day9ServiceTest() 
            : base(new SmokeBasinService(new MapData(){Source=TestData}), 15, 1134 )
        {
        }

        private const string TestData = @"2199943210
3987894921
9856789892
8767896789
9899965678";
    }
}