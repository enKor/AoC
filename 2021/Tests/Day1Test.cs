using Day1;

namespace Tests
{
    public class Day1Test : TestBase
    {
        public Day1Test()
            : base(new Service(new SonarData { Source = TestData }), 7, 5)
        {
        }

        private const string TestData = @"199
200
208
210
200
207
240
269
260
263";
    }
}