using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Day7
{
    public class WhalesTreacheryService : IService
    {
        private readonly CrabData _data;

        public WhalesTreacheryService(CrabData data)
        {
            _data = data;
        }

        public object RunTask1() => GetConstantFuel();

        public object RunTask2() => GetNonConstantFuel();

        private long GetConstantFuel()
        {
            int leastFuel = default;

            foreach (var target in GetPossibleTargets())
            {
                var fuel = 0;
                foreach (var position in _data.GetPositions())
                {
                    fuel += Math.Abs(position - target);
                }

                leastFuel = LeastFuel(fuel, leastFuel);
            }

            return leastFuel;
        }

        private long GetNonConstantFuel()
        {
            int leastFuel = default;
            
            foreach (var target in GetPossibleTargets())
            {
                var fuel = 0;
                foreach (var position in _data.GetPositions())
                {
                    var diff= Math.Abs(position - target);
                    var numbers = Enumerable.Range(1, diff);
                    fuel += numbers.Sum();
                }

                leastFuel = LeastFuel(fuel, leastFuel);
            }

            return leastFuel;
        }

        private static int LeastFuel(int fuel, int leastFuel) =>
            fuel < leastFuel || leastFuel == default
                ? fuel
                : leastFuel;

        private IEnumerable<int> GetPossibleTargets()
        {
            var positions = _data.GetPositions().ToArray();
            var targetPositionsCount = Math.Abs(positions.Max() - positions.Min()) + 1;
            return Enumerable.Range(positions.Min(), targetPositionsCount);
        }
    }
}
