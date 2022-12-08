using NUnit.Framework;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace aoc;

[TestFixture]
public class Day8
{
    private int[][] _forrest;

    [SetUp]
    public void SetUp()
    {
        var data = File.ReadAllLines("Day8.txt");

        _forrest = new int[data.Length][];
        for (int y = 0; y < data.Length; y++)
        {
            _forrest[y] = new int[data[y].Length];
            for (int x = 0; x < data[y].Length; x++)
            {
                _forrest[y][x] = Convert.ToInt32(data[y][x].ToString());
            }
        }
    }

    [Test]
    public void Part1()
    {
        var trees = new List<Tree>();

        for (int y = 1; y < _forrest.Length - 1; y++)
        {
            for (int x = 1; x < _forrest[y].Length - 1; x++)
            {
                if (_forrest[y][x - 1] < _forrest[y][x]) trees.Add(new Tree(y, x));
                if (_forrest[y][x - 1] > _forrest[y][x]) break;
            }

            for (int x = _forrest[y].Length - 2; x > 0; x--)
            {
                if (_forrest[y][x + 1] < _forrest[y][x]) trees.Add(new Tree(y, x));
                if (_forrest[y][x + 1] > _forrest[y][x]) break;
            }
        }

        for (int x = 1; x < _forrest[0].Length - 1; x++)
        {
            for (int y = 1; y < _forrest[x].Length - 1; y++)
            {
                if (_forrest[y - 1][x] < _forrest[y][x]) trees.Add(new Tree(y, x));
                if (_forrest[y - 1][x] > _forrest[y][x]) break;
            }

            for (int y = _forrest[x].Length - 2; y > 0; y--)
            {
                if (_forrest[y + 1][x] < _forrest[y][x]) trees.Add(new Tree(y, x));
                if (_forrest[y + 1][x] > _forrest[y][x]) break;
            }
        }


        var result = trees.Distinct().Count();
        result += (_forrest.Length - 1) * 2 + (_forrest[0].Length - 1) * 2;

        Assert.That(result, Is.EqualTo(21));
    }

    [Test]
    public void Part2()
    {

        //Assert.That(result, Is.EqualTo(19));
    }

    record Tree(int Y, int X);

}
