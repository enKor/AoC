using NUnit.Framework;

namespace aoc;

[TestFixture]
public class Day1
{
    private List<long?> calories;

    [SetUp]
    public void SetUp()
    {
        calories = File.ReadAllLines("Day1.txt")
            .Select(x => x.Trim() == string.Empty
                ? default(long?)
                : long.Parse(x))
            .ToList();
    }

    [Test]
    public void Part1()
    {
        var currentSum = 0L;
        var maxSum = 0L;

        foreach (var calorie in calories)
        {
            if (calorie is null)
            {
                currentSum = 0;
                continue;
            }

            currentSum += calorie.Value;
            if (currentSum > maxSum) maxSum = currentSum;
        }

        Assert.That(maxSum, Is.EqualTo(24000));
    }

    [Test]
    public void Part2()
    {
        var currentSum = 0L;
        var list = new List<long>();

        for (var index = 0; index < calories.Count; index++)
        {
            var calorie = calories[index];
            if (calorie is null)
            {
                list.Add(currentSum);
                currentSum = 0L;
                continue;
            }

            currentSum += calorie.Value;

            if (index == calories.Count - 1)
                list.Add(currentSum);
        }

        var result = list
            .OrderByDescending(x => x)
            .Take(3)
            .Sum();

        Assert.That(result, Is.EqualTo(45000));
    }
}