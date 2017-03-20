using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Constants;
using System;
using FluentAssertions;

namespace Services.Services
{
    [TestClass]
    public class StubDateTimeServiceTests
    {
        private StubDateTimeService _sut;

        private Mock<IConfigurationRoot> _configurationRoot;
        private Mock<IConfigurationSection> _configurationSection;

        [TestInitialize]
        public void Initialize()
        {
            _configurationRoot = new Mock<IConfigurationRoot>();
            _configurationSection = new Mock<IConfigurationSection>();

            _sut = new StubDateTimeService(_configurationRoot.Object);
        }

        [TestMethod]
        public void GetCurrent_WithStubCurrentDateTime_ReturnsStubCurrentDateTime()
        {
            // Arrange
            _configurationSection
                .Setup(c => c.Value)
                .Returns("2015-03-24T11:30:00");

            _configurationRoot
                .Setup(s => s.GetSection(AppSettings.StubCurrentDateTime))
                .Returns(_configurationSection.Object);

            // Act
            var result = _sut.GetCurrent();

            // Assert
            var currentDateTime = new DateTime(2015, 03, 24, 11, 30, 00, DateTimeKind.Utc);
            result.Should().Be(currentDateTime);
        }
    }
}
