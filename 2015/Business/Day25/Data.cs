using System;
using System.Collections.Generic;

namespace Business.Day25
{
    public class Data  : IData
    {
        public string Source { get; set; }

        public Data()
        {
            Source = Input;
        }

        private const string Input = @"";
    }
}