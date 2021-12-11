using System.Linq;

namespace Business.Day6
{
    public class Service : IService
    {
        private readonly CmdData _cmdData;

        public Service(CmdData cmdData)
        {
            _cmdData = cmdData;
        }

        public object RunTask1() => LightLights();

        public object RunTask2() => TotalBrightness();

        private long LightLights()
        {
            var cmds = _cmdData.GetCommands();
            var arr = new bool[1000, 1000];
            foreach (var cmd in cmds)
            {
                foreach (var point in cmd.GetVectors())
                {
                    arr[point.A - 1, point.B - 1] = cmd.GetValue(arr[point.A - 1, point.B - 1]);
                }
            }

            return arr.Cast<bool>().Count(b => b);
        }

        private long TotalBrightness()
        {
            var cmds = _cmdData.GetCommands();
            var arr = new int[1000, 1000];
            foreach (var cmd in cmds)
            {
                foreach (var point in cmd.GetVectors())
                {
                    arr[point.A - 1, point.B - 1] = cmd.GetBrightness(arr[point.A - 1, point.B - 1]);
                }
            }

            return arr.Cast<int>().Sum(b => b);
        }
    }
}
