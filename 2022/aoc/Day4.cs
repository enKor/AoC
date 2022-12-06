using System.Text.RegularExpressions;
using NUnit.Framework;

namespace aoc;

[TestFixture]
public class Day4
{
    private string[] data;
    private readonly Regex _regex = new(@"^(\d+)-(\d+),(\d+)-(\d+)$");

    [SetUp]
    public void SetUp()
    {
        data = File.ReadAllLines("Day4.txt");
    }

    [Test]
    public void Part1()
    {
        var total = 0;

        foreach (var x in data)
        {
            var match = _regex.Match(x);
            var l1 = GetVal(match, 1);
            var r1 = GetVal(match, 2);
            var l2 = GetVal(match, 3);
            var r2 = GetVal(match, 4);

            if (l1 <= l2 && r1 >= r2 || l2 <= l1 && r2 >= r1)
            {
                total++;
            }
        }

        Assert.That(total, Is.EqualTo(2));
    }

    [Test]
    public void Part2()
    {
        var total = 0;

        foreach (var x in data)
        {
            var match = _regex.Match(x);
            var l1 = GetVal(match, 1);
            var r1 = GetVal(match, 2);
            var l2 = GetVal(match, 3);
            var r2 = GetVal(match, 4);

            if (!(r2 < l1 || l2 > r1))
            {
                total++;
            }
        }

        Assert.That(total, Is.EqualTo(4));
    }

    private static int GetVal(Match m, int grp) => Convert.ToInt32(m.Groups[grp].Value);

}