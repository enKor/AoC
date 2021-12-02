using Common;

namespace Day1
{
    public class Service : IService
    {
        private readonly Sonar _sonar;

        public Service()
        {
            _sonar = new Sonar(new SonarData());
        }

        public object RunTask1() => _sonar.GetIncreasesCount();

        public object RunTask2() => _sonar.GetIncreasesWithNoiseCount();
    }
}
