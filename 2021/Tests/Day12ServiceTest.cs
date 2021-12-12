using Business.Day12;

namespace Tests
{
    public class Day12ServiceTest : ServiceTestBase
    {
        public Day12ServiceTest()
            : base(new CavePathwayService(new CaveData { Source = TestData }), 226, 3509)
        {
        }

        private const string TestData = @"fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW";
    }
}