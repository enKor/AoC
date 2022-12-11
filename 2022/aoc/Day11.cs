using NUnit.Framework;

namespace aoc;

[TestFixture]
public partial class Day11
{
    private class Monkey
    {
        public int Id { get; init; }
        public List<(int Value, bool Processed)> Items { get; set; }
        public int DivideBy { get; init; }
        public Func<int, int> Operation { get; init; }
        public Monkey OnTrue { get; set; }
        public Monkey OnFalse { get; set; }
    }

    private Dictionary<int, Monkey> Monkeys = new();

    [SetUp]
    public void SetUp()
    {
        var src = File.ReadAllLines("Day11.txt");
        Monkeys = SetupMonkeys(src);
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
