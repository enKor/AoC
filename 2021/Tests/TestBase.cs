using Business;
using Xunit;

namespace Tests
{
    public abstract class TestBase
    {
        private readonly IService _service;
        private readonly int _result1;
        private readonly int _result2;

        protected TestBase(IService service, int result1, int result2)
        {
            _service = service;
            _result1 = result1;
            _result2 = result2;
        }
        
        [Fact]
        public void Task1Test()
        {
            var result = _service.RunTask1();
            Assert.Equal(_result1, result);
        }

        [Fact]
        public void Task2Test()
        {
            var result = _service.RunTask2();
            Assert.Equal(_result2, result);
        }
    }
}