using System.Collections.Generic;
using System.Linq;

namespace Business.Day3
{
    public static class Extensions
    {
        public enum Freq
        {
            LeastCommon,
            MostCommon
        }

        public static char GetFrequencyChar(this IEnumerable<(char, int)> enumeration, Freq freq)
        {
            var query= freq switch
            {
                Freq.MostCommon => enumeration.OrderByDescending(x => x.Item2),
                Freq.LeastCommon => enumeration.OrderBy(x => x.Item2)
            };

            var orderedQuery = query.ToList();

            if (orderedQuery.Select(x => x.Item2).Distinct().Count() == 1)
            {
                return freq == Freq.MostCommon
                    ? "1"[0]
                    : "0"[0];
            }

            return orderedQuery
                .Select(x => x.Item1)
                .First();
        }

    }
}