using Business.Day7;

namespace Tests
{
    public class Day7ServiceTest : ServiceTestBase
    {
        public Day7ServiceTest() 
            : base(new WhalesTreacheryService(new CrabData{Source=TestData}), 37, 168)
        {
        }

        private const string TestData = @"16,1,2,0,4,2,7,1,2,14";
    }
}