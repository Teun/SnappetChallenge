using CsvHelper;
using Moq;
using SnappetChallenge.Models;
using SnappetChallenge.Services;
using System.Globalization;

namespace SnappetTests.Services
{
    public class AsyncEnumerable<T> : IAsyncEnumerable<T>
    {
        private readonly Exception _exception;

        public AsyncEnumerable(Exception exception)
        {
            _exception = exception;
        }

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new AsyncEnumerator<T>(_exception);
        }
    }

    public class AsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private bool _hasBeenEnumerated = false;
        private readonly Exception _exception;

        public AsyncEnumerator(Exception exception)
        {
            _exception = exception;
        }

        public ValueTask DisposeAsync() => ValueTask.CompletedTask;

        public ValueTask<bool> MoveNextAsync()
        {
            if (_hasBeenEnumerated)
            {
                return ValueTask.FromResult(false);
            }

            _hasBeenEnumerated = true;

            // Throw the exception on the first enumeration
            throw _exception;
        }

        public T Current => throw new InvalidOperationException("Enumeration has not started.");
    }

    public class CSVReaderTests
    {
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

        // Helper method to create an IAsyncEnumerable<T> that throws an exception
        private static IAsyncEnumerable<T> GetAsyncEnumerableThatThrows<T>(Exception exception)
        {
            return new AsyncEnumerable<T>(exception);
        }

        [Fact]
        public async Task ReadCSV_ShouldReturnRecords_WhenFileIsValid()
        {
            // Arrange
            string _filePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "TestData", "CorrectTestData.csv");

            var mockRecords = new List<WorkModel>
            {
                _comparisonWorkModel
            };

            var csvReaderMock = new Mock<ICSVReader<WorkModel>>();
            var csvReader = new CSVReader<WorkModel>();

            var mockStreamReader = new Mock<StreamReader>(_filePath);
            var mockCsvReader = new Mock<CsvReader>(mockStreamReader.Object, CultureInfo.InvariantCulture);

            mockCsvReader
                .Setup(r => r.GetRecordsAsync<WorkModel>(new CancellationToken()))
                .Returns(GetMockRecordsAsync(mockRecords));

            // Act
            var result = await csvReader.ReadCSV(_filePath);

            // Assert
            Assert.Equal(mockRecords.Count, result.Count());
            Assert.Equal(mockRecords[0].SubmittedAnswerId, result.First().SubmittedAnswerId);
        }

        [Fact]
        public async Task ReadCSV_ShouldHandleEmptyFileGracefully()
        {
            // Arrange
            string _filePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "TestData", "EmptyTestData.csv");

            var csvReaderMock = new Mock<ICSVReader<WorkModel>>();
            var csvReader = new CSVReader<WorkModel>();

            var mockStreamReader = new Mock<StreamReader>(_filePath);
            var mockCsvReader = new Mock<CsvReader>(mockStreamReader.Object, CultureInfo.InvariantCulture);

            mockCsvReader
                .Setup(r => r.GetRecordsAsync<WorkModel>(new CancellationToken()))
                .Returns(GetMockRecordsAsync(new List<WorkModel>())); // No records

            // Act
            var result = await csvReader.ReadCSV(_filePath);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task ReadCSV_ShouldHandleException_WhenErrorOccurs()
        {
            // Arrange
            string _filePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "TestData", "InvalidTestData.csv");

            var csvReaderMock = new Mock<ICSVReader<WorkModel>>();
            var csvReader = new CSVReader<WorkModel>();

            var mockStreamReader = new Mock<StreamReader>(_filePath);
            var mockCsvReader = new Mock<CsvReader>(mockStreamReader.Object, CultureInfo.InvariantCulture);

            var asyncEnumerable = GetAsyncEnumerableThatThrows<WorkModel>(new IOException("File not found"));

            var x = mockCsvReader
                .Setup(r => r.GetRecordsAsync<WorkModel>(new CancellationToken()))
                .Returns(asyncEnumerable);

            // Act & Assert
            var result = await csvReader.ReadCSV(_filePath);

            // The method should return an empty list and not throw an exception
            Assert.Empty(result);
        }

        private async IAsyncEnumerable<T> GetMockRecordsAsync<T>(IEnumerable<T> records)
        {
            foreach (var record in records)
            {
                yield return record;
            }
        }
    }
}