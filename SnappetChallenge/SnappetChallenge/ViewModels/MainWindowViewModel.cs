using SnappetChallenge.Commands;
using SnappetChallenge.Models;
using SnappetChallenge.Repositories;
using SnappetChallenge.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace SnappetChallenge.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private const int PageSize = 200; // Number of records per page
        private int _currentPage = 1;

        private readonly WorkRepository _workRepository = new WorkRepository();
        private readonly FileDialogService _fileDialogService = new FileDialogService();
        private List<WorkModel> _studentData = new List<WorkModel>();
        private ObservableCollection<StudentData> _todaysStudentData = new ObservableCollection<StudentData>();
        private string _selectedSubject = "";
        private string _totalStudents = "";
        private string _totalPass = "";
        private string _totalFail = "";
        private string _totalImproved = "";
        private string _totalWorsened = "";

        public List<WorkModel> StudentData
        {
            get => _studentData;
            set
            {
                _studentData = value;
            }
        }

        public ObservableCollection<StudentData> TodaysStudentData
        {
            get => _todaysStudentData;
            set
            {
                _todaysStudentData = value;
                OnPropertyChanged(nameof(TodaysStudentData));
                OnPropertyChanged(nameof(StudentDataLoaded));
            }
        }

        public ObservableCollection<StudentData> PaginatedStudentData
        {
            get;
            private set;
        } = new ObservableCollection<StudentData>();

        public ObservableCollection<string> Subjects
        {
            get;
            private set;
        } = new ObservableCollection<string>();

        public string SelectedSubject
        {
            get => _selectedSubject;
            set
            {
                if (_selectedSubject != value)
                {
                    _selectedSubject = value;
                    OnPropertyChanged(nameof(SelectedSubject));
                    PopulateSubjectData();
                }
            }
        }

        public string TotalStudents
        {
            get => _totalStudents;
            set
            {
                if (_totalStudents != value)
                {
                    _totalStudents = value;
                    OnPropertyChanged(nameof(TotalStudents));
                }
            }
        }

        public string TotalPass
        {
            get => _totalPass;
            set
            {
                if (_totalPass != value)
                {
                    _totalPass = value;
                    OnPropertyChanged(nameof(TotalPass));
                }
            }
        }

        public string TotalFail
        {
            get => _totalFail;
            set
            {
                if (_totalFail != value)
                {
                    _totalFail = value;
                    OnPropertyChanged(nameof(TotalFail));
                }
            }
        }

        public string TotalImproved
        {
            get => _totalImproved;
            set
            {
                if (_totalImproved != value)
                {
                    _totalImproved = value;
                    OnPropertyChanged(nameof(TotalImproved));
                }
            }
        }

        public string TotalWorsened
        {
            get => _totalWorsened;
            set
            {
                if (_totalWorsened != value)
                {
                    _totalWorsened = value;
                    OnPropertyChanged(nameof(TotalWorsened));
                }
            }
        }

        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
                UpdatePaginatedStudentData();
            }
        }

        public bool StudentDataLoaded => StudentData != null && StudentData.Count > 0;
        public int TotalPages => (int)Math.Ceiling((double)TodaysStudentData.Count / PageSize);
        public string CurrentPageText => $"Page {CurrentPage}/{TotalPages}";
        public bool PreviousPagesExist => CurrentPage > 1;
        public bool MorePagesExist => CurrentPage < TotalPages;

        public ICommand ChooseStudentWorkFileCommand { get; }
        public ICommand PreviousPageCommand { get; }
        public ICommand NextPageCommand { get; }

        public MainWindowViewModel()
        {
            ChooseStudentWorkFileCommand = new RelayCommand(LoadStudentData);
            PreviousPageCommand = new RelayCommand(PreviousPage);
            NextPageCommand = new RelayCommand(NextPage);
        }

        private async void LoadStudentData(object? parameter)
        {
            try
            {
                string filePath = _fileDialogService.OpenFileDialog();
                StudentData = await Task.Run(() => _workRepository.GetAllStudentWork(filePath));
                TodaysStudentData.Clear();

                // Map WorkModel to StudentData
                var todaysWorkModels = StudentData.Where(
                    sd => sd.SubmitDateTime.Date == GlobalDateTime.CurrentDateTime.Date).ToList();

                var todaysStudentData = new ObservableCollection<StudentData>();

                foreach (var studentData in todaysWorkModels)
                {
                    var earliestData = StudentData.Where(s => s.SubmitDateTime.Date < GlobalDateTime.CurrentDateTime.Date
                        && s.UserId == studentData.UserId
                        && s.Subject == studentData.Subject)
                        .OrderBy(o => o.SubmitDateTime).FirstOrDefault();

                    float? thisWeekDifficulty = null;
                    if (studentData.Difficulty != "NULL")
                    {
                        thisWeekDifficulty = float.Parse(studentData.Difficulty);
                    }

                    float? earliestDifficulty = null;
                    if (earliestData != null && earliestData.Difficulty != "NULL")
                    {
                        earliestDifficulty = float.Parse(earliestData.Difficulty);
                    }

                    bool previousWeekCorrect = studentData.Correct == 1 ? true : false;
                    if (earliestData != null)
                    {
                        previousWeekCorrect = earliestData.Correct == 1 ? true : false;
                    }

                    todaysStudentData.Add(new StudentData
                    {
                        ChangeInDifficulty = (thisWeekDifficulty.HasValue && earliestDifficulty.HasValue) ?
                            (thisWeekDifficulty.Value - earliestDifficulty.Value).ToString() : "N/A",
                        // If the int isn't 0 or 1 then the IntToStringConverter will handle other solutions
                        WasEarliestRecordCorrect = earliestData == null ? 2 : earliestData.Correct,
                        Correct = studentData.Correct,
                        Difficulty = studentData.Difficulty,
                        Domain = studentData.Domain,
                        LearningObjective = studentData.LearningObjective,
                        Progress = studentData.Progress,
                        Subject = studentData.Subject,
                        SubmitDateTime = studentData.SubmitDateTime,
                        SubmittedAnswerId = studentData.SubmittedAnswerId,
                        UserId = studentData.UserId
                    });
                }

                TodaysStudentData = todaysStudentData;

                UpdatePaginatedStudentData();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void PreviousPage(object? parameter)
        {
            CurrentPage--;
        }

        private void NextPage(object? parameter)
        {
            CurrentPage++;
        }

        private void UpdatePaginatedStudentData()
        {
            try
            {
                PaginatedStudentData.Clear();
                var startIndex = (CurrentPage - 1) * PageSize;
                var endIndex = Math.Min(startIndex + PageSize, TodaysStudentData.Count);

                for (int i = startIndex; i < endIndex; i++)
                {
                    PaginatedStudentData.Add(TodaysStudentData[i]);
                }

                Subjects = new ObservableCollection<string>(PaginatedStudentData.Select(s => s.Subject).Distinct());

                OnPropertyChanged(nameof(PaginatedStudentData));
                OnPropertyChanged(nameof(CurrentPageText));
                OnPropertyChanged(nameof(PreviousPagesExist));
                OnPropertyChanged(nameof(MorePagesExist));
                OnPropertyChanged(nameof(Subjects));
                OnPropertyChanged(nameof(TotalPages));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void PopulateSubjectData()
        {
            TotalStudents = $"Total number of students who submitted work in {SelectedSubject} today: " +
                TodaysStudentData.Where(p => p.Subject == SelectedSubject).DistinctBy(s => s.UserId).Count();
            TotalPass = "Total number of students who submitted work that passed today: " +
                TodaysStudentData.Where(p => p.Correct == 1 && p.Subject == SelectedSubject).DistinctBy(s => s.UserId).Count();
            TotalFail = "Total number of students who submitted work that failed today: " +
                TodaysStudentData.Where(p => p.Correct == 0 && p.Subject == SelectedSubject).DistinctBy(s => s.UserId).Count();
            TotalImproved = "Total number of students who submitted work that improved today: " +
                TodaysStudentData.Where(p => p.Progress > 0 && p.Subject == SelectedSubject).DistinctBy(s => s.UserId).Count();
            TotalWorsened = "Total number of students who submitted work that worsened today: " +
                TodaysStudentData.Where(p => p.Progress < 0 && p.Subject == SelectedSubject).DistinctBy(s => s.UserId).Count();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string? propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}