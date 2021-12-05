namespace Business.Day3
{
    public class Service : IService
    {
        private readonly Navigation _navigation;

        public Service(NavigationData navigationData)
        {
            _navigation = new Navigation(navigationData);
        }

        public object RunTask1() => _navigation.VisitedHousesCount();

        public object RunTask2() => _navigation.VisitedHousesCount(2);
    }
}
