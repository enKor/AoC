using NUnit.Framework;
using System.Text.RegularExpressions;

namespace aoc;

[TestFixture]
public class Day19
{
    [SetUp]
    public void SetUp()
    {
        _blueprints = File
            .ReadAllLines("Day19.txt")
            .Where(x=>!string.IsNullOrWhiteSpace(x.Trim()))
            .Select(x => new Blueprint
            {
                Id = GetValue(x, 1),
                OreRobot = new Robot
                {
                    Cost = new Stones
                    {
                        Ore = GetValue(x, 2)
                    },
                    Output = new Stones{Ore = 1},
                    Count = 1
                },
                ClayRobot = new Robot
                {
                    Cost = new Stones
                    {
                        Ore = GetValue(x, 3)
                    },
                    Output = new Stones { Clay = 1 }
                },
                ObsidianRobot = new Robot
                {
                    Cost = new Stones
                    {
                        Ore = GetValue(x, 4),
                        Clay = GetValue(x, 5),
                    },
                    Output = new Stones { Obsidian = 1 }
                },
                GeodeRobot = new Robot
                {
                    Cost = new Stones
                    {
                        Ore = GetValue(x, 6),
                        Obsidian = GetValue(x, 7),
                    },
                    Output = new Stones { Geode = 1 }
                }
            })
            .ToArray();
    }

    [Test]
    public void Part1()
    {
        // not yet working

        const int minutes = 24;
        var result = 0L;

        for (var b = 0; b < _blueprints.Length; b++)
        {
            var blueprint = _blueprints[b];
            var stock = new Stones();

            for (var i = 0; i < minutes; i++)
            {
                stock += blueprint.GetProduction();

                if (stock.CanRemove(blueprint.GeodeRobot.Cost))
                {
                    stock -= blueprint.GeodeRobot.Cost;
                    blueprint.GeodeRobot.Count++;
                }
                else if (stock.CanRemove(blueprint.ObsidianRobot.Cost))
                {
                    stock -= blueprint.ObsidianRobot.Cost;
                    blueprint.ObsidianRobot.Count++;
                }
                else if (stock.CanRemove(blueprint.ClayRobot.Cost))
                {
                    stock -= blueprint.ClayRobot.Cost;
                    blueprint.ClayRobot.Count++;
                }
                else if (stock.CanRemove(blueprint.OreRobot.Cost))
                {
                    stock -= blueprint.OreRobot.Cost;
                    blueprint.OreRobot.Count++;
                }
            }

            result += blueprint.Id * stock.Geode;
        }

        Assert.That(result, Is.EqualTo(33L));
    }

    [Test]
    public void Part2()
    {
        // todo

        //Assert.That(result, Is.EqualTo(36));
    }
    private class Robot
    {
        public Stones Cost { get; init; } = new();
        public int Count { get; set; }
        public Stones Output { get; set; } = new();

        public Stones Produce() => Output * Count;
    }

    private class Blueprint
    {
        public int Id { get; init; }
        public Robot OreRobot { get; init; } 
        public Robot ClayRobot { get; init; }
        public Robot ObsidianRobot { get; init; } 
        public Robot GeodeRobot { get; init; }

        public Stones GetProduction() =>
            OreRobot.Produce() +
            ClayRobot.Produce() +
            ObsidianRobot.Produce() +
            GeodeRobot.Produce();
    }

    private record Stones
    {
        public int Ore { get; set; }
        public int Clay { get; set; }
        public int Obsidian { get; set; }
        public int Geode { get; set; }

        public static Stones operator *(Stones s, int count) =>
            new()
            {
                Ore = s.Ore * count,
                Clay = s.Clay * count,
                Obsidian = s.Obsidian * count,
                Geode = s.Geode * count,
            };

        public static Stones operator -(Stones a, Stones b) =>
            new()
            {
                Ore = a.Ore - b.Ore,
                Clay = a.Clay - b.Clay,
                Obsidian = a.Obsidian - b.Obsidian,
                Geode = a.Geode - b.Geode,
            };

        public static Stones operator +(Stones a, Stones b) =>
            new()
            {
                Ore = a.Ore + b.Ore,
                Clay = a.Clay + b.Clay,
                Obsidian = a.Obsidian + b.Obsidian,
                Geode = a.Geode + b.Geode,
            };

        public bool CanRemove(Stones s)
        {
            var r = this - s;
            return r.Ore >= 0 && r.Clay >= 0 && r.Obsidian >= 0 && r.Geode >= 0;
        }
    }

    private readonly Regex _regex = new("Blueprint (\\d+): Each ore robot costs (\\d+) ore. Each clay robot costs (\\d+) ore. Each obsidian robot costs (\\d+) ore and (\\d+) clay. Each geode robot costs (\\d+) ore and (\\d+) obsidian.");

    private Blueprint[] _blueprints;

    private int GetValue(string line, int group) => Convert.ToInt32(_regex.Match(line).Groups[group].Value);
}