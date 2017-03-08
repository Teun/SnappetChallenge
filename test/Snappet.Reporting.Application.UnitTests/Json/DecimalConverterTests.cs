using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Snappet.Reporting.Application.Json;
using Xunit;

namespace Snappet.Reporting.Application.UnitTests
{
    public class DecimalConverterTests
    {
        private readonly Mock<JsonReader> _readerMock;
        private readonly DecimalConverter _target;

        public DecimalConverterTests()
        {
            var loggerFactory = new LoggerFactory();
            _readerMock = new Mock<JsonReader>();
            _target = new DecimalConverter(loggerFactory);
        }

        [Fact]
        public void ReadJson_WithNoValue_Returns0()
        {
            _readerMock.SetupGet(x => x.Value).Returns(null);

            var actual = _target.ReadJson(_readerMock.Object, null, null, null);

            Assert.Equal(0.0, actual);
        }

        [Fact]
        public void ReadJson_WithNullValue_Returns0()
        {
            _readerMock.SetupGet(x => x.Value).Returns("NULL");

            var actual = _target.ReadJson(_readerMock.Object, null, null, null);

            Assert.Equal(0.0, actual);
        }

        [Fact]
        public void ReadJson_WithValidDecimalValue_ReturnsDecimal()
        {
            var loggerFactory = new LoggerFactory();
            var readerMock = new Mock<JsonReader>();
            var expected = 100.0;

            readerMock.SetupGet(x => x.Value).Returns(expected);
            var target = new DecimalConverter(loggerFactory);

            var actual = target.ReadJson(readerMock.Object, typeof(string), null, null);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadJson_WithNoDecimalValue_ThrowsException()
        {
            var noDecimal = "No decimal";
            _readerMock.SetupGet(x => x.Value).Returns(noDecimal);

            var actual = Assert.Throws<JsonSerializationException>(() => _target.ReadJson(_readerMock.Object, null, null, null));
            Assert.Contains(noDecimal, actual.Message);
        }

        [Fact]
        public void CanConvert_Double_ReturnsTrue()
        {
            var actual = _target.CanConvert(typeof(double));
            Assert.True(actual);
        }

        [Fact]
        public void CanConvert_NullableDouble_ReturnsTrue()
        {
            var actual = _target.CanConvert(typeof(double?));
            Assert.True(actual);
        }
    }
}
