using System.Text.RegularExpressions;
using NUnit.Framework;

namespace aoc;

[TestFixture]
public class Day5
{
    private Dictionary<int, Stack<char>> Stacks;
    private (int count, int from, int to)[] Steps;

    [SetUp]
    public void SetUp()
    {
        var data = File.ReadAllLines("Day5.txt");
        Stacks = GetStacks(data);
        Steps = GetSteps(data);
    }

    [Test]
    public void Part1()
    {
        foreach (var (count, from, to) in Steps)
        {
            var src = Stacks[from - 1];
            var target = Stacks[to - 1];
            Move(count, target, src);
        }

        var result = new string(Stacks.Select(x => x.Value.Peek()).ToArray());

        Assert.That(result, Is.EqualTo("CMZ"));
    }

    [Test]
    public void Part2()
    {
        foreach (var (count, from, to) in Steps)
        {
            var src = Stacks[from - 1];
            var target = Stacks[to - 1];

            var tempStack = new Stack<char>();

            Move(count, tempStack, src);
            Move(count, target, tempStack);
        }

        var result = new string(Stacks.Select(x => x.Value.Peek()).ToArray());

        Assert.That(result, Is.EqualTo("MCD"));
    }

    private static Dictionary<int, Stack<char>> GetStacks(string[] data)
    {
        var emptyRowIdx = GetEmptyRowIndex(data);

        var stacks = data[emptyRowIdx - 1]
            .Select((x, i) =>
            {
                var v = x != ' ' ? (int)x : ' ';
                return (i, v);
            })
            .Where(x => x is not (_, ' '))
            .ToDictionary(x => x.i, _ => new Stack<char>());

        for (int idx = emptyRowIdx - 1; idx >= 0; idx--)
        {
            data[idx]
                .Select((c, i) => (i, c))
                .Where(x => x.c is >= 'A' and <= 'Z')
                .ToList()
                .ForEach(x =>
                {
                    stacks[x.i].Push(x.c);
                });
        }

        stacks = stacks
            .Select((x, i) => (i, x.Value))
            .ToDictionary(x => x.i, x => x.Value);

        return stacks;
    }

    private static (int, int, int)[] GetSteps(IEnumerable<string> data)
    {
        var regex = new Regex(@"^move (\d+) from (\d+) to (\d+)$");

        return data
            .Select(x =>
            {
                var m = regex.Match(x);
                if (m.Success) return (GetVal(m, 1), GetVal(m, 2), GetVal(m, 3));
                else return (0, 0, 0);
            })
            .Where(x => x is not (0, 0, 0))
            .ToArray();
    }

    private static int GetEmptyRowIndex(IEnumerable<string> data) =>
        data
            .Select((x, i) => (i, x))
            .Where(o => o.x.Trim() == string.Empty)
            .Select(o => o.i)
            .First();

    private static void Move(int count, Stack<char> target, Stack<char> src)
    {
        for (int i = 0; i < count; i++)
        {
            target.Push(src.Pop());
        }
    }

    private static int GetVal(Match m, int grp) => Convert.ToInt32(m.Groups[grp].Value);
}