using NUnit.Framework;

namespace aoc;

[TestFixture]
public class Day12
{
    private char[][] map;

    private Dictionary<Point, int> distances = new();

    private record Point(int Row, int Column);

    private void SetBasicPoint(ref Point start, ref Point end)
    {
        for (int row = 0; row < map.Length; row++)
        {
            for (int column = 0; column < map[0].Length; column++)
            {
                if (map[row][column] == 'S')
                {
                    start = new(row, column);
                    map[row][column] = 'a';
                }
                else if (map[row][column] == 'E')
                {
                    end = new(row, column);
                    map[row][column] = 'z';
                }
            }
        }
    }

    private void ExploreNeighbour(int pathLength, Point current, Point next)
    {
        if (next.Row < 0 || next.Row >= map.Length) return;
        if (next.Column < 0 || next.Column >= map[0].Length) return;
        if (map[next.Row][next.Column] > map[current.Row][current.Column] + 1) return;
        if (distances.ContainsKey(next) && distances[next] <= pathLength + 1) return;
        
        distances[next] = pathLength + 1;
        ExploreNeighbours(pathLength + 1, next);
    }

    void ExploreNeighbours(int pathLength, Point current)
    {
        ExploreNeighbour(pathLength, current, current with { Column = current.Column + 1 });
        ExploreNeighbour(pathLength, current, current with { Column = current.Column - 1 });
        ExploreNeighbour(pathLength, current, current with { Row = current.Row + 1 });
        ExploreNeighbour(pathLength, current, current with { Row = current.Row - 1 });
    }

    [SetUp]
    public void SetUp()
    {
        map = File.ReadAllLines("Day12.txt")
            .Select(x => x.ToCharArray())
            .ToArray();
    }
    
    [Test]
    public void Part1()
    {
        var start = new Point(0, 0);
        var end = new Point(0, 0);

        SetBasicPoint(ref start, ref end);
        distances[start] = 0;
        ExploreNeighbours(0, start);
        
        var result = distances[end];

        Assert.That(result, Is.EqualTo(31));
    }

    [Test]
    public void Part2()
    {
        var start = new Point(0, 0);
        var end = new Point(0, 0);

        SetBasicPoint(ref start, ref end);

        var aLetters = map
            .SelectMany((r, row) => r
                .Select((c, col) => c == 'a' ? new Point(row, col) : new Point(-1, -1)))
            .Where(x => x != new Point(-1, -1));

        int min = int.MaxValue;

        foreach (var a in aLetters)
        {
            start = a;
            distances[start] = 0;
            ExploreNeighbours(0, start);
            if (min > distances[end]) min = distances[end];
        }

        Assert.That(min, Is.EqualTo(29));
    }
}