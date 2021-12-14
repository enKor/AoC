using System;
using System.Linq;
using System.Text;

namespace Business.Day14
{
    public class ChemService : IService
    {
        private readonly PolymerData _data;

        public ChemService(PolymerData data)
        {
            _data = data;

        }

        public object RunTask1() => Calculation(10);

        public object RunTask2() => Calculation(40);

        private long Calculation(int rounds)
        {
            var formula = _data.GetFormula();
            var dic = _data.GetDictionary();

            for (int n = 0; n < rounds; n++)
            {
                Console.WriteLine(n);
                Console.WriteLine(formula);

                var newFormula = new StringBuilder();

                for (int i = 0; i < formula.Length - 1; i++)
                {

                    var pair = formula.Substring(i, 2);

                    if (i == 0) newFormula.Append(pair[0]);
                    newFormula.Append(dic[pair]);
                    newFormula.Append(pair[1]);
                }

                try
                {
                    formula = newFormula.ToString();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            var groups = formula
                .GroupBy(g => g)
                .Select(x => new { Letter = x.Key, Count = x.LongCount() })
                .ToArray();

            var min = groups.Min(x => x.Count);
            var max = groups.Max(x => x.Count);

            return max - min;
        }
    }
}