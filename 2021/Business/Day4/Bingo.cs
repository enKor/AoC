using System.Collections.Generic;
using System.Linq;

namespace Business.Day4
{
    public class Bingo
    {
        private readonly IEnumerable<Board> _boards;
        private readonly IEnumerable<int> _numbers;

        public Bingo(IEnumerable<int> numbers, IEnumerable<Board> boards)
        {
            _boards = boards;
            _numbers = numbers;
        }

        public int GetWinnerBoard()
        {
            foreach (var number in _numbers)
            {
                foreach (var board in _boards)
                {
                    var isWinner = board.ProcessCall(number);
                    if (isWinner)
                    {
                        return CalculateResult(board, number);
                    }
                }
            }
            
            return -1;
        }
        
        public int GetLooserBoard()
        {
            var list = new List<(Board,int)>();
            foreach (var number in _numbers)
            {
                foreach (var board in _boards)
                {
                    if (board.Done) continue;

                    var isWinner = board.ProcessCall(number);
                    if (isWinner)
                    {
                        list.Add((board,number));
                    }
                }
            }

            var looser = list.Last();
            return CalculateResult(looser.Item1, looser.Item2);
        }

        private static int CalculateResult(Board board, int number)
        {
            var sum = board.GetNumbers()
                .SelectMany(x => x)
                .Where(x => !x.Marked)
                .Sum(x => x.Number);
            return number * sum;
        }
    }
}