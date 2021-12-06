namespace Business.Day2
{
    public class Service : IService
    {
        private readonly PackHelper _packHelper;

        public Service(PresentsData presentsData)
        {
            _packHelper = new PackHelper(presentsData);
        }

        public object RunTask1() => _packHelper.GetNecessaryPaper();

        public object RunTask2() => _packHelper.GetRibbonLength();
    }
}
