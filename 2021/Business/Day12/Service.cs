namespace Business.Day12
{
    public class Service : IService
    {
        private readonly Data _data;

        public Service(Data data)
        {
            _data = data;
        }

        public object RunTask1() => -1;

        public object RunTask2() => -1;
    }
}