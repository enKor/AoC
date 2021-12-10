namespace Business.Day5
{
    public class Service : IService
    {
        private readonly Letter _letter;

        public Service(LetterData data)
        {
            _letter = new Letter(data);
        }

        public object RunTask1() => _letter.GetNiceWords().Count;

        public object RunTask2() => _letter.GetNicerWords().Count;
    }
}
