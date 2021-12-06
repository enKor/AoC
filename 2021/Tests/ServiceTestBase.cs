using Business;
using Xunit;

namespace Tests
{
    public abstract class ServiceTestBase
    {
        private readonly IService _service;
        private readonly long _result1;
        private readonly long _result2;

        protected ServiceTestBase(IService service, long result1, long result2)
        {
            _service = service;
            _result1 = result1;
            _result2 = result2;
        }
        
        [Fact]
        public void RunTask1_Method_Test()
        {
            var result = _service.RunTask1();
            Assert.Equal(_result1, result);
        }

        [Fact]
        public void RunTask2_Method_Test()
        {
            var result = _service.RunTask2();
            Assert.Equal(_result2, result);
        }
    }
}