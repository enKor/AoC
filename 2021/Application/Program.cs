using Business;
using Business.Day1;
using Business.Day2;
using Business.Day3;
using Business.Day4;
using Business.Day5;
using Business.Day6;

namespace Application
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var services = new IService[]
            {
                new Business.Day1.Service(new SonarData()),
                new Business.Day2.Service(new NavigationData()),
                new Business.Day3.Service(new DiagnosticsData()),
                new Business.Day4.Service(new BingoData()),
                new Business.Day5.Service(new FloorData()),
                new Business.Day6.Service(new Day6Data()),
            };

            for (var i = 0; i < services.Length; i++)
            {
                Log.WriteResult(i + 1, 1, services[i].RunTask1());
                Log.WriteResult(i + 1, 2, services[i].RunTask2());
            }
        }
    }
}