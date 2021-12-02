using Day2;

namespace Tests
{
    public class Day2Test : TestBase
    {
        public Day2Test() : base(new Service(new TestData()), 150, 900)
        {
        }

        private class TestData : NavigationData
        {
            public override string Movements()
            {
                return @"forward 5
down 5
forward 8
up 3
down 8
forward 2";
            }
        }
    }
}