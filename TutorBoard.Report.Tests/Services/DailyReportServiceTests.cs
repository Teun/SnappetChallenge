using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorBoard.Dal.Models;
using TutorBoard.Dal.Repositories;
using TutorBoard.Report.Services;
using Xunit;

namespace TutorBoard.Report.Tests.Services
{
    public class DailyReportServiceTests
    {
        private IEnumerable<Subject> _testSubjects;
        private IEnumerable<User> _testUsers;
        private IEnumerable<UserProgress> _testUserProgresses;

        public DailyReportServiceTests()
        {
            _testSubjects = new List<Subject>
            {
                new Subject {Label = "Subject 1"},
                new Subject {Label = "Subject 2"}
            };
            _testUsers = new List<User>
            {
                new User { UserId = 1, Name = "User 1"},
                new User { UserId = 2, Name = "User 2"},
                new User { UserId = 3, Name = "User 3"}
            };
            _testUserProgresses = new List<UserProgress>
            {
                new UserProgress { UserId = 1, Progress = 4},
                new UserProgress { UserId = 2, Progress = -3}
            };
        }

        [Fact]
        public async Task TestCreateDailyReportAsync()
        {
            var date = new DateTime();

            var workResultRepositoryMock = new Mock<IWorkResultRepository>();
            var subjectRepositoryMock = new Mock<ISubjectRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();

            // Setup
            subjectRepositoryMock.Setup(r => r.GetAsync()).Returns(Task.FromResult(_testSubjects));

            workResultRepositoryMock.Setup(r => r.CountExercisesAsync(date)).Returns(Task.FromResult(45));
            workResultRepositoryMock.Setup(r => r.CountExercisesForSubjectAsync(date, "Subject 1")).Returns(Task.FromResult(15));
            workResultRepositoryMock.Setup(r => r.CountExercisesForSubjectAsync(date, "Subject 2")).Returns(Task.FromResult(30));
            workResultRepositoryMock.Setup(r => r.GetUserProgressAsync(date)).Returns(Task.FromResult(_testUserProgresses));

            userRepositoryMock.Setup(r => r.GetAsync()).Returns(Task.FromResult(_testUsers));
            
            var service = new DailyReportService(workResultRepositoryMock.Object, subjectRepositoryMock.Object, userRepositoryMock.Object);

            // Act
            var result = await service.CreateDailyReportAsync(date);

            // Verify
            subjectRepositoryMock.Verify(r => r.GetAsync(), Times.Once);
            workResultRepositoryMock.Verify(r => r.CountExercisesAsync(date), Times.Once);
            workResultRepositoryMock.Verify(r => r.CountExercisesForSubjectAsync(date, "Subject 1"), Times.Once);
            workResultRepositoryMock.Verify(r => r.CountExercisesForSubjectAsync(date, "Subject 2"), Times.Once);
            workResultRepositoryMock.Verify(r => r.GetUserProgressAsync(date), Times.Once);

            userRepositoryMock.Verify(r => r.GetAsync(), Times.Once);

            Assert.NotNull(result);
            Assert.NotNull(result.EditedTasks);
            Assert.Equal(45, result.EditedTasks.Summary);
            Assert.Equal(2, result.EditedTasks.SubjectCounts.Count());

            var cS1 = result.EditedTasks.SubjectCounts.FirstOrDefault(sc => sc.Subject == "Subject 1");
            Assert.NotNull(cS1);
            Assert.Equal(15, cS1.Count);

            Assert.NotNull(result.UserProgress);
            Assert.Equal(3, result.UserProgress.Count());
            Assert.True(result.UserProgress.Any(up => up.Progress == 4 && up.UserId == 1));
            Assert.True(result.UserProgress.Any(up => up.Progress == -3 && up.UserId == 2));
            Assert.True(result.UserProgress.Any(up => up.Progress == 0 && up.UserId == 3));
        }

        [Fact]
        public async Task CreateEditedTasksReportAsync()
        {
            var date = new DateTime();

            var workResultRepositoryMock = new Mock<IWorkResultRepository>();
            var subjectRepositoryMock = new Mock<ISubjectRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();

            // Setup
            subjectRepositoryMock.Setup(r => r.GetAsync()).Returns(Task.FromResult(_testSubjects));
            workResultRepositoryMock.Setup(r => r.CountExercisesAsync(date)).Returns(Task.FromResult(45));
            workResultRepositoryMock.Setup(r => r.CountExercisesForSubjectAsync(date, "Subject 1")).Returns(Task.FromResult(15));
            workResultRepositoryMock.Setup(r => r.CountExercisesForSubjectAsync(date, "Subject 2")).Returns(Task.FromResult(30));

            var service = new DailyReportService(workResultRepositoryMock.Object, subjectRepositoryMock.Object, userRepositoryMock.Object);

            // Act
            var result = await service.CreateEditedTasksReportAsync(date);

            // Verify
            subjectRepositoryMock.Verify(c => c.GetAsync(), Times.Once);
            workResultRepositoryMock.Verify(r => r.CountExercisesAsync(date), Times.Once);
            workResultRepositoryMock.Verify(r => r.CountExercisesForSubjectAsync(date, "Subject 1"), Times.Once);
            workResultRepositoryMock.Verify(r => r.CountExercisesForSubjectAsync(date, "Subject 2"), Times.Once);

            Assert.NotNull(result);
            Assert.Equal(45, result.Summary);
            Assert.Equal(2, result.SubjectCounts.Count());

            var cS1 = result.SubjectCounts.FirstOrDefault(sc => sc.Subject == "Subject 1");
            Assert.NotNull(cS1);
            Assert.Equal(15, cS1.Count);
        }

        [Fact]
        public async Task TestCreateUserProgressReportsAsync()
        {
            var date = new DateTime();

            var workResultRepositoryMock = new Mock<IWorkResultRepository>();
            var subjectRepositoryMock = new Mock<ISubjectRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();

            // Setup
            workResultRepositoryMock.Setup(r => r.GetUserProgressAsync(date)).Returns(Task.FromResult(_testUserProgresses));

            userRepositoryMock.Setup(r => r.GetAsync()).Returns(Task.FromResult(_testUsers));

            var service = new DailyReportService(workResultRepositoryMock.Object, subjectRepositoryMock.Object, userRepositoryMock.Object);

            // Act
            var result = await service.CreateUserProgressReportsAsync(date);

            // Verify
            workResultRepositoryMock.Verify(r => r.GetUserProgressAsync(date), Times.Once);

            userRepositoryMock.Verify(r => r.GetAsync(), Times.Once);

            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
            
            Assert.True(result.Any(up => up.Progress == 4 && up.UserId == 1));
            Assert.True(result.Any(up => up.Progress == -3 && up.UserId == 2));
            Assert.True(result.Any(up => up.Progress == 0 && up.UserId == 3));
        }
    }
}
