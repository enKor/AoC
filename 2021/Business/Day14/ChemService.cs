using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Day14
{
    public class ChemService : IService
    {
        private readonly PolymerData _data;

        public ChemService(PolymerData data)
        {
            _data = data;

        }

        public object RunTask1() => Calculation1(10);

        public object RunTask2() => Calculation2(40);

        private static string GetFilePath(string filename) => Path.Combine(Environment.CurrentDirectory, @"Day14\", filename);

        private long Calculation1(int rounds)
        {
            var formula = _data.GetFormula();
            var dic = _data.GetDictionary();
            
            var src = GetFilePath("toread.txt");
            var target = GetFilePath("towrite.txt");

            File.WriteAllText(src, formula);
            File.WriteAllText(target, "");

            for (var n = 0; n < rounds; n++)
            {
                Console.WriteLine(n);
                File.WriteAllText(target, "");


                using (var fsRead = File.Open(src, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
                using (var bsRead = new BufferedStream(fsRead))
                using (var sr = new StreamReader(bsRead))
                
                using (var fsWrite= File.Open(target, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                using (var bsWrite = new BufferedStream(fsWrite))
                using (var sw= new StreamWriter(bsWrite))
                {
                    char? prev = null;
                    while (sr.Peek() >= 0)
                    {
                        var ch = (char) sr.Read();
                        if (prev == null)
                        {
                            sw.Write(ch);
                            prev = ch;
                            continue;
                        }
                        else
                        {
                            var toWrite = dic[prev + ch.ToString()] + ch;
                            sw.Write(toWrite);
                            prev = ch;

                        }

                    }
                }
                
                try
                {
                    File.Copy(target, src, true);

                    var debugFile = GetFilePath("debug" + n + ".txt");
                    File.Copy(target, debugFile, true);
                }
                catch (IOException iox)
                {
                    Console.WriteLine(iox.Message);
                }
                
            }

            var counts = new Dictionary<char, long>();
            using (var fsRead = File.Open(src, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
            using (var bsRead = new BufferedStream(fsRead))
            using (var sr = new StreamReader(bsRead))
            {
                while (sr.Peek() >= 0)
                {
                    var c = (char) sr.Read();
                    if (!counts.ContainsKey(c)) counts.Add(c, 0L);
                    counts[c]++;
                }
            }

            var min = counts.Values.Min();
            var max = counts.Values.Max();

            return max - min;
        }

        private IDictionary<string, string> _insertions;

        private long Calculation2(int rounds)
        {
            var c = PairCounts(_data.GetFormula(), rounds);
           var l= CountLetters(c);

            return l;
        }

        private IDictionary<string, long> PairCounts(string polymer, int rounds)
        {
            _insertions = _data.GetDictionary();

            var pairCounts = new Dictionary<string,long>();
            for (var i = 0; i < polymer.Length - 1; i++)
            {
                var length = i + 2;
                if(length>= polymer.Length)continue;
                
                var pair = polymer.Substring(i, length);
                if (pairCounts.ContainsKey(pair))
                    pairCounts[pair]++;
                else
                    pairCounts.Add(pair, 0L);
            }

            for (var i = 0; i < rounds; i++)
            {
                var newPairCounts = new Dictionary<string, long>();
                foreach (var kv in pairCounts)
                {
                    var pair = kv.Key;
                    var pairCount = pairCounts[pair];
                    var insert = _insertions[pair];
                    var newPair1 = pair[0] + insert;
                    var newPair2 = insert + pair[1];
                    if(!newPairCounts.ContainsKey(newPair1))newPairCounts.Add(newPair1,0L);
                    if(!newPairCounts.ContainsKey(newPair2))newPairCounts.Add(newPair2,0L);
                    newPairCounts[newPair1]+= pairCount;
                    newPairCounts[newPair2] += pairCount;
                }
                pairCounts = newPairCounts;
            }
            
            return pairCounts;
        }
        
        private static long CountLetters(IDictionary<string,long> pairCounts)
        {
            Dictionary<string, long> counts = new ();

            foreach (var s in pairCounts.Keys)
            {
                var sCount = pairCounts[s];

                var c0 = s[0];
                counts[c0.ToString()]+=sCount;

                var c1 = s[1];
                counts[c1.ToString()] += sCount;
            }

            var min = long.MaxValue;
            var max = long.MinValue;

            foreach (var l in counts.Values)
            {
                if (min > l)
                    min = l;
                if (max < l)
                    max = l;
            }

            return (max / 2) - (min / 2) + 1;
        }



    }
}