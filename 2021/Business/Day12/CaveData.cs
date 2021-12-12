using System;
using System.Linq;

namespace Business.Day12
{
    public class CaveData : IData
    {
        public CaveData()
        {
            Source = SampleData;
        }

        public string Source { get; set; }

        public string[][] GetPairs() =>
            Source
                .Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Split("-", StringSplitOptions.RemoveEmptyEntries))
                .ToArray();


       private const string SampleData = @"EO-jc
end-tm
jy-FI
ek-EO
mg-ek
jc-jy
FI-start
jy-mg
mg-FI
jc-tm
end-EO
ds-EO
jy-start
tm-EO
mg-jc
ek-jc
tm-ek
FI-jc
jy-EO
ek-jy
ek-LT
start-mg";
    }
}