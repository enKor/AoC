using Business.Day11;

namespace Tests
{
    public class Day11ServiceTest : ServiceTestBase
    {
        public Day11ServiceTest() 
            : base(new GlowingOctopussesService(new OctopusFieldData{Source=TestData}), 1656, 195)
        {
        }

        private const string TestData = @"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";
    }
}