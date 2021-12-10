using Business.Day11;

namespace Tests
{
    public class Day11ServiceTest : ServiceTestBase
    {
        public Day11ServiceTest() 
            : base(new Service(new Data{Source=TestData}), -1, -1)
        {
        }

        private const string TestData = @"";
    }
}