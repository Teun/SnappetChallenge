using FluentAssertions;
using SnappetChallenge.Repository.JsonConvertors;
using System;
using System.Text;
using System.Text.Json;
using Xunit;

namespace SnappetChallenge.Repository.Tests
{
    public class DateTimeTrimWhitespaceConverterTests
    {
        [Fact]
        public void GivenADateTimeStringWithTrailingWhitespaceWhenReadingThenItIsSuccessfullyConverted()
        {
            // Arrange
            var converter = new DateTimeTrimWhitespaceConverter();
                        
            var bytes = Encoding.UTF8.GetBytes("{\r\n \"SubmittedAnswerId\": \"2015-03-02T08:27:36    \" \r\n}");
            var readOnlySpan = new ReadOnlySpan<byte>(bytes);
            var reader = new Utf8JsonReader(readOnlySpan);
            DateTime readResult = DateTime.MinValue;

            // Act
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.String)
                {
                    readResult = converter.Read(ref reader, typeof(DateTime), new JsonSerializerOptions());
                    break;
                }
            }

            // Assert
            readResult.Should().Be(new DateTime(2015, 3, 2, 8, 27, 36));
        }
    }
}
