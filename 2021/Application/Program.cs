﻿using System;
using System.Linq;
using Business;
using Business.Day1;
using Business.Day10;
using Business.Day11;
using Business.Day12;
using Business.Day13;
using Business.Day14;
using Business.Day15;
using Business.Day2;
using Business.Day3;
using Business.Day4;
using Business.Day5;
using Business.Day6;
using Business.Day7;
using Business.Day8;
using Business.Day9;

namespace Application
{
    /// <summary>
    /// https://adventofcode.com/2021
    /// </summary>
    internal static class Program
    {
        private static readonly IService[] Services = {
            //new SonarSweepService(new SonarData()),
            //new DivingService(new NavigationData()),
            //new BinaryDiagnosticService(new DiagnosticsData()),
            //new GiantSquidService(new BingoData()),
            //new HydrothermalVentureService(new FloorData()),
            //new LanternfishService(new FishData()),
            //new WhalesTreacheryService(new CrabData()),
            //new SevenSegmentSearchService(new SignalData()),
            //new SmokeBasinService(new MapData()),
            //new SyntaxScoringService(new ChunkData()),
            //new GlowingOctopussesService(new OctopusFieldData()),
            //new CavePathwayService(new CaveData()),
            //new OrigamiService(new PaperData()),
            //new ChemService(new PolymerData()),
            new Service(new Data()),
        };

        private static void Main(string[] args)
        {
            RunServices();
            Console.Beep();
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