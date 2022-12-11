using NUnit.Framework;
using System.Diagnostics;

namespace aoc;

[TestFixture]
public class Day10
{
    private record Command(int Value, int ExtraCycle);
    private Queue<Command> _program = default!;

    [SetUp]
    public void SetUp()
    {
        var src = File
            .ReadAllLines("Day10.txt")
            .Select(line =>
            {
                var split = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                return split switch
                {
                    ["addx", var n] => new Command(Convert.ToInt32(n), 1),
                    _ => new Command(0, 0)
                };
            });
        _program = new Queue<Command>(src);
    }

    [Test]
    public void Part1()
    {
        var subtotal = 1;
        var strongSum = 0;
        var countdown = 0;
        var value = 0;
        int cycle = 1;
        bool shouldLoad = true;
        while (true)
        {
            countdown--;

            Trace.WriteLine($"Cycle {cycle} ---------------------: {countdown}");
            Trace.WriteLine($"subtotal {subtotal}");

            if ((cycle - 20) % 40 == 0)
            {
                strongSum += subtotal * cycle;
                Trace.WriteLine($"20+40*n subtotal {subtotal}");
                Trace.WriteLine($"strong sum {strongSum}");
            }

            if (shouldLoad && _program.Count > 0)
            {
                var cmd = _program.Dequeue();
                value = cmd.Value;
                countdown = cmd.ExtraCycle;
                shouldLoad = false;
                Trace.WriteLine($"loaded {cmd}");
            }

            if (countdown == 0)
            {
                Trace.WriteLine($"Applied {value}");
                subtotal += value;
                shouldLoad = true;

                if (_program.Count == 0) break;
            }

            cycle++;
        }
        
        Assert.That(strongSum, Is.EqualTo(13140));
    }

    [Test]
    public void Part2()
    {
        var result = "";

        Assert.That(result, Is.EqualTo(@"##..##..##..##..##..##..##..##..##..##..
###...###...###...###...###...###...###.
####....####....####....####....####....
#####.....#####.....#####.....#####.....
######......######......######......####
#######.......#######.......#######....."));
    }

}
