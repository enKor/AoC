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
            var (plus, minus) = _liftData.GetFloors();
            return plus - minus;
        }
    }
}
