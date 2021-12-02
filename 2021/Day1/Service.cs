using Common;

namespace Day1
{
    public class Service : IService
    {
        private readonly Sonar _sonar;

        public Service(SonarData sonarData)
        {
            _sonar = new Sonar(sonarData);
        }

        public object RunTask1() => _sonar.GetIncreasesCount();

        public object RunTask2() => _sonar.GetIncreasesWithNoiseCount();
    }
}
