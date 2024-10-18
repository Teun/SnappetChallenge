using SnappetChallenge.Converters;
using System.Globalization;

namespace SnappetTests.Converters
{
    public class IntToStringConverterTests
    {
        private readonly IntToStringConverter _converter = new IntToStringConverter();

        [Theory]
        [InlineData(0, "No")]
        [InlineData(1, "Yes")]
        [InlineData(2, "Unknown")]
        [InlineData(-1, "Unknown")]
        [InlineData(100, "Unknown")]
        public void Convert_ShouldReturnExpectedString_WhenIntegerValueIsPassed(int inputValue, string expected)
        {
            // Arrange
            var culture = CultureInfo.InvariantCulture;

            // Act
            var result = _converter.Convert(inputValue, typeof(string), null, culture);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Convert_ShouldReturnEmptyString_WhenNonIntegerValueIsPassed()
        {
            // Arrange
            var nonIntegerValue = "string value";
            var culture = CultureInfo.InvariantCulture;

            // Act
            var result = _converter.Convert(nonIntegerValue, typeof(string), null, culture);

            // Assert
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void ConvertBack_ShouldThrowNotImplementedException()
        {
            // Act & Assert
            Assert.Throws<NotImplementedException>(() => _converter.ConvertBack(null, typeof(int), null, CultureInfo.InvariantCulture));
        }
    }
}