using System;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Submarine(MovementHelper.GetMovements());
            
            var simplePosition = s.MoveSimple();
            Console.WriteLine(simplePosition.depth * simplePosition.forward);

            var aimedPosition = s.MoveWithAiming();
            Console.WriteLine(aimedPosition.depth * aimedPosition.forward);
        }
    }
}
