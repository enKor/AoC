using System;

namespace Business
{
    public static class Log
    {
        public static void WriteResult(string day, int task, object result) => 
            Console.WriteLine($"{day}, task {task}: {result}");
    }
}
