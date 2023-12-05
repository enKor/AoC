using NUnit.Framework;

namespace aoc;

[TestFixture]
public class Day2
{
    [SetUp]
    public void SetUp()
    {
        
    }

    [Test]
    public void Part1()
    {
        var sumGamesIds = File.ReadAllLines("Day2A.txt")
            .Select(GetId)
            .Sum();
        
        Assert.That(sumGamesIds, Is.EqualTo(8));
    }

    [Test]
    public void Part2()
    {
        

        //Assert.That(sum, Is.EqualTo(281));
    }

    [Test]
    public void GetIdTest()
    {
        var id = GetId("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");

        Assert.That(id, Is.EqualTo(1));
    }

    private static int GetId(string x)
    {
        const int maxRed = 12;
        const int maxGreen = 13;
        const int maxBlue = 14;

        var split = x
            .Replace(";", string.Empty)
            .Replace(",", string.Empty)
            .Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        for (int i = 2; i < split.Length; i += 2)
        {
            var value = int.Parse(split[i]);
            var isOk = split[i + 1] switch
            {
                "red" => value <= maxRed,
                "green" => value <= maxGreen,
                "blue" => value <= maxBlue,
            };

            if (!isOk)
            {
                return 0;
            }
        }

        var id = int.Parse(split[1].AsSpan()[..^1]);

        return id;
    }


    private class Game
    {
        public int Id { get; set; }
        public List<Set> Sets { get; set; }

        public class Set
        {
            public int Red { get; set; }
            public int Green { get; set; }
            public int Blue { get; set; }
        }
    }
}