using System;

namespace Common
{
    public static class Log
    {
        public static void WriteResult(int day, int task, object result) => 
            Console.WriteLine($"Day {day}, task {task}: {result}");
    }
}
