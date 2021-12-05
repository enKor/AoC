using Business.Day1;
using Xunit;

namespace Tests
{
    public class Day1Test : TestBase
    {
        public Day1Test()
            : base(new Service(new SonarData { Source = TestData }), 7, 5)
        {
        }

        [Fact]
        public void GetIncreaseCountCommon_Method_Test()
        {
            var sonar = new SonarData { Source = TestData };
            var result = Sonar.GetIncreaseCountCommon(sonar.GetMeasurements());
         
            Assert.Equal(7, result);
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