using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    internal static class Extender
    {
        public static IEnumerable<int> SelectNumbers(this string str, string splitter = "\r\n")
        {
            return str
                .Split(splitter, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => Convert.ToInt32(x));
        }
    }
}