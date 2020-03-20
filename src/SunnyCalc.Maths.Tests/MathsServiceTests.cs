using NUnit.Framework;

namespace SunnyCalc.Maths.Tests
{
    [TestFixture]
    public class MathsServiceTests
    {
        private IMathsService _service;
        
        [SetUp]
        public void Setup()
        {
            _service = new MathsService();
        }

        [Test]
        public void IntegerSum([Range(-10, 10)] int a, [Range(-10, 10)] int b)
        {
            var expectedSum = a + b;
            var serviceSum = _service.Sum(a, b);
            Assert.That(serviceSum, Is.EqualTo(expectedSum));
        }
    }
}
