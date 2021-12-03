using Common;
using Day1;
using Day2;
using Day3;

namespace Application
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var services = new IService[]
            {
                new Day1.Service(new SonarData()),
                new Day2.Service(new NavigationData()),
                new Day3.Service(new DiagnosticsData()),
            };

            for (var i = 0; i < services.Length; i++)
            {
                Log.WriteResult(i + 1, 1, services[i].RunTask1());
                Log.WriteResult(i + 1, 2, services[i].RunTask2());
            }
        }
    }
}