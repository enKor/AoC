using NUnit.Framework;

namespace aoc;

[TestFixture]
public class Day6
{
    private string data;

    [SetUp]
    public void SetUp()
    {
        data = File.ReadAllLines("Day6.txt")[0];
    }

    [Test]
    public void Part1()
    {
        var result = GetStart(4);

        Assert.That(result, Is.EqualTo(7));
    }

    [Test]
    public void Part2()
    {
        var result = GetStart(14);

        Assert.That(result, Is.EqualTo(19));
    }

    private int GetStart(int distinctLength)
    {
        for (int i = 0; i + distinctLength < data.Length; i++)
        {
            var slice = data[i..(i + distinctLength)];
            if (slice.Distinct().Count() == distinctLength)
            {
                return i + distinctLength;
            }
        }

        return int.MinValue;
    }
}