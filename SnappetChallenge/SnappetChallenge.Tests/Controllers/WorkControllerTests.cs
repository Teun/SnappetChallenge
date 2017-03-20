using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Services;
using FluentAssertions;
using Services.Dto;
using System;

namespace SnappetChallenge.Controllers
{
    [TestClass]
    public class WorkControllerTests
    {
        private WorkController _sut;
        private Mock<ISubjectService> _workService;

        [TestInitialize]
        public void Initialize()
        {
            _workService = new Mock<ISubjectService>();

            _sut = new WorkController(_workService.Object);
        }

        [TestMethod]
        public void GetSubjects_ReturnsCurrentWork()
        {
            // Arrange
            var subject = new Subject();
            _workService
                .Setup(r => r.GetSubjects())
                .Returns(new[] { subject });

            // Act
            var result = _sut.GetSubjects();

            // Assert
            result.ShouldBeEquivalentTo(new[] { subject });
        }

        [TestMethod]
        public void GetSubject_WithName_ReturnsSubjectStatistics()
        {
            // Arrange
            const string subject = "Rekenen";
            var statistics = new SubjectStatistics();
            _workService
                .Setup(r => r.GetSubject(subject))
                .Returns(statistics);

            // Act
            var result = _sut.GetSubject(subject);

            // Assert
            result.Should().BeSameAs(statistics);
        }

        [TestMethod]
        public void GetSubject_WithNull_ThrowsException()
        {
            // Arrange
            const string subject = null;
            var statistics = new SubjectStatistics();
            _workService
                .Setup(r => r.GetSubject(subject))
                .Returns(statistics);

            // Act
            Action action = () => _sut.GetSubject(subject);

            // Assert
            action.ShouldThrow<ArgumentNullException>()
                .And.ParamName.Should().Be("subject");
        }
    }
}
