using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Entities;
using Services.Repositories;
using System;
using FluentAssertions;
using Services.Dto;

namespace Services.Services
{
    [TestClass]
    public class SubjectServiceTests
    {
        private SubjectService _sut;

        private Mock<IDateTimeService> _dateTimeService;
        private Mock<IWorkRepository> _workRepository;

        [TestInitialize]
        public void Initialize()
        {
            _workRepository = new Mock<IWorkRepository>();
            _dateTimeService = new Mock<IDateTimeService>();

            _sut = new SubjectService(_workRepository.Object, _dateTimeService.Object);
        }

        [TestMethod]
        public void GetSubjects_WithWorkForSameSubject_ReturnsDistinctSubject()
        {
            // Arrange
            var currentDateTime = new DateTime(2015, 03, 24, 11, 30, 00, DateTimeKind.Utc);

            _dateTimeService
                .Setup(s => s.GetCurrent())
                .Returns(currentDateTime);

            const string subject = "Rekenen";
            const string domain1 = "Meten";
            const string domain2 = "Getallen";
            _workRepository
                .Setup(r => r.GetCurrentWork(currentDateTime))
                .Returns(new[]
                {
                    new Work
                    {
                        Subject = subject,
                        Domain = domain1,
                        Progress = 50

                    },
                    new Work
                    {
                        Subject = subject,
                        Domain = domain2,
                        Progress = 25
                    },
                    new Work
                    {
                        Subject = subject,
                        Domain = domain1,
                        Progress = 100
                    }
                });

            // Act
            var result = _sut.GetSubjects();

            // Assert
            result.ShouldAllBeEquivalentTo(new[]
            {
                new Subject
                {
                    Name = subject,
                    Domains = new [] { domain2, domain1 },
                    AverageProgress = 58
                }
            }, o => o.WithStrictOrdering());
        }

        [TestMethod]
        public void GetSubjects_WithWorkForMultipleSubjects_ReturnsOrderedSubjects()
        {
            // Arrange
            var currentDateTime = new DateTime(2015, 03, 24, 11, 30, 00, DateTimeKind.Utc);

            _dateTimeService
                .Setup(s => s.GetCurrent())
                .Returns(currentDateTime);

            const string subject1 = "Spelling";
            const string subject2 = "Rekenen";
            const string domain1 = "Taalverzorging";
            const string domain2 = "Getallen";
            _workRepository
                .Setup(r => r.GetCurrentWork(currentDateTime))
                .Returns(new[]
                {
                    new Work
                    {
                        Subject = subject1,
                        Domain = domain1,
                        Progress = 25
                    },
                    new Work
                    {
                        Subject = subject1,
                        Domain = domain1,
                        Progress = 50
                    },
                    new Work
                    {
                        Subject = subject2,
                        Domain = domain2,
                        Progress = 13
                    }
                });

            // Act
            var result = _sut.GetSubjects();

            // Assert
            result.ShouldAllBeEquivalentTo(new[]
            {
                new Subject
                {
                    Name = subject2,
                    Domains = new [] { domain2 },
                    AverageProgress = 13
                },
                new Subject
                {
                    Name = subject1,
                    Domains = new [] { domain1 },
                    AverageProgress = 38
                }
            }, o => o.WithStrictOrdering());
        }

        [TestMethod]
        public void GetSubject_WithSubject_ReturnsStatistics()
        {
            // Arrange
            var currentDateTime = new DateTime(2015, 03, 24, 11, 30, 00, DateTimeKind.Utc);

            _dateTimeService
                .Setup(s => s.GetCurrent())
                .Returns(currentDateTime);

            const string subject = "Rekenen";
            const string domain = "Meten";
            const string learningObjective = "Kennis over bewerkingen";
            _workRepository
                .Setup(r => r.GetCurrentWork(currentDateTime))
                .Returns(new[]
                {
                    new Work
                    {
                        Subject = subject,
                        Domain = domain,
                        LearningObjective = learningObjective,
                        Correct = true,
                        Progress = 50,
                        Difficulty = "10"

                    },
                    new Work
                    {
                        Subject = subject,
                        Domain = domain,
                        LearningObjective = learningObjective,
                        Correct = false,
                        Progress = -25,
                        Difficulty = "20"
                    },
                    new Work
                    {
                        Subject = subject,
                        Domain = domain,
                        LearningObjective = learningObjective,
                        Correct = true,
                        Progress = 100,
                        Difficulty = "30"
                    }
                });

            // Act
            var result = _sut.GetSubject(subject);

            // Assert
            result.ShouldBeEquivalentTo(new SubjectStatistics
            {
                Name = subject,
                Domains = new []
                {
                    new DomainStatistics
                    {
                        Name = domain,
                        LearningObjectives = new []
                        {
                            new LearningObjectiveStatistics
                            {
                                Name = learningObjective,
                                TotalCount = 3,
                                CorrectCount = 2,
                                IncorrectCount = 1,
                                AverageProgress = 42,
                                AverageDifficulty = 20
                            }
                        }
                    }
                }
            }, o => o.WithStrictOrdering());
        }

        [TestMethod]
        public void GetSubject_WithNull_ThrowsException()
        {
            // Arrange
            const string subject = null;

            // Act
            Action action = () => _sut.GetSubject(subject);

            // Assert
            action.ShouldThrow<ArgumentNullException>()
                .And.ParamName.Should().Be("subject");
        }
    }
}
