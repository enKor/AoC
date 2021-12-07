namespace Business.Day1
{
    public class SonarSweepService : IService
    {
        private readonly Sonar _sonar;

        public SonarSweepService(SonarData sonarData)
        {
            _sonar = new Sonar(sonarData);
        }

        public object RunTask1() => _sonar.GetIncreasesCount();

        public object RunTask2() => _sonar.GetIncreasesWithNoiseCount();
    }
}
