using SnappetChallenge.Models;
using SnappetChallenge.ViewModels;

namespace SnappetTests.ViewModels
{
    public class IndividualStudentDetailsViewModelTests
    {
        [Fact]
        public void Constructor_ShouldInitializeStudent_WhenCalledWithValidStudent()
        {
            // Arrange
            var expectedStudent = new StudentData
            {
                UserId = 1
                // Add other properties as needed
            };

            // Act
            var viewModel = new IndividualStudentDetailsViewModel(expectedStudent);

            // Assert
            Assert.NotNull(viewModel.Student); // Ensure the student is not null
            Assert.Equal(expectedStudent.UserId, viewModel.Student.UserId); // Ensure the correct Id is set
        }
    }
}