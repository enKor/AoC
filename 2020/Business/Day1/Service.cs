namespace Business.Day1
{
    public class Service : IService
    {
        private readonly Lift _lift;

        public Service(LiftData liftData)
        {
            _lift = new Lift(liftData);
        }

        public object RunTask1() => _lift.GetFloor();

        public object RunTask2() => _lift.GetBasementMovementPosition();
    }
}
