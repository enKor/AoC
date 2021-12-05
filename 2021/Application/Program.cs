using Business;
using Business.Day1;
using Business.Day2;
using Business.Day3;
using Business.Day4;
using Business.Day5;
using Business.Day6;

namespace Application
{
    /// <summary>
    /// https://adventofcode.com/2021
    /// </summary>
    internal static class Program
    {
        private static readonly IService[] Services = {
            new Business.Day1.Service(new SonarData()),
            new Business.Day2.Service(new NavigationData()),
            new Business.Day3.Service(new DiagnosticsData()),
            new Business.Day4.Service(new BingoData()),
            new Business.Day5.Service(new FloorData()),
            new Business.Day6.Service(new Day6Data()),
        };

        private static void Main(string[] args)
        {
            RunServices();
        }

        private static void RunServices()
        {
            for (var i = 0; i < Services.Length; i++)
            {
                Log.WriteResult(i + 1, 1, Services[i].RunTask1());
                Log.WriteResult(i + 1, 2, Services[i].RunTask2());
            }
        }
    }
}