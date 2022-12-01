using Microsoft.AspNetCore.Mvc;
using Moq;
using TeacherApp.Controllers;
using TeacherApp.Models;

namespace TeacherApp.Tests
{
	public class HomeControllerTests
	{
		[Fact]
		public async Task Can_Use_RepositoryAsync()
		{
			// Arrange
			Mock<ITeacherAppRepository> mock = new Mock<ITeacherAppRepository>();
			mock.Setup(m => m.Works).Returns((new Work[]
			{
				new Work {
					SubmittedAnswerId=1,
					SubmitDateTime=DateTime.Parse("02/03/2015".ToString()),
					Correct=1,
					Progress=5,
					ExerciseId=10,
					UserId=1,
					Subject="Subject A"
				},
				new Work {
					SubmittedAnswerId=2,
					SubmitDateTime=DateTime.Parse("02/03/2015".ToString()),
					Correct=0,
					Progress=0,
					ExerciseId=11,
					UserId=1,
					Subject="Subject A"
				}
			}).AsQueryable<Work>());

			mock.Setup(m => m.Students).Returns((new Student[]
			{
				new Student
				{
					StudentId=1,
					Name="Student_1"
				},
			}).AsQueryable<Student>());

			HomeController controller = new HomeController(mock.Object);

			// Act
			ActionResult<List<Student>> result = await controller.GetStudents();

			// Assert
			Student[] students = result.Value.ToArray();
			Assert.True(students.Length == 1);
			Assert.Equal("Student_1", students[0].Name);
			Assert.Equal(1, students[0].StudentId);
		}
	}
}
