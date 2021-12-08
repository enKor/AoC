using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Day8
{
    public class SignalData : IData
    {
        public SignalData()
        {
            Source = SampleData;
        }

        public string Source { get; set; }

        public IEnumerable<Connection> GetTestData()
        {
            var split = Source.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < split.Length; i += 2)
            {
                var c = split
                        .Skip(i)
                        .Take(2)
                        .Select(x => x.Replace("|", ""))
                        .Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries))
                        .ToArray();

                yield return new Connection(c[0], c[1]);
            }
        }
        public IEnumerable<Connection> GetData() =>
            Source.Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(x =>
                {
                    var c = x
                        .Split("|", StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => s.Split(" ", StringSplitOptions.RemoveEmptyEntries))
                        .ToArray();
                    return new Connection(c[0], c[1]);
                });

        private const string SampleData = @"be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb |
fdgacbe cefdb cefbgd gcbe
edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec |
fcgedb cgb dgebacf gc
fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef |
cg cg fdcagb cbg
fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega |
efabcd cedba gadfec cb
aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga |
gecf egdcabf bgf bfgea
fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf |
gebdcfa ecba ca fadegcb
dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf |
cefg dcbef fcge gbcadfe
bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd |
ed bcgafe cdgba cbgef
egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg |
gbdfcae bgc cg cgb
gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc |
fgae cfgab fg bagce";

    }
}