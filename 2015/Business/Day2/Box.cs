using System.Linq;

namespace Business.Day2
{
    public record Box
    {
        public Box(int length, int width, int height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public int Length { get; init; }
        public int Width { get; init; }
        public int Height { get; init; }

        private static int GetFaceSurfaceArea(int a, int b) => a * b;

        public int GetPrismSurfaceArea() =>
            new[]
            {
                GetFaceSurfaceArea(Length, Width),
                GetFaceSurfaceArea(Width, Height),
                GetFaceSurfaceArea(Height, Length)
            }.Sum() * 2;

        public int GetSmallestFaceSurfaceArea()
        {
            return new[] {Height, Width, Length}
                .OrderBy(x => x)
                .Take(2)
                .Aggregate(1, (a, b) => a * b);
        }

        public int GetVolume() => Width * Height * Length;

    }
}