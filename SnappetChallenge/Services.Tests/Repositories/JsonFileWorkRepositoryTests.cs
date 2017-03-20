using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Constants;
using Services.Services;
using System;
using System.IO;
using FluentAssertions;
using Services.Entities;

namespace Services.Repositories
{
    [TestClass]
    public class JsonFileWorkRepositoryTests
    {
        private Mock<IConfigurationRoot> _configurationRoot;
        private Mock<IConfigurationSection> _configurationSection;
        private Mock<IFileService> _fileService;

        private JsonFileWorkRepository _sut;

        [TestInitialize]
        public void Initialize()
        {
            _configurationRoot = new Mock<IConfigurationRoot>();
            _configurationSection = new Mock<IConfigurationSection>();
            _fileService = new Mock<IFileService>();

            _sut = new JsonFileWorkRepository(_configurationRoot.Object, _fileService.Object);
        }

        [TestMethod]
        public void GetAllWork_ReturnsAllWork()
        {
            // Arrange
            const string testFile = "test.json";
            _configurationSection
                .Setup(c => c.Value)
                .Returns(testFile);

            _configurationRoot
                .Setup(s => s.GetSection(AppSettings.WorkFile))
                .Returns(_configurationSection.Object);

            using (var testTextReader = new StringReader(TestResources.SampleJsonWork))
            {
                _fileService
                    .Setup(s => s.GetTextReader(testFile))
                    .Returns(testTextReader);

                // Act
                var result = _sut.GetAllWork();

                // Assert
                result.ShouldAllBeEquivalentTo(new[]
                {
                    new Work
                    {
                        SubmittedAnswerId = 61717849,
                        SubmitDateTime = new DateTime(2015, 03, 23, 08, 24, 44, 420, DateTimeKind.Utc),
                        Correct = true,
                        Progress = 7,
                        UserId = 68421,
                        ExerciseId = 389764,
                        Difficulty = "216.4190329",
                        Subject = "Rekenen",
                        Domain = "Getallen",
                        LearningObjective = "Afronden op hele getallen"
                    },
                    new Work
                    {
                        SubmittedAnswerId = 69399577,
                        SubmitDateTime = new DateTime(2015, 03, 24, 11, 29, 58, 530, DateTimeKind.Utc),
                        Correct = true,
                        Progress = 0,
                        UserId = 40282,
                        ExerciseId = 392536,
                        Difficulty = "211.9584245",
                        Subject = "Spelling",
                        Domain = "Taalverzorging",
                        LearningObjective = "woorden eindigend op -d of -t"
                    },
                    new Work
                    {
                        SubmittedAnswerId = 69399737,
                        SubmitDateTime = new DateTime(2015, 03, 24, 11, 30, 05, 130, DateTimeKind.Utc),
                        Correct = false,
                        Progress = -10,
                        UserId = 40282,
                        ExerciseId = 392537,
                        Difficulty = "294.5562315",
                        Subject = "Spelling",
                        Domain = "Taalverzorging",
                        LearningObjective = "woorden eindigend op -d of -t"
                    }
                });
            }
        }

        [TestMethod]
        public void GetCurrentWork_WithTimestamp_ReturnsCurrentWork()
        {
            // Arrange
            var timestamp = new DateTime(2015, 03, 24, 11, 30, 00, DateTimeKind.Utc);

            const string testFile = "test.json";
            _configurationSection
                .Setup(c => c.Value)
                .Returns(testFile);

            _configurationRoot
                .Setup(s => s.GetSection(AppSettings.WorkFile))
                .Returns(_configurationSection.Object);

            using (var testTextReader = new StringReader(TestResources.SampleJsonWork))
            {
                _fileService
                    .Setup(s => s.GetTextReader(testFile))
                    .Returns(testTextReader);

                // Act
                var result = _sut.GetCurrentWork(timestamp);

                // Assert
                result.ShouldAllBeEquivalentTo(new[]
                {
                    new Work
                    {
                        SubmittedAnswerId = 69399577,
                        SubmitDateTime = new DateTime(2015, 03, 24, 11, 29, 58, 530, DateTimeKind.Utc),
                        Correct = true,
                        Progress = 0,
                        UserId = 40282,
                        ExerciseId = 392536,
                        Difficulty = "211.9584245",
                        Subject = "Spelling",
                        Domain = "Taalverzorging",
                        LearningObjective = "woorden eindigend op -d of -t"
                    }
                });
            }
        }
    }
}
