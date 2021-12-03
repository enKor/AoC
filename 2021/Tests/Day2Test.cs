using Day2;

namespace Tests
{
    public class Day2Test : TestBase
    {
        public Day2Test() 
            : base(new Service(new NavigationData { Source = TestData }), 150, 900)
        {
        }

        private const string TestData = @"forward 5
down 5
forward 8
up 3
down 8
forward 2";
    }
}