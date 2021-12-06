using System.Linq;

namespace Business.Day1
{
    public class Lift
    {
        private readonly LiftData _liftData;

        public Lift(LiftData liftData)
        {
            _liftData = liftData;
        }

        public int GetFloor()
        {
            var chars = _liftData.Source
                .ToArray()
                .GroupBy(x => x)
                .Select(x => (x.Key, x.Count()))
                .ToArray();

            var plus = chars.Single(x => x.Key == '(').Item2;
            var minus = chars.Single(x => x.Key == ')').Item2;
            return plus - minus;
        }

        public int GetBasementMovementPosition()
        {
            var currentPosition = 0;
            const int basement = -1;
            var src = _liftData.Source.ToCharArray();

            for (int movement = 1; movement <= src.Length; movement++)
            {
                currentPosition += src[movement - 1] == '(' ? 1 : -1;
                if (currentPosition == basement) return movement;
            }

            return -1;
        }
    }
}
