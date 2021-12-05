namespace Business.Day4
{
    public class Service : IService
    {
        private readonly Md5Processor _md5Processor;

        public Service(Md5Data md5Data)
        {
            _md5Processor = new Md5Processor(md5Data);
        }

        public object RunTask1() => _md5Processor.IterationToStartWith("00000");

        public object RunTask2() => _md5Processor.IterationToStartWith("000000");
    }
}
