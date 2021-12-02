using System;

namespace Day1
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            var sonar = new Sonar();
            Console.WriteLine(Sonar.GetIncreasesCount());
            Console.WriteLine(Sonar.GetIncreasesWithNoiseCount());

        }
    }
}
