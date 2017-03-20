using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Services.Parsers
{
    [TestClass]
    public class DifficultyParserTests
    {
        [TestMethod]
        public void Parse_WithValueNull_returnsNull()
        {
            // Arrange
            const string difficulty = "NULL";

            // Act
            var result = DifficultyParser.Parse(difficulty);

            // Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void Parse_WithValidValue_returnsDecimalValue()
        {
            // Arrange
            const string difficulty = "123.456";

            // Act
            var result = DifficultyParser.Parse(difficulty);

            // Assert
            result.Should().Be(123.456m);
        }

        [TestMethod]
        public void Parse_WithInvalidValue_returnsDecimalValue()
        {
            // Arrange
            const string difficulty = "ERROR";

            // Act
            var result = DifficultyParser.Parse(difficulty);

            // Assert
            result.Should().BeNull();
        }
    }
}
