using System;
using System.Linq;
using Business;
using Business.Day1;
using Business.Day2;
using Business.Day25;
using Business.Day3;
using Business.Day4;
using Business.Day5;

namespace Application
{
    /// <summary>
    /// https://adventofcode.com/2020
    /// </summary>
    internal static class Program
    {
        private static readonly IService[] Services = {
            //new Business.Day1.Service(new LiftData()),
            //new Business.Day2.Service(new PresentsData()),
            //new Business.Day3.Service(new NavigationData()),
            //new Business.Day4.Service(new Md5Data()),
            //new Business.Day5.Service(new Data()),
            new Business.Day25.Service(new Data()),
        };

        private static void Main(string[] args)
        {
            RunServices();
        }

        private static void RunServices()
        {
            foreach (var service in Services)
            {
                var day = service.GetType().Namespace!.Split(".", StringSplitOptions.RemoveEmptyEntries).Last();
                Log.WriteResult(day, 1, service.RunTask1());
                Log.WriteResult(day, 2, service.RunTask2());
            }
        }
    }
}