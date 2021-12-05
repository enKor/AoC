using System.Linq;
using Business.Day3;
using Xunit;

namespace Tests
{
    public class Day3ServiceTest : ServiceTestBase
    {
        public Day3ServiceTest()
            : base(new Service(new DiagnosticsData {Source = TestData}), 198, 230)
        {
        }

        [Theory]
        [InlineData(Extender.Freq.MostCommon, "10110")]
        [InlineData(Extender.Freq.LeastCommon, "01001")]
        public void GetByte_Method_Test(Extender.Freq freq, string expectedResult)
        {
            var result = DiagnosticDevice.GetByte(GetTestDataBinaries(), freq);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(Extender.Freq.MostCommon, "10111")]
        [InlineData(Extender.Freq.LeastCommon, "01010")]
        public void GetCascadedByte_Method_Test(Extender.Freq freq, string expectedResult)
        {
            var result = DiagnosticDevice.GetCascadedByte(GetTestDataBinaries().ToList(), freq);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(0, Extender.Freq.MostCommon, '1')]
        [InlineData(0, Extender.Freq.LeastCommon, '0')]
        [InlineData(1, Extender.Freq.MostCommon, '0')]
        [InlineData(1, Extender.Freq.LeastCommon, '1')]
        [InlineData(3, Extender.Freq.MostCommon, '1')]
        [InlineData(3, Extender.Freq.LeastCommon, '0')]
        public void GetChar_Method_Test(int position, Extender.Freq freq, char expectedResult)
        {
            var result = DiagnosticDevice.GetChar(GetTestDataBinaries(), position, freq);

            Assert.Equal(expectedResult, result);
        }

        private static string[] GetTestDataBinaries() => new DiagnosticsData { Source = TestData }.GetBinaries();

        private const string TestData = @"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";
    }
}