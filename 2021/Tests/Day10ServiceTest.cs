using Business.Day10;

namespace Tests
{
    public class Day10ServiceTest : ServiceTestBase
    {
        public Day10ServiceTest() 
            : base(new SyntaxScoringService(new ChunkData{Source=TestData}), 26397, 288957)
        {
        }

        private const string TestData = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]";
    }
}