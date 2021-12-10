using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Day5
{
    public class Letter
    {
        private readonly LetterData _data;

        public Letter(LetterData data)
        {
            _data = data;
        }

        public List<string> GetNicerWords()
        {
            var niceWords = new List<string>();

            foreach (var word in _data.GetWords())
            {
                var letters = word.ToCharArray();
                var pairs = new List<(int idx, string str)>();

                for (int i = 0; i < letters.Length - 1; i++)
                {
                    var s = new string(new[] {letters[i], letters[i + 1]});
                    pairs.Add((i,s));
                }

                var hasRelevantPairs = pairs
                    .GroupBy(s => s.str)
                    .Any(x => x.Count() > 2
                              || (x.Count() == 2
                                  && x.Select(s => s.idx)
                                      .Aggregate(0, (a, n) => Math.Abs(a - n)) > 1));

                var hasTriade = false;
                for (int i = 0; i < letters.Length - 2; i++)
                {
                    if (letters[i] == letters[i+2])
                    {
                        hasTriade = true;
                        break;
                    }
                }

                if (hasTriade && hasRelevantPairs) niceWords.Add(word);
            }

            return niceWords;
        }

        public List<string> GetNiceWords()
        {
            var vowels = new[] { 'a','e','i','o','u'};
            var niceWords = new List<string>();

            foreach (var word in _data.GetWords())
            {
                var letters = word.ToCharArray();

                var vowelsCount = 0;
                foreach (var letter in letters)
                {
                    if (vowels.Contains(letter)) vowelsCount++;
                    if (vowelsCount == 3) break;
                }

                if (vowelsCount < 3) continue;

                var doubles = letters.Distinct().Select(x => new string(new[]{x,x}));
                var hasDoubles = doubles.Any(d => word.Contains(d));

                if (!hasDoubles) continue;

                var ugly = new[] { "ab","cd","pq","xy"};
                var hasUgly = ugly.Any(d => word.Contains(d));

                if (hasUgly) continue;

                niceWords.Add(word);
            }


            return niceWords;
        }
    }
}