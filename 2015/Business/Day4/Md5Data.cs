namespace Business.Day4
{
    public class Md5Data : IData
    {
        public string Source { get; set; }

        public Md5Data()
        {
            Source = Input;
        }
        
        private const string Input = @"ckczppom";
    }
}