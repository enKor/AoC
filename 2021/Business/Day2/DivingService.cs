namespace Business.Day2
{
    public class DivingService : IService
    {
        private readonly Submarine _submarine;

        public DivingService(NavigationData navigationData)
        {
            _submarine = new Submarine(navigationData.GetMovements());
        }

        public object RunTask1()
        {
            var simplePosition = _submarine.MoveSimple();
            return (long)( simplePosition.depth * simplePosition.forward);
        }

        public object RunTask2()
        {
            var aimedPosition = _submarine.MoveWithAiming();
            return (long)(aimedPosition.depth * aimedPosition.forward);
        }
    }
}
