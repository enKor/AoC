using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Business.Day6
{
    public class Command
    {
        private static readonly Regex CmdRegex = new(@"^([a-z ]*) (\d*),(\d*) through (\d*),(\d*)$");

        private CommandType CommandType { get; }
        private Vector2 Start { get; }
        private Vector2 End { get; }

        public Command(string cmd)
        {
            var m = CmdRegex.Matches(cmd);

            var t = m[0].Groups[1].Value switch
            {
                "turn on" => CommandType.TurnOn,
                "turn off" => CommandType.TurnOff,
                "toggle" => CommandType.Toggle,
                _ => throw new ArgumentOutOfRangeException()
            };

            CommandType = t;
            Start = new Vector2(GetPosition(m, 2), GetPosition(m, 3));
            End = new Vector2(GetPosition(m, 4), GetPosition(m, 5));
        }

        private static int GetPosition(MatchCollection m, int grp) => Convert.ToInt32(m[0].Groups[grp].ToString());

        public IEnumerable<Vector2> GetVectors()
        {
            for (int a = Start.A; a <= End.A; a++)
            for (int b = Start.B; b <= End.B; b++)
            {
                yield return new Vector2(a, b);
            }
        }

        public bool GetValue(bool input) =>
            CommandType switch
            {
                CommandType.Toggle => !input,
                CommandType.TurnOn => true,
                CommandType.TurnOff => false,
                _ => throw new ArgumentOutOfRangeException()
            };

        public int GetBrightness(int input)
        {
            var i = CommandType switch
            {
                CommandType.Toggle => input + 2,
                CommandType.TurnOn => input + 1,
                CommandType.TurnOff => input - 1,
                _ => throw new ArgumentOutOfRangeException()
            };

            return i < 0 ? 0 : i;
        }
    }
}