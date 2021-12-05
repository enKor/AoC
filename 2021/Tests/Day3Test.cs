using System;
using Business.Day3;

namespace Tests
{
    public class Day3Test : TestBase
    {
        public Day3Test()
            : base(new Service(new DiagnosticsData {Source = TestData}), 198, 230)
        {
        }

        public void GetByte_Method_Test()
        {
            throw new NotImplementedException();
        }

        public void GetCascadedByte_Method_Test()
        {
            throw new NotImplementedException();
        }

        public void GetChar_Method_Test()
        {
            throw new NotImplementedException();
        }


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