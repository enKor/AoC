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
        var sumGamesIds = File.ReadAllLines("Day2.txt")
            .Select(GetId)
            .Sum();
        
        Assert.That(sumGamesIds, Is.EqualTo(8));
    }

    [Test]
    public void Part2()
    {
        var sumGamesPowers = File.ReadAllLines("Day2.txt")
            .Select(GetPower)
            .Sum();

        Assert.That(sumGamesPowers, Is.EqualTo(2286));
    }

    [Test]
    public void GetPower_ValidGameTest()
    {
        var power = GetPower("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");

        Assert.That(power, Is.EqualTo(48));
    }

    [Test]
    public void GetId_ValidGameTest()
    {
        var id = GetId("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");

        Assert.That(id, Is.EqualTo(1));
    }

    [Test]
    public void GetId_InvalidGameTest()
    {
        var id = GetId("Game 1: 3 blue, 4 red; 13 red, 2 green, 6 blue; 2 green");

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

    private static long GetPower(string x)
    {
        var split = x
            .Replace(";", string.Empty)
            .Replace(",", string.Empty)
            .Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        long r = 0, g = 0, b = 0;

        for (int i = 2; i < split.Length; i += 2)
        {
            var value = int.Parse(split[i]);
            switch (split[i + 1])
            {
                case "red":
                    r = Math.Max(r, value);
                    break;
                case "green":
                    g = Math.Max(g, value);
                    break;
                case "blue":
                    b = Math.Max(b, value);
                    break;
            }
        }

        var power = r * g * b;

        return power;
    }
}