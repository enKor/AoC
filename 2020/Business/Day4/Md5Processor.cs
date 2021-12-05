using System.Security.Cryptography;
using System.Text;

namespace Business.Day4
{
    public class Md5Processor
    {
        private readonly Md5Data _md5Data;

        public Md5Processor(Md5Data md5Data)
        {
            _md5Data = md5Data;
        }

        public int IterationToStartWith(string startWith)
        {
            var i = 1;
            while (true)
            {
                var hash = GetMd5($"{_md5Data.Source}{i}");
                if (hash.StartsWith(startWith)) return i;
                i++;
            }
        }

        private static string GetMd5(string str)
        {
            var bytes = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(str));
            return ByteArrayToString(bytes);
        }

        private static string ByteArrayToString(byte[] bytes)
        {
            var output = new StringBuilder(bytes.Length);

            foreach (var t in bytes)
            {
                output.Append(t.ToString("X2"));
            }

            return output.ToString();
        }
    }
}