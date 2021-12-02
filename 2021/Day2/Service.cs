using Common;

namespace Day2
{
    public class Service : IService
    {
        private readonly Submarine _submarine;

        public Service(NavigationData navigationData)
        {
            _submarine = new Submarine(navigationData.GetMovements());
        }

        public object RunTask1()
        {
            var simplePosition = _submarine.MoveSimple();
            return simplePosition.depth * simplePosition.forward;
        }

        public object RunTask2()
        {
            var aimedPosition = _submarine.MoveWithAiming();
            return aimedPosition.depth * aimedPosition.forward;
        }
    }
}
