using System.Linq;

namespace Business.Day8
{
    public record Connection
    {
        public Connection(string[] signals, string[] segments)
        {
            Signals = signals;
            Segments = segments.Select<string,(string,string)>(x => new (
                    x,
                    string.Join("", x.OrderBy(c => c))
                )
            ).ToArray();
        }

        public string[] Signals { get; init; }
        public (string orig, string ordered)[] Segments { get; init; }
        

    }
}