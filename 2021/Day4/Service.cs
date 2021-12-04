using Common;

namespace Day4
{
    public class Service : IService
    {
        private readonly BingoData _data;

        public Service(BingoData data)
        {
            _data = data;
        }

        public object RunTask1() => new Bingo(_data.GetNumbers(), _data.GetBoards()).GetWinnerBoard();

        public object RunTask2() => new Bingo(_data.GetNumbers(), _data.GetBoards()).GetLooserBoard();
    }
}
