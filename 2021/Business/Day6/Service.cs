namespace Business.Day6
{
    public class Service : IService
    {
        private readonly Day6Data _data;

        public Service(Day6Data data)
        {
            _data = data;
        }

        public object RunTask1() =>  -1;

        public object RunTask2() => -1;
    }
}
