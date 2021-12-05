using System.Linq;

namespace Business.Day2
{
    public class PackHelper
    {
        private readonly PresentsData _presentsData;

        public PackHelper(PresentsData presentsData)
        {
            _presentsData = presentsData;
        }

        public int GetNecessaryPaper() => _presentsData.GetDimensions()
            .Select(x => x.GetPrismSurfaceArea() + x.GetSmallestFaceSurfaceArea())
            .Sum();

        public int GetRibbonLength() =>
            _presentsData.GetDimensions()
                .Select(box =>
                {
                    var sides = new[] {box.Width, box.Height, box.Length}
                        .OrderBy(x => x)
                        .Take(2)
                        .ToArray();

                    var length = (sides[0] + sides[1]) * 2;
                    var volume = box.GetVolume();
                    return length + volume;
                })
                .Sum();
    }
}
