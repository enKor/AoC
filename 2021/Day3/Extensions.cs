using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    public static class Extensions
    {
        public enum Freq
        {
            Min,
            Max
        }

        public static IOrderedEnumerable<(char, int)> OrderBy(this IEnumerable<(char, int)> enumerable, Freq freq)
        {
            return freq switch
            {
                Freq.Max => enumerable.OrderByDescending(x => x.Item2),
                Freq.Min => enumerable.OrderBy(x => x.Item2)
            };
        }

    }
}