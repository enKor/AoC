using System;
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

        private int GetGamma() => GetInt(Extensions.Freq.Max);
        private int GetEpsilon() => GetInt(Extensions.Freq.Min);

        private int GetInt(Extensions.Freq freq)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < _bytes[0].Length; i++)
            {
                var b = GetChar(i, freq);
                sb.Append(b);
            }

            return Convert.ToInt32(sb.ToString(), 2);
        }
        
        private char GetChar(int position, Extensions.Freq freq)=> 
            _bytes
            .GroupBy(x => x[position])
            .Select(x => (x.Key, x.Count()))
            .OrderBy(freq)
            .Select(x => x.Item1)
            .First();

        
    }
}
