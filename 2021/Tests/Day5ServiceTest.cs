using Business.Day5;
using Xunit;

namespace Tests
{
    public class Day5ServiceTest : ServiceTestBase
    {
        public Day5ServiceTest()
            : base(new Service(new FloorData { Source = TestData }), 5, 12)
        {
        }

        [Theory]
        [MemberData(nameof(VectorData))]
        public void IsDiagonal_Method_Test(Vector2 a, Vector2 b, bool expectedResult)
        {
            var result = Service.IsDiagonal(a, b);
            Assert.True(result == expectedResult);
        }

        public static TheoryData<Vector2, Vector2, bool> VectorData =
            new()
            {
                {new Vector2(0, 8), new Vector2(9, 0), false},
                {new Vector2(0, 8), new Vector2(8, 0), true},
                {new Vector2(2, 2), new Vector2(1, 1), true},
                {new Vector2(2, 2), new Vector2(1, 0), false},
                {new Vector2(3, 4), new Vector2(17, 0), false},
                {new Vector2(0, 8), new Vector2(0, 6), false},
                {new Vector2(1, 8), new Vector2(1, 9), false},
                {new Vector2(5, 5), new Vector2(5, 5), true},
                {new Vector2(5, 5), new Vector2(7, 3), true}
            };


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