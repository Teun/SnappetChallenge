using Moq;
using SnappetChallenge.Models;
using SnappetChallenge.Repositories;
using SnappetChallenge.Services;
using SnappetChallenge.ViewModels;
using System.Collections.ObjectModel;


namespace SnappetTests.ViewModels
{
    public class MainWindowViewModelTests
    {
        private readonly Mock<IWorkRepository> _mockWorkRepository;
        private readonly Mock<IFileDialogService> _mockFileDialogService;
        private readonly MainWindowViewModel _viewModel;
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

        public MainWindowViewModelTests()
        {
            // Set up the view model with mocked dependencies
            _viewModel = new MainWindowViewModel();
            _mockWorkRepository = new Mock<IWorkRepository>();
            _mockFileDialogService = new Mock<IFileDialogService>();
        }

        [Fact]
        public void PreviousPage_ShouldDecreaseCurrentPage()
        {
            // Arrange
            _viewModel.CurrentPage = 2;

            // Act
            _viewModel.PreviousPageCommand.Execute(null);

            // Assert
            Assert.Equal(1, _viewModel.CurrentPage);
        }

        [Fact]
        public void NextPage_ShouldIncreaseCurrentPage()
        {
            // Arrange
            _viewModel.CurrentPage = 1;

            // Act
            _viewModel.NextPageCommand.Execute(null);

            // Assert
            Assert.Equal(2, _viewModel.CurrentPage);
        }

        [Fact]
        public void PopulateSubjectData_ShouldUpdateTotalCounts()
        {
            // Arrange
            var studentData = new ObservableCollection<StudentData>
        {
            new StudentData 
            { 
                UserId = 1,
                Subject = "Maths",
                Correct = 1, 
                Progress = 1
            },
            new StudentData 
            { 
                UserId = 2, 
                Subject = "Maths",
                Correct = 0,
                Progress = -1 
            },
            new StudentData 
            { 
                UserId = 1,
                Subject = "Maths",
                Correct = 0, 
                Progress = 0
            }
        };

            _viewModel.TodaysStudentData = studentData;
            
            // Act
            _viewModel.SelectedSubject = "Maths";

            // Assert
            Assert.Equal("Total number of students who submitted work in Maths today: 2", _viewModel.TotalStudents);
            Assert.Equal("Total number of students who submitted work that passed today: 1", _viewModel.TotalPass);
            Assert.Equal("Total number of students who submitted work that failed today: 2", _viewModel.TotalFail);
            Assert.Equal("Total number of students who submitted work that improved today: 1", _viewModel.TotalImproved);
            Assert.Equal("Total number of students who submitted work that worsened today: 1", _viewModel.TotalWorsened);
        }
    }
}