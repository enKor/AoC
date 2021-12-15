using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Day15
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