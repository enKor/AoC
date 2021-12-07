namespace Business.Day3
{
    public class BinaryDiagnosticService : IService
    {
        private readonly DiagnosticDevice _diagnosticDevice;

        public BinaryDiagnosticService(DiagnosticsData data)
        {
            _diagnosticDevice = new DiagnosticDevice(data.GetBinaries());
        }

        public object RunTask1() => _diagnosticDevice.GetConsumption();

        public object RunTask2() => _diagnosticDevice.GetLifeSupportRating();
    }
}
