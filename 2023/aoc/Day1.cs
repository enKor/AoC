using NUnit.Framework;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace aoc;

[TestFixture]
public class Day1
{
    private string[] codes;

    [SetUp]
    public void SetUp()
    {
        codes = File.ReadAllLines("Day1.txt");
    }

    [Test]
    public void Part1()
    {
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
       
    }
}