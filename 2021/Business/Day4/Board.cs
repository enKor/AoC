using System.Collections.Generic;
using System.Linq;

namespace Business.Day4
{
    public class Board
    {
        public bool Done { get; private set; }

        public class Item
        {
            public int Number { get; set; }
            public bool Marked { get; set; }
        }

        private readonly List<Item[]> _numbers;

        public Board()
        {
            _numbers = new List<Item[]>();
        }

        public void AddRow(IEnumerable<int> numbers)
        {
            var checkableNumbers = numbers.Select(x => new Item{Number=x}).ToArray();
            _numbers.Add(checkableNumbers);
        }

        public Item[][] GetNumbers() => _numbers.ToArray();

        public bool ProcessCall(int n)
        {
            foreach (var row in _numbers)
            {
                foreach (var item in row)
                {
                    if (item.Number == n) item.Marked = true;
                }
            }

            if (IsBingo())
            {
                Done = true;
                return true;
            }

            return false;
        }

        private bool IsBingo()
        {
            foreach (var row in _numbers)
            {
                if (row.All(x => x.Marked)) 
                    return true;
            }

            for (int column = 0; column < _numbers[0].Length; column++)
            {
                if (_numbers.Select(x => x[column]).All(x => x.Marked)) 
                    return true;
            }

            return false;
        }
    }
}