using NUnit.Framework;

namespace aoc;

[TestFixture]
public partial class Day11
{
    private class Monkey
    {
        public List<long> Items { get; set; }
        public long DivideBy { get; init; }
        public Func<long, long> Operation { get; init; }
        public int OnTrue { get; set; }
        public int OnFalse { get; set; }
        public long InspectedItems { get; set; }

        public override string ToString() => $"Inspected {InspectedItems}, Items {string.Join(", ", Items)}";
    }

    private Dictionary<int, Monkey> _monkeys = default!;

    [SetUp]
    public void SetUp()
    {
        _monkeys = SetupMonkeys();
    }

    [Test]
    public void Part1()
    {
        var result = Calculate(20, 3L, true);
        Assert.That(result, Is.EqualTo(10605));
    }

    [Test]
    public void Part2()
    {
        var divider = _monkeys.Values
            .Select(m => m.DivideBy)
            .Aggregate((a, b) => a * b);

        var result = Calculate(10_000, divider, false);
        Assert.That(result, Is.EqualTo(2713310158));
    }

    private long Calculate(int rounds, long divideBy, bool isPart1)
    {
        for (int round = 1; round <= rounds; round++)
        {
            for (int i = 0; i < _monkeys.Keys.Count; i++)
            {
                _monkeys[i].InspectedItems += _monkeys[i].Items.Count;

                foreach (var item in _monkeys[i].Items)
                {
                    var worry = isPart1
                        ? _monkeys[i].Operation(item) / divideBy
                        : _monkeys[i].Operation(item) % divideBy;
                    var divisible = worry % _monkeys[i].DivideBy == 0;

                    var targetMonkey = divisible ? _monkeys[i].OnTrue : _monkeys[i].OnFalse;
                    _monkeys[targetMonkey].Items.Add(worry);
                }

                _monkeys[i].Items = new List<long>();
            }
        }

        var highestCounts = new long[2];

        foreach (var currentMonkey in _monkeys.Values)
        {
            for (long count = 0; count < 2; count++)
            {
                if (highestCounts[count] < currentMonkey.InspectedItems)
                {
                    if (count == 0)
                    {
                        highestCounts[1] = highestCounts[0];
                    }
                    highestCounts[count] = currentMonkey.InspectedItems;
                    break;
                }
            }
        }

        var result = highestCounts[0] * highestCounts[1];
        return result;
    }
}
