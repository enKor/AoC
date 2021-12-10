namespace Business.Day25
{
    public class Service : IService
    {
        private readonly Data _data;

        public Service(Data data)
        {
            _data = data;
        }

        public object RunTask1() => GetCode();

        public object RunTask2() => -1;


        private static long GetCode()
        {
            const int row = 2981, col = 3075;
            var reminder = 20151125L;

            long currentRow = 2, currentColumn = 1;
            while (true)
            {
                //Console.WriteLine($"R{currentRow},C{currentColumn}");

                // process
                reminder = reminder * 252533L % 33554393;

                // check
                if (currentRow == row && currentColumn == col)
                {
                    return reminder;
                }

                // move cursor
                if (currentRow == 1)
                {
                    currentRow = currentColumn + 1;
                    currentColumn = 1;
                }
                else
                {
                    currentColumn++;
                    currentRow--;
                }





            }


        }
    }
}
