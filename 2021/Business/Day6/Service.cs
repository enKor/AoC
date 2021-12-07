using System.Collections.Generic;
using System.Linq;

namespace Business.Day6
{
    public class Service : IService
    {
        private readonly FishData _data;

        public Service(FishData data)
        {
            _data = data;
        }

        public object RunTask1() => FishCount(80, _data.GetFish());

        public object RunTask2() => FishCount(256, _data.GetFish());

        private static long FishCount(int days, IEnumerable<int> fish)
        {
            const int newLife = 8;

            var arr = fish.ToArray();

            var dic = Enumerable
                .Range(0, newLife + 1)
                .Select(key => (key, 0))
                .ToDictionary(
                    k => k.key,
                    v => arr.LongCount(x => x == v.key));

            for (var day = 1; day <= days; day++)
            {
                dic = LiveOneDay(dic, newLife);
            }

            return dic.Select(x => x.Value).Sum(x => x);
        }

        internal static Dictionary<int, long> LiveOneDay(Dictionary<int, long> src, int newLife)
        {
            var result = new Dictionary<int, long>(src);
            const int afterBreedLife = 6;

            var toAdd = src[0];

            for (var k = src.Keys.Count - 1; k >= 0; k--)
            {
                var srcKey = src.Keys.ElementAt(k);
                var keyToUpdate = k == 0 ? afterBreedLife : k - 1;

                result[keyToUpdate] = srcKey == 0
                    ? src[srcKey] + result[keyToUpdate]
                    : src[srcKey];
            }
            
            result[newLife] = toAdd;

            return result;
        }
    }
}
