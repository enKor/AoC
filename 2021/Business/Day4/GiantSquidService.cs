namespace Business.Day4
{
    public class GiantSquidService : IService
    {
        private readonly BingoData _data;

        public GiantSquidService(BingoData data)
        {
            _data = data;
        }

        public object RunTask1() => new Bingo(_data.GetNumbers(), _data.GetBoards()).GetWinnerBoard();

        public object RunTask2() => new Bingo(_data.GetNumbers(), _data.GetBoards()).GetLooserBoard();
    }
}
