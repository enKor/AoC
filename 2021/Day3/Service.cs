using Common;

namespace Day3
{
    public class Service : IService
    {
        private readonly DiagnosticDevice _diagnosticDevice;

        public Service(DiagnosticsData data)
        {
            _diagnosticDevice = new DiagnosticDevice(data.GetBinaries());
        }

        public object RunTask1() => _diagnosticDevice.GetConsumption();

        public object RunTask2() => _diagnosticDevice.GetLifeSupportRating();
    }
}
