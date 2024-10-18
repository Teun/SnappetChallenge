using SnappetChallenge.Converters;
using System.Globalization;
using System.Windows;

namespace SnappetTests.Converters
{
    public class BoolToVisibilityConverterTests
    {
        private readonly BoolToVisibilityConverter _converter;

        public BoolToVisibilityConverterTests()
        {
            _converter = new BoolToVisibilityConverter();
        }

        [Theory]
        [InlineData(true, null, Visibility.Collapsed)]
        [InlineData(false, null, Visibility.Visible)]
        public void Convert_NoParameter_ReturnsCorrectVisibility(bool booleanValue, bool? parameter, Visibility expected)
        {
            // Act
            var result = _converter.Convert(booleanValue, typeof(Visibility), parameter, CultureInfo.InvariantCulture);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, Visibility.Visible)]
        [InlineData(false, true, Visibility.Collapsed)]
        [InlineData(true, false, Visibility.Collapsed)]
        [InlineData(false, false, Visibility.Visible)]
        public void Convert_WithParameter_ReturnsCorrectVisibility(bool booleanValue, bool boolParameter, Visibility expected)
        {
            // Act
            var result = _converter.Convert(booleanValue, typeof(Visibility), boolParameter, CultureInfo.InvariantCulture);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(Visibility.Visible, true)]
        [InlineData(Visibility.Collapsed, false)]
        public void ConvertBack_ReturnsCorrectBoolean(Visibility visibility, bool expected)
        {
            // Act
            var result = _converter.ConvertBack(visibility, typeof(bool), null, CultureInfo.InvariantCulture);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Convert_InvalidValue_ReturnsCollapsed()
        {
            // Arrange
            var invalidValue = "Invalid";

            // Act
            var result = _converter.Convert(invalidValue, typeof(Visibility), null, CultureInfo.InvariantCulture);

            // Assert
            Assert.Equal(Visibility.Collapsed, result);
        }
    }
}