using NUnit.Framework;

namespace aoc;

[TestFixture]
public class Day3
{
    private string[] data;

    [SetUp]
    public void SetUp()
    {
        data = File.ReadAllLines("Day3.txt");
    }

    [Test]
    public void Part1()
    {
        var total = 0;
        foreach (var input in data)
        {
            string line = input.Trim();
            (string, string) intervals = (line[..(line.Length / 2)], line[(line.Length / 2)..]);
            char commonChar = intervals.Item1.Intersect(intervals.Item2).ToArray()[0];
            int diff = commonChar switch
            {
                >= 'a' and <= 'z' => -97,
                >= 'A' and <= 'Z' => -65 + 26,
                _ => throw new NotImplementedException()
            };
            var subtotal = commonChar + diff + 1;
            total += subtotal;
        }

        Assert.That(total, Is.EqualTo(157));
    }

    [Test]
    public void Part2()
    {
        var total = 0;
        var groups = data.Chunk(3);
        foreach (var group in groups)
        {
            var listOfLists = new List<char[]>
            {
                group[0].ToArray(),
                group[1].ToArray(),
                group[2].ToArray(),
            };
            var commonChar = listOfLists
                .Aggregate((previousList, nextList) =>
                    previousList.Intersect(nextList).ToArray())[0];

            var diff = commonChar switch
            {
                >= 'a' and <= 'z' => -97,
                >= 'A' and <= 'Z' => -65 + 26,
                _ => throw new NotImplementedException()
            };
            var subtotal = commonChar + diff + 1;
            total += subtotal;

        }
        Assert.That(total, Is.EqualTo(70));
    }
}