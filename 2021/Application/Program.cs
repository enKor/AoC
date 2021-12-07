using Business;
using Business.Day1;
using Business.Day2;
using Business.Day3;
using Business.Day4;
using Business.Day5;
using Business.Day6;
using Business.Day7;
using Business.Day8;

namespace Application
{
    /// <summary>
    /// https://adventofcode.com/2021
    /// </summary>
    internal static class Program
    {
        private static readonly IService[] Services = {
            new SonarSweepService(new SonarData()),
            new DivingService(new NavigationData()),
            new BinaryDiagnosticService(new DiagnosticsData()),
            new GiantSquidService(new BingoData()),
            new HydrothermalVentureService(new FloorData()),
            new LanternfishService(new FishData()),
            new WhalesTreacheryService(new CrabData()),
            new Service(new Day8Data()),
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