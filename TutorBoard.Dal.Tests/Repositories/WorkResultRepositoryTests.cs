using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorBoard.Dal.Data;
using TutorBoard.Dal.Dtos;
using TutorBoard.Dal.Repositories;
using Xunit;

namespace TutorBoard.Dal.Tests.Repositories
{
    public class WorkResultRepositoryTests
    {
        private IEnumerable<WorkDto> _testData;

        public WorkResultRepositoryTests()
        {
            _testData = new List<WorkDto>
            {
                new WorkDto {Subject = "Subject 1", ExerciseId = 1, UserId = 1, SubmitDateTime = new DateTime(2017, 1, 1)},
                new WorkDto {Subject = "Subject 1", ExerciseId = 1, UserId = 1, SubmitDateTime = new DateTime(2017, 1, 2)},
                new WorkDto {Subject = "Subject 1", ExerciseId = 2, UserId = 2, SubmitDateTime = new DateTime(2017, 1, 2)},
                new WorkDto {Subject = "Subject 1", ExerciseId = 1, UserId = 2, SubmitDateTime = new DateTime(2017, 1, 1)},
                new WorkDto {Subject = "Subject 2", ExerciseId = 3, UserId = 4, SubmitDateTime = new DateTime(2017, 1, 1)},
                new WorkDto {Subject = "Subject 1", ExerciseId = 1, UserId = 1, SubmitDateTime = new DateTime(2017, 1, 1)},
                new WorkDto {Subject = "Subject 1", ExerciseId = 1, UserId = 3, SubmitDateTime = new DateTime(2017, 1, 3)},
                new WorkDto {Subject = "Subject 2", ExerciseId = 3, UserId = 5, SubmitDateTime = new DateTime(2017, 1, 1)},
            };
        }

        [Fact]
        public async Task TestCountExercisesAsync()
        {
            var date = new DateTime(2017, 1, 1);

            var contextMock = new Mock<IDataContext>();

            // Setup
            contextMock.Setup(c => c.GetWorkData()).Returns(_testData);

            var repository = new WorkResultRepository(contextMock.Object);

            // Act
            var result = await repository.CountExercisesAsync(date);

            // Verify
            Assert.Equal(4, result);
        }

        [Fact]
        public async Task TestCountExercisesForSubjectAsync()
        {
            var date = new DateTime(2017, 1, 1);

            var contextMock = new Mock<IDataContext>();

            // Setup
            contextMock.Setup(c => c.GetWorkData()).Returns(_testData);

            var repository = new WorkResultRepository(contextMock.Object);

            // Act
            var result = await repository.CountExercisesForSubjectAsync(date, "Subject 1");

            // Verify
            Assert.Equal(2, result);

        }
    }
}
