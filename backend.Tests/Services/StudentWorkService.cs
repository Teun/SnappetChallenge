using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using backend.Models;
using backend.Services;
using Xunit;
using Xunit.Abstractions;

namespace backend.Tests
{
    public class StudentWorkServiceTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public StudentWorkServiceTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void GetStudentWorksBySubmitDateTime_Given6data_ShouldReturn4Data()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var jsonPath = Path.Combine(currentDirectory, "TestData", "datetime_filter_test_data.json");
            var studentWorkService = new StudentWorkService(jsonPath);

            DateTime testDateTime = DateTime.Parse("2015-03-24T11:30:00Z");

            var expectedListCount = 4;
            var actual = studentWorkService.GetStudentWorksBySubmitDateTime(testDateTime);

            Assert.NotNull(actual);
            Assert.Equal(expectedListCount, actual.Count());
        }

        [Fact]
        public void GetAverageProgressOfSubjectBySubmitDateTime_given2Subjects_returnAverage()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var jsonPath = Path.Combine(currentDirectory, "TestData", "test_group_by_subject.json");
            var studentWorkService = new StudentWorkService(jsonPath);

            DateTime testDateTime = DateTime.Parse("2015-03-24T11:30:00Z");

            var expected = new List<SubjectProgress>
            {
                new SubjectProgress
                {
                    Subject = "Begrijpend Lezen",
                    AverageProgress = -100,
                    IncorrectPercentage = 0
                },
                new SubjectProgress
                {
                    Subject = "historie",
                    AverageProgress = 5,
                    IncorrectPercentage = 0
                }
            };

            var actual = studentWorkService.GetAverageProgressOfSubjectBySubmitDateTime(testDateTime);
            Assert.NotNull(actual);
            Assert.Equal(expected.Count, actual.Count);
            
            // Assert the properties for each SubjectProgress object
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Subject, actual[i].Subject);
                Assert.Equal(expected[i].AverageProgress, actual[i].AverageProgress);
                Assert.Equal(expected[i].IncorrectPercentage, actual[i].IncorrectPercentage);
            }
        }

        [Fact]
        public void GetStudentPerformancesBySubmitDateTime_given3Students_return3Performances()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var jsonPath = Path.Combine(currentDirectory, "TestData", "test_student_performance.json");
            var studentWorkService = new StudentWorkService(jsonPath);

            DateTime testDateTime = DateTime.Parse("2015-03-24T11:30:00Z");

            var expected = new List<StudentPerformance>
            {
                new StudentPerformance
                {
                    UserId = 1,
                    CorrectSubmissions = 2,
                    IncorrectSubmissions = 0,
                    TotalProgress = 300
                },
                new StudentPerformance
                {
                    UserId = 2,
                    CorrectSubmissions = 0,
                    IncorrectSubmissions = 2,
                    TotalProgress = -500
                },
                new StudentPerformance
                {
                    UserId = 3,
                    CorrectSubmissions = 1,
                    IncorrectSubmissions = 1,
                    TotalProgress = 0
                }
            };

            var actual = studentWorkService.GetStudentPerformancesBySubmitDateTime(testDateTime);
            Assert.NotNull(actual);
            Assert.Equal(expected.Count, actual.Count);
            
            // Assert the properties for each SubjectProgress object
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].UserId, actual[i].UserId);
                Assert.Equal(expected[i].CorrectSubmissions, actual[i].CorrectSubmissions);
                Assert.Equal(expected[i].IncorrectSubmissions, actual[i].IncorrectSubmissions);
                Assert.Equal(expected[i].TotalProgress, actual[i].TotalProgress);
            }
        }
    }
}