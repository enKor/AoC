using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Day8
{
    public class SevenSegmentSearchService : IService
    {
        private readonly SignalData _data;

        public SevenSegmentSearchService(SignalData data)
        {
            _data = data;
        }

        public object RunTask1() => Count();

        public object RunTask2() => Sum();

        private IEnumerable<Connection> GetData() => _data.GetData();

        private long Count()
        {
            //1,4,7,8
            var wanted = new[] {"cf", "bcdf", "acf", "abcdefg"};
            var lengths = wanted.Select(x => x.Length);

            var total = 0;

            foreach (var connection in GetData())
            {
                var orderedSignals = connection.Signals
                    .Select(x => string.Join("", x.OrderBy(c => c)));

                var intersect = connection.Segments
                    .Select(x => x.ordered)
                    .Where(x => lengths.Contains(x.Length))
                    .Intersect(orderedSignals);

                var foundUniqueNumbers = connection.Segments
                    .Where(x => intersect.Contains(x.ordered))
                    .Select(x => x.orig);

                total += foundUniqueNumbers.Count();
            }

            return total;
        }

        private long Sum()
        {
            //1,4,7,8
            var uniqueNumbers = new[] {(1, "cf"), (4, "bcdf"), (7, "acf"), (8, "abcdefg")};
            var uniqueNumbersLengths = uniqueNumbers.Select(x => x.Item2.Length);

            //0-9
            var numbers = new[]
                {"abcefg", "cf", "acdeg", "acdfg", "bcdf", "abdfg", "abdefg", "acf", "abcdefg", "abcdfg"};
            var numberLine = Enumerable.Range(0, numbers.Length).ToArray();

            var letters = numbers.Select(a => a.ToCharArray())
                .SelectMany(a => a.Select(x => x))
                .GroupBy(g => g)
                .Select<IGrouping<char, char>, (char, int)>(x => new(x.Key, x.Count()))
                .ToArray();

            var total = 0;

            foreach (var connection in GetData())
            {
                var orderedSignals = connection.Signals
                    .Select(x => string.Join("", x.OrderBy(c => c)))
                    .ToArray();

                var intersect = connection.Segments
                    .Select(x => x.ordered)
                    .Where(x => uniqueNumbersLengths.Contains(x.Length))
                    .Intersect(orderedSignals);

                var foundUniqueNumbers = connection.Segments
                    .Where(x => intersect.Contains(x.ordered))
                    .Select(x => x.orig);

                var display = GetDisplayNumber(numbers, uniqueNumbers,
                    orderedSignals, foundUniqueNumbers, numberLine,
                    connection, letters);
                total += display;
            }

            return total;
        }

        class Assignment
        {
            public char Signal { get; set; }
            public char? Segment { get; set; }
            public int[] PossibleNumbers { get; set; }

            public override string ToString() =>
                $"{Signal}->{Segment}, PossibleNumbers: {string.Join(",", PossibleNumbers)}";
        }

        // TODO In progress
        private static int GetDisplayNumber(string[] allNumbers, (int, string)[] uniqueNumbers,
            string[] orderedSignals, IEnumerable<string> foundUniqueNumbers, int[] numberLine,
            Connection connection, (char Char, int Count)[] letters)
        {
            var assign = new[] {'a', 'b', 'c', 'd', 'e', 'f', 'g'}
                .Select(x => new Assignment {PossibleNumbers = numberLine, Signal = x, Segment = null})
                .ToList();

            var signalLetters = orderedSignals.Select(a => a.ToCharArray())
                .SelectMany(a => a.Select(x => x))
                .GroupBy(g => g)
                .Select<IGrouping<char, char>, (char Char, int Count)>(x => new(x.Key, x.Count()))
                .ToArray();

            foreach (var i in new[] {4, 6, 7, 8, 9})
            {
                SetByLength(i, letters, signalLetters, assign, allNumbers);
            }

            var foundOrderedNumbers = foundUniqueNumbers
                .Select(x => new string(x.OrderBy(a => a).ToArray()))
                .ToArray();

            foreach (var unique in uniqueNumbers)
            {
                var list = new List<int>();

                foreach (var sig in orderedSignals)
                {
                    if (sig.Length == unique.Item2.Length)
                    {
                        list.Add(unique.Item1);
                    }
                }
                //assign.Where(a=>a.Signal)
            }




            var dic = orderedSignals.ToDictionary(k => k, v => (int?) default);


            foreach (var foundUniqueNumber in foundOrderedNumbers)
            {
                var item = allNumbers.Single(x => x.Length == foundUniqueNumber.Length);
                dic[foundUniqueNumber] = Array.IndexOf(allNumbers, item);
            }



            //var poss=

            //{

            //    var allNeededMapped = connection.Segments
            //        .Select(s => s.ordered)
            //        .All(x => dic[x].HasValue);

            //    //if (allNeededMapped) break;
            //}

            var display = connection.Segments
                .Select(x => dic[x.ordered].ToString())
                .Aggregate(string.Empty, (result, next) => result += next);
            return Convert.ToInt32(display);
        }

        private static void SetByLength(int n, (char Char, int Count)[] letters, (char Char, int Count)[] signalLetters,
            IEnumerable<Assignment> assign, string[] allNumbers)
        {
            var sigs = signalLetters.Where(s => s.Count == n).ToArray();
            var segs = letters.Where(s => s.Count == n).ToArray();
            var assignment = assign.Where(x => sigs.Select(s => s.Char).Contains(x.Signal)).ToList();
            assignment.ForEach(a =>
            {
                var list = new List<int>();
                foreach (var seg in segs)
                {
                    for (var i = 0; i < allNumbers.Length; i++)
                    {
                        if (allNumbers[i].Contains(seg.Char))
                        {
                            list.Add(i);
                        }
                    }
                }

                a.PossibleNumbers = list.Distinct().OrderBy(x => x).ToArray();
                a.Segment = segs.Length == 1 ? segs.Single().Char : null;
            });

        }
    }
}