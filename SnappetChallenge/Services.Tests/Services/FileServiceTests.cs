using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Constants;
using FluentAssertions;
using System.IO;
using System.Reflection;
using System;

namespace Services.Services
{
    [TestClass]
    public class FileServiceTests
    {
        private readonly FileService _sut;
        private readonly IConfigurationRoot _configuration;

        public FileServiceTests()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            _configuration = builder.Build();

            _sut = new FileService();
        }

        [TestMethod]
        public void GetTextReader_WithPath_ReturnsTextReader()
        {
            // Arrange
            var testPath = GetCurrentDirectory();
            var path = Path.Combine(testPath, _configuration.GetSection(AppSettings.WorkFile).Value);

            // Act
            var result =_sut.GetTextReader(path);

            // Assert
            result.Should().NotBeNull();
        }

        [TestMethod]
        public void GetTextReader_WithPathNull_ThrowsException()
        {
            // Arrange
            var path = string.Empty;

            // Act
            Action action = () => _sut.GetTextReader(path);

            // Assert
            action.ShouldThrow<ArgumentNullException>()
                .And.ParamName.Should().Be("path");
        }

        public string GetCurrentDirectory()
        {
            var location = GetType().GetTypeInfo().Assembly.Location;
            return Path.GetDirectoryName(location);
        }
    }
}
