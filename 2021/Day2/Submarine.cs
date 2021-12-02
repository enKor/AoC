using System.Collections.Immutable;
using System.Linq;

namespace Day2
{
    internal class Submarine
    {
        private readonly Vector[] _movements;

        public Submarine(Vector[] movements)
        {
            _movements = movements;
        }

        public (int forward, int depth) MoveSimple()
        {
            var subTotal = _movements.GroupBy(x => x.Dir)
                .Select(x => (x.Key, x.Sum(s => s.Value)))
                .ToImmutableArray();

            var forward = subTotal.Single(x => x.Key == Direction.Forward).Item2;
            var up = subTotal.Single(x => x.Key == Direction.Up).Item2;
            var down = subTotal.Single(x => x.Key == Direction.Down).Item2;

            return (forward, down - up);
        }

        public (int forward, int depth) MoveWithAiming()
        {
            int forward = 0, depth = 0, aim = 0;

            foreach (var movement in _movements)
            {
                if (movement.Dir == Direction.Forward)
                {
                    forward += movement.Value;
                    if (aim != 0)
                    {
                        depth += movement.Value * aim;
                    }
                }
                else if (movement.Dir==Direction.Down)
                {
                    aim += movement.Value;
                }
                else if (movement.Dir == Direction.Up)
                {
                    aim -= movement.Value;
                }
            }

            return (forward,depth);
        }
    }
}
