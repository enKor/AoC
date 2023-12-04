using NUnit.Framework;

namespace aoc;

[TestFixture]
public class Day1
{
    [SetUp]
    public void SetUp()
    {
        
    }

    [Test]
    public void Part1()
    {
        var codes = File.ReadAllLines("Day1A.txt");
        var sum = 0L;
        Span<char> numbers = stackalloc char[2];
        
        foreach (var c in codes)
        {
            ReadOnlySpan<char> code = c;
            
            for (int i = 0; i < code.Length; i++)
            {
                if (char.IsDigit(code[i]))
                {
                    numbers[0] = code[i];
                    break;
                }
            }

            for (int i = code.Length-1; i >= 0; i--)
            {
                if (char.IsDigit(code[i]))
                {
                    numbers[1] = code[i];
                    break;
                }
            }

            sum += int.Parse(numbers);
        }

        Assert.That(sum, Is.EqualTo(142));
    }

    [Test]
    public void Part2()
    {
        var codes = File.ReadAllLines("Day1B.txt");
        var sum = 0L;
        Span<char> numbers = stackalloc char[2];

        var numbersDic = new Dictionary<string, char>
        {
            { "0", '0' }, { "1", '1' }, { "2", '2' }, { "3", '3' }, { "4", '4'}, 
            { "5", '5' }, { "6", '6' }, { "7", '7' }, { "8", '8' }, { "9", '9'},
            { "one", '1' },
            { "two", '2' },
            { "three", '3' },
            { "four", '4' },
            { "five", '5' },
            { "six", '6' },
            { "seven", '7' },
            { "eight", '8' },
            { "nine", '9' },
        };

        foreach (var c in codes)
        {
            var values = numbersDic.Keys
                .Select(k => new
                {
                    Idx1st = c.IndexOf(k, StringComparison.InvariantCulture),
                    IdxLast = c.LastIndexOf(k, StringComparison.InvariantCulture),
                    Key = k
                })
                .Select(x=>new []
                {
                    new {Idx=x.Idx1st,x.Key},
                    new {Idx=x.IdxLast,x.Key},
                })
                .SelectMany(x=>x)
                .Where(x => x.Idx >= 0)
                .OrderBy(x => x.Idx)
                .ToArray();

            numbers[0] = numbersDic[values[0].Key];
            numbers[1] = numbersDic[values.Last().Key];

            sum += int.Parse(numbers);
        }

        Assert.That(sum, Is.EqualTo(281));
    }
}