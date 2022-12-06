using System.Collections.ObjectModel;
using NUnit.Framework;

namespace aoc;

[TestFixture]
public class Day2
{
    private List<(char him, char me)> pairs;

    [SetUp]
    public void SetUp()
    {
        pairs = File.ReadAllLines("Day2.txt")
            .Select(x =>
            {
                if (x.Split(" ", StringSplitOptions.RemoveEmptyEntries) is [var a, var b])
                {
                    return (a[0], b[0]);
                }

                return default;
            })
            .Where(x => x != default)
            .ToList();
    }

    [Test]
    public void Part1()
    {
        var total = 0;

        foreach (var (him, me) in pairs)
        {
            var opponentMove = (Move)(him - 'A');
            var myMove = (Move)(me - 'X');

            total += 1 + (int)myMove;

            var resultingMove = MovesToResult[(myMove, opponentMove)];
            total += GetValueOfResult(resultingMove);
        }


        Assert.That(total, Is.EqualTo(15));
    }


    [Test]
    public void Part2()
    {
        var total = 0;

        foreach (var (him, me) in pairs)
        {
            var opponentMove = (Move)(him - 'A');
            var desiredResult = (Result)(me - 'X');

            var myMove = desiredResult switch
            {
                Result.Win => GetMyMove(opponentMove, Result.Win),
                Result.Loss => GetMyMove(opponentMove, Result.Loss),
                _ => opponentMove
            };

            total += 1 + (int)myMove;
            total += GetValueOfResult(desiredResult);

        }

        Assert.That(total, Is.EqualTo(12));
    }


    private enum Move { Rock, Paper, Scissors }

    private enum Result { Loss, Draw, Win }

    private static int GetValueOfResult(Result result) => result switch
    {
        Result.Loss => 0,
        Result.Draw => 3,
        Result.Win => 6,
        _ => throw new ArgumentOutOfRangeException(nameof(result), result, null)
    };

    private static readonly ReadOnlyDictionary<(Move me, Move him), Result> MovesToResult =
        new Dictionary<(Move me, Move him), Result>
        {
            { (Move.Rock, Move.Paper), Result.Loss },
            { (Move.Rock, Move.Rock), Result.Draw },
            { (Move.Rock, Move.Scissors), Result.Win },
            { (Move.Paper, Move.Rock), Result.Win },
            { (Move.Paper, Move.Scissors), Result.Loss },
            { (Move.Paper, Move.Paper), Result.Draw },
            { (Move.Scissors, Move.Paper), Result.Win },
            { (Move.Scissors, Move.Rock), Result.Loss },
            { (Move.Scissors, Move.Scissors), Result.Draw },
        }.AsReadOnly();

    private static Move GetMyMove(Move opponentMove, Result result) =>
        MovesToResult
            .Single(x => x.Value == result && x.Key.him == opponentMove)
            .Key.me;
}