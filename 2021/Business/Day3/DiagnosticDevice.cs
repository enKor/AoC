﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Day3
{
    public class DiagnosticDevice
    {
        private readonly string[] _bytes;

        public DiagnosticDevice(string[] bytes)
        {
            _bytes = bytes;
        }

        public long GetConsumption() => GetEpsilon() * GetGamma();
        public long GetLifeSupportRating() => O2Rating() * Co2Rating();

        internal int GetGamma()
        {
            var s =  GetByte(_bytes, Extender.Freq.MostCommon);
            return Convert.ToInt32(s, 2);
        }

        internal int GetEpsilon()
        {
            var s = GetByte(_bytes, Extender.Freq.LeastCommon);
            return Convert.ToInt32(s, 2);
        }

        internal int O2Rating()
        {
            var s = GetCascadedByte(_bytes.ToList(), Extender.Freq.MostCommon);
            return Convert.ToInt32(s, 2);
        }

        internal int Co2Rating()
        {
            var s = GetCascadedByte(_bytes.ToList(), Extender.Freq.LeastCommon);
            return Convert.ToInt32(s, 2);
        }


        internal static string GetByte(IReadOnlyList<string> bytes, Extender.Freq freq)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < bytes[0].Length; i++)
            {
                var b = GetChar(bytes, i, freq);
                sb.Append(b);
            }

            return sb.ToString();
        }

        internal static string GetCascadedByte(List<string> bytes, Extender.Freq freq)
        {
            while (true)
            {
                var list = bytes;

                for (var i = 0; i < list[0].Length; i++)
                {
                    if (list.Count == 1) break;

                    var b = GetChar(list, i, freq);
                    list = list.Where(x => x[i] == b).ToList();
                }

                if (list.Count == 1) return list.First();

                bytes = list;
            }
        }

        internal static char GetChar(IEnumerable<string> bytes, int position, Extender.Freq freq) =>
            bytes
                .GroupBy(x => x[position])
                .Select(x => (x.Key, x.Count()))
                .GetFrequencyChar(freq);
    }
}
