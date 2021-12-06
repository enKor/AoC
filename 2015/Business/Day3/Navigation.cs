using System.Collections.Generic;
using System.Linq;

namespace Business.Day3
{
    public class Navigation
    {
        private readonly NavigationData _navigationData;

        public Navigation(NavigationData navigationData)
        {
            _navigationData = navigationData;
        }

        public int VisitedHousesCount(int visitorsCount = 1)
        {
            var src = _navigationData.Source.ToCharArray();
            var visitorsNavigation = new List<char>?[visitorsCount];

            for (var v = 0; v < visitorsNavigation.Length; v++)
            {
                visitorsNavigation[v] ??= new List<char>();
            }

            for (int i = 0, v = 0; i < src.Length; i++, v++)
            {
                if (v >= visitorsCount)
                {
                    v = 0;
                }

                visitorsNavigation[v]!.Add(src[i]);
            }

            return visitorsNavigation
                .Select(navigation => GetVisitedHouses(navigation!.ToArray()))
                .SelectMany(house => house)
                .Distinct()
                .Count();
        }

        private static List<(int X, int Y)> GetVisitedHouses(char[] src)
        {
            var houses = new List<(int X, int Y)> {(0, 0)};

            for (int i = 0, x = 0, y = 0; i < src.Length; i++)
            {
                switch (src[i])
                {
                    case 'v':
                        y--;
                        break;
                    case '^':
                        y++;
                        break;
                    case '<':
                        x--;
                        break;
                    case '>':
                        x++;
                        break;
                }

                houses.Add((x, y));
            }

            return houses;
        }
    }
}
