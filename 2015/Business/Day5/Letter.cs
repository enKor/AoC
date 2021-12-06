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

        public string[] GetNiceWords()
        {
            var vovels = new[] { 'a','e','i','o','u'};
            var niceWords = new List<string>();

            foreach (var word in _data.GetWords())
            {
                var letters = word.ToCharArray();

                var vovelsCount = 0;
                foreach (var letter in letters)
                {
                    if (vovels.Contains(letter)) vovelsCount++;
                    if (vovelsCount == 3) break;
                }

                if (vovelsCount < 3) continue;

                var doubles = letters.Distinct().Select(x => new string(new[]{x,x}));
                var hasDoubles = doubles.Any(d => word.Contains(d));

                if (!hasDoubles) continue;

                var ugly = new[] { "ab","cd","pq","xy"};
                var hasUgly = ugly.Any(d => word.Contains(d));

                if (hasUgly) continue;

                niceWords.Add(word);
            }


            return niceWords.ToArray();
        }
    }
}