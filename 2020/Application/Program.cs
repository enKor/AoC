using Business;

namespace Application
{
    /// <summary>
    /// https://adventofcode.com/2020
    /// </summary>
    internal static class Program
    {
        private static readonly IService[] Services = {
            new Business.Day1.Service(new Business.Day1.LiftData()),
            new Business.Day2.Service(new Business.Day2.PresentsData()),
            new Business.Day3.Service(new Business.Day3.NavigationData()),
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