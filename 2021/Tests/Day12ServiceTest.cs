using Business.Day12;

namespace Tests
{
    public class Day12ServiceTest : ServiceTestBase
    {
        public Day12ServiceTest()
            : base(new Service(new Data { Source = TestData }), -1, -1)
        {
        }

        private const string TestData = @"";
    }
}