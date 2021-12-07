namespace Business.Day8
{
    public class Service : IService
    {
        private readonly Day8Data _data;

        public Service(Day8Data data)
        {
            _data = data;
        }

        public object RunTask1() => -1;

        public object RunTask2() => -1;
    }
}