using NUnit.Framework;

namespace aoc;

[TestFixture]
public class Day11
{
    private class Monkey
    {
        public List<int> Items { get; set; }
        public int DivideBy { get; init; }
        public Func<int,int> Operation{get; init; }
        public Monkey OnTrue { get; set; }
        public Monkey OnFalse { get; set; }
    }


    [SetUp]
    public void SetUp()
    {
        var src = File
            .ReadAllLines("Day11.txt");
    }

    [Test]
    public void Part1()
    {
        var sum = 0;
        Assert.That(sum, Is.EqualTo(10605));
    }

    [Test]
    public void Part2()
    {
        var result = 0;

        Assert.That(result, Is.EqualTo(0));
    }

}
