using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day3
{
    public class DiagnosticDevice
    {
        private readonly string[] _bytes;

        public DiagnosticDevice(string[] bytes)
        {
            _bytes = bytes;
        }

        public int GetConsumption() => GetEpsilon() * GetGamma();
        public int GetLifeSupportRating() => O2Rating() * Co2Rating();

        private int GetGamma()
        {
            var s =  GetByte(_bytes, Extensions.Freq.MostCommon);
            return Convert.ToInt32(s, 2);
        }

        private int GetEpsilon()
        {
            var s = GetByte(_bytes, Extensions.Freq.LeastCommon);
            return Convert.ToInt32(s, 2);
        }

        private int O2Rating()
        {
            var s = GetCascadedByte(_bytes.ToList(), Extensions.Freq.MostCommon);
            return Convert.ToInt32(s, 2);
        }

        private int Co2Rating()
        {
            var s = GetCascadedByte(_bytes.ToList(), Extensions.Freq.LeastCommon);
            return Convert.ToInt32(s, 2);
        }


        private static string GetByte(IReadOnlyList<string> bytes, Extensions.Freq freq)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < bytes[0].Length; i++)
            {
                var b = GetChar(bytes, i, freq);
                sb.Append(b);
            }

            return sb.ToString();
        }

        private static string GetCascadedByte(List<string> bytes, Extensions.Freq freq)
        {
            var list = bytes;

            for (var i = 0; i < list[0].Length; i++)
            {
                if (list.Count == 1) break;

                var b = GetChar(list, i, freq);
                list = list.Where(x => x[i] == b).ToList();
            }

            if (list.Count == 1) 
                return list.First();

            return null;
        }

        private static char GetChar(IEnumerable<string> bytes, int position, Extensions.Freq freq) =>
            bytes
                .GroupBy(x => x[position])
                .Select(x => (x.Key, x.Count()))
                .GetFrequencyChar(freq);
    }
}
