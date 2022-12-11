using NUnit.Framework;

namespace aoc;

[TestFixture]
public class Day9
{
    private IEnumerable<Direction> movements;

    [SetUp]
    public void SetUp()
    {
        movements = File
            .ReadAllLines("Day9.txt")
            .SelectMany(GetDirections)
            .ToList();
    }

    [Test]
    public void Part1()
    { 
        var rope = new Rope();
        var tailPositions = new List<(int, int)>();

        foreach (var movement in movements)
        {
            rope.Move(movement);
            tailPositions.Add((rope.Tail.X,rope.Tail.Y));
        }

        var result = tailPositions.Distinct().Count();

        Assert.That(result, Is.EqualTo(13));
    }

    [Test]
    public void Part2()
    {
        // todo

        //Assert.That(result, Is.EqualTo(36));
    }

    private enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    private static IEnumerable<Direction> GetDirections(string line) =>
        Enumerable.Range(0, Convert.ToInt32(line[2..]))
            .Select(x => line[..1] switch
            {
                "U" => Direction.Up,
                "D" => Direction.Down,
                "L" => Direction.Left,
                "R" => Direction.Right,
            });

    private class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Move(Direction direction) =>
            (X, Y) = direction switch
            {
                Direction.Up => (X, ++Y),
                Direction.Down => (X, --Y),
                Direction.Right => (++X, Y),
                Direction.Left => (--X, Y),
            };

        public override string ToString() => $"{X},{Y}";
    }

    private class Rope
    {
        public Rope()
        {
            Head = new Point();
            Tail = new Point();
        }

        private Point Head { get; }
        public Point Tail { get; }

        public void Move(Direction headDirection)
        {
            var prevHead = (Head.X, Head.Y);
            Head.Move(headDirection);
            MoveTailTowardsHead(prevHead);
        }

        private void MoveTailTowardsHead((int x, int y) prevHead)
        {
            if (Math.Abs(Head.Y - Tail.Y) == 1 && Math.Abs(Head.X - Tail.X) == 1)
                return;
            if (Head.X == Tail.X &&
                (Head.Y == Tail.Y || Math.Abs(Head.Y - Tail.Y) == 1) ||
                (Head.Y == Tail.Y && Math.Abs(Head.X - Tail.X) == 1))
                return;
            (Tail.X, Tail.Y) = prevHead;
        }
        
    }
}
