using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

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

        private IEnumerable<Connection> GetData() => _data.GetTestData();

        private long Count()
        {
            //1,4,7,8
            var wanted = new[] { "cf", "bcdf", "acf", "abcdefg" };
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
            var uniqueNumbers = new[] { "cf", "bcdf", "acf", "abcdefg" };
            var uniqueNumbersLengths = uniqueNumbers.Select(x => x.Length);

            //0-9
            var numbers = new[] { "abcefg", "cf", "acdeg", "acdfg", "bcdf", "abdfg", "abdefg", "acf", "abcdefg", "abcdfg" };
            var numberLine = Enumerable.Range(0, numbers.Length).ToArray();

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
                    connection);
                total += display;
            }

            return total;
        }

        private static int GetDisplayNumber(string[] allNumbers, string[] uniqueNumbers,
            IEnumerable<string> orderedSignals, IEnumerable<string> foundUniqueNumbers, int[] numberLine,
            Connection connection)
        {
            var dic = orderedSignals.
                ToDictionary(k => k, v => (int?) default);

            var foundOrderedNumbers = foundUniqueNumbers.Select(x => new string(x.OrderBy(a => a).ToArray()));

            foreach (var foundUniqueNumber in foundOrderedNumbers)
            {
                var item = allNumbers.Single(x => x.Length == foundUniqueNumber.Length);
                dic[foundUniqueNumber] = Array.IndexOf(allNumbers, item);
            }

            foreach (var kv in dic.Where(kv=>!kv.Value.HasValue))
            {
                var notSolvedNumbers = numberLine.Except(dic.Values.Where(a => a.HasValue).Select(x=>x.Value));
                
                foreach (var i in notSolvedNumbers)
                {
                    if (i == 0)
                    {

                    }
                    else if (i == 1)
                    {

                    }
                    else if (i == 2)
                    {

                    }
                    else if (i == 3)
                    {

                    }
                    else if (i == 4)
                    {

                    }
                    else if (i == 5)
                    {

                    }
                    else if (i == 6)
                    {

                    }
                    else if (i == 7)
                    {

                    }
                    else if (i == 8)
                    {

                    }
                    else if (i == 9)
                    {

                    }
                }

                var allNeededMapped = connection.Segments
                    .Select(s => s.ordered)
                    .All(x => dic[x].HasValue);

                if (allNeededMapped) break;
            }

            var display = connection.Segments
                .Select(x => dic[x.ordered].ToString())
                .Aggregate(string.Empty, (result, next) => result += next);
            return Convert.ToInt32(display);
        }
    }
}