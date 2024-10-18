using Moq;
using SnappetChallenge.Models;
using SnappetChallenge.Repositories;
using SnappetChallenge.Services;

namespace SnappetTests.Repositories
{
    public class WorkRepositoryTests
    {
        private readonly Mock<ICSVReader<WorkModel>> _csvReaderMock;
        private readonly WorkRepository _repository;
        private static WorkModel _comparisonWorkModel =
            new WorkModel
            {
                SubmitDateTime = new DateTime(2015, 3, 2, 7, 35, 38, 740),
                SubmittedAnswerId = 2395278,
                Progress = 0,
                Correct = 1,
                UserId = 40281,
                Difficulty = "-200",
                Subject = "Begrijpend",
                Domain = "-",
                LearningObjective = "Diverse leerdoelen Begrijpend Lezen"
            };

        public WorkRepositoryTests()
        {
            _csvReaderMock = new Mock<ICSVReader<WorkModel>>();
            _repository = new WorkRepository();
        }

        [Fact]
        public async Task GetAllStudentWork_ShouldReturnFilteredWorkModels_WhenSubmitDateTimeIsInThePast()
        {
            // Arrange
            string _filePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "TestData", "CorrectTestData.csv");

            var mockData = new List<WorkModel>
            {
                _comparisonWorkModel
            };

            _csvReaderMock
                .Setup(reader => reader.ReadCSV(_filePath))
                .ReturnsAsync(mockData);

            // Act
            var result = await _repository.GetAllStudentWork(_filePath);

            // Assert
            Assert.Single(result); // Only one item should be returned
            Assert.Equal(mockData[0].SubmitDateTime, result[0].SubmitDateTime); // Ensure the past-dated item is returned
        }

        [Fact]
        public async Task GetAllStudentWork_ShouldReturnEmptyList_WhenNoValidWorkModels()
        {
            // Arrange
            string _filePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "TestData", "FutureDateTestData.csv");

            // Act
            var result = await _repository.GetAllStudentWork(_filePath);

            // Assert
            Assert.Empty(result); // No work models should be returned
        }
    }
}