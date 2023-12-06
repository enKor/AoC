using System.Diagnostics;
using NUnit.Framework;

namespace aoc;

[TestFixture]
public class Day3
{
    private string[] _engine = Array.Empty<string>();

    [SetUp]
    public void SetUp()
    {
        _engine = File.ReadAllLines("Day3.txt");
    }

    [Test]
    public void Part1()
    {
        long sum = 0;

        Span<char> number = stackalloc char[3];
        number.Fill(' ');
        var length = 0;

        for (int row = 0; row < _engine.Length; row++)
        {
            if (length > 0 && IsAdjacent(row, _engine[row].Length - length, length))
            {
                Debug.WriteLine(number.ToString());

                sum += int.Parse(number);
            }

            length = 0;
            number.Fill(' ');

            for (int position = 0; position < _engine[row].Length; position++)
            {
                Debug.WriteLine($"R:{row},C:{position}");

                var ch = _engine[row][position];
                if (char.IsDigit(ch))
                {
                    number[length] = ch;
                    length++;
                }
                else
                {
                    if (length > 0 && IsAdjacent(row, position - length, length))
                    {
                        Debug.WriteLine(number.ToString());

                        sum += int.Parse(number);
                    }

                    length = 0;
                    number.Fill(' ');
                }
            }
        }

        Assert.That(sum, Is.EqualTo(4361));
    }

    [Test]
    public void Part2()
    {
        //Assert.That(sumGamesPowers, Is.EqualTo(0));
    }

    private bool IsAdjacent(int row, int start, int length)
    {
        if (row > 0 && AdjacesSymbolInRow(row - 1, start, length)) return true;
        if (row < _engine.Length - 1 && AdjacesSymbolInRow(row + 1, start, length)) return true;
        if (AdjacesSymbolInRow(row, start, length)) return true;

        return false;
    }

    private bool AdjacesSymbolInRow(int row, int start, int length)
    {
        for (int i = -1; i < length + 1; i++)
        {
            if (IsSymbol(row, start + i)) return true;
        }

        return false;
    }

    private bool IsSymbol(int row, int idx) =>
        idx >= 0 && idx < _engine[row].Length && IsSymbol(_engine[row][idx]);

    private static bool IsSymbol(char ch) => ch != '.' && !char.IsDigit(ch);
}