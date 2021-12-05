using Business.Day5;

namespace Tests
{
    public class Day5Test : TestBase
    {
        public Day5Test() 
            : base(new Service(new FloorData{Source=TestData}), 5, 12)
        {
        }

        private const string TestData = @"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";
    }
}