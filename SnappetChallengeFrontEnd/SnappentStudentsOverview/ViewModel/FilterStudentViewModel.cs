using SnappetChallenge.Client.Helper;
using SnappetChallenge.Client.Model;
using SnappetChallenge.Client.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;

namespace SnappetChallenge.Client.ViewModel
{
    public class FilterStudentViewModel : BaseViewModel
    {
        private readonly StudentApiService studentApiService;
        private ObservableCollection<string> _studentDomains;
        private ObservableCollection<object> _selectedDomains;
        private ObservableCollection<object> _selectedSubjects;

        private int _currentSkipRow;
        private bool _isStudentListLoading;
        private bool _canLoadStudent;
        private ObservableCollection<Student> _customStudentReport;
        private ObservableCollection<string> _studentSubjects;
        private DateTime _filterStartSpecificTime;
        private DateTime _filterEndSpecificTime;


        public int CurrentSkipRow
        {
            get => _currentSkipRow;
            set
            {
                _currentSkipRow = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }
        public bool IsStudentListLoading
        {
            get => _isStudentListLoading;
            set
            {
                _isStudentListLoading = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }
        public bool CanLoadStudent
        {
            get => _canLoadStudent;
            set
            {
                _canLoadStudent = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }
        public ObservableCollection<string> StudentDomains
        {
            get => _studentDomains;
            set
            {
                _studentDomains = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }

        public ObservableCollection<object> SelectedDomains
        {
            get => _selectedDomains;
            set
            {
                _selectedDomains = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }
        public ObservableCollection<object> SelectedSubjects
        {
            get => _selectedSubjects;
            set
            {
                _selectedSubjects = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Student> CustomStudentReport
        {
            get => _customStudentReport;
            set
            {
                _customStudentReport = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }
        public ObservableCollection<string> StudentSubjects
        {
            get => _studentSubjects;
            set
            {
                _studentSubjects = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }
        public DateTime FilterStartSpecificTime
        {
            get => _filterStartSpecificTime;
            set
            {
                _filterStartSpecificTime = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }
        public DateTime FilterEndSpecificTime
        {
            get => _filterEndSpecificTime;
            set
            {
                _filterEndSpecificTime = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }
    
        public IAsyncCommand<Syncfusion.ListView.XForms.ItemTappedEventArgs> SelectedMeetingCommand { get; set; }

        public IAsyncCommand ReloadCommand { get; set; }
        public IAsyncCommand LoadMoreStudentApplyFilterCommand { get; set; }
        public IAsyncCommand GetFilterStudentItemsCommand { get; set; }
        public FilterStudentViewModel()
        {
            studentApiService = new StudentApiService();
            this.LoadMoreStudentApplyFilterCommand = new AsyncCommand(LoadMoreStudents, CanLoadMoreItems);
            this.GetFilterStudentItemsCommand = new AsyncCommand(GetStudentWithFilterValues);
            SelectedSubjects = new ObservableCollection<object>();
            SelectedDomains = new ObservableCollection<object>();
            FilterStartSpecificTime = new DateTime(2015, 3, 23);
            FilterEndSpecificTime = new DateTime(2015, 3, 24);
        }
        public async Task LoadSubjects()
        {
            try
            {
                var remote = await studentApiService.GetSubjects();
                if (remote != null)
                {
                    StudentSubjects = ConvertEnumerableListToObservableCollection.ToObservableCollection(remote);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public async Task LoadDomains()
        {
            try
            {
                var remote = await studentApiService.GetDomains();
                if (remote != null)
                {
                    StudentDomains = ConvertEnumerableListToObservableCollection.ToObservableCollection(remote);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async Task GetStudentWithFilterValues()
        {
            FilterReport studentFillter = CreateFilter(CurrentSkipRow = 0);
            IsStudentListLoading = true;
            var getStudentList = await AllStudentByFilter(studentFillter);
            if (getStudentList != null)
            {
                if (CustomStudentReport != null && CustomStudentReport.Count != 0)
                {
                    CustomStudentReport.Clear();
                }

                CustomStudentReport = ConvertEnumerableListToObservableCollection.ToObservableCollection(getStudentList);
                CanLoadStudent = CustomStudentReport.Count() >= 20;
            }
            IsStudentListLoading = false;
            CurrentSkipRow = 0;
        }

        private async Task<IEnumerable<Student>> AllStudentByFilter(FilterReport studentFillter)
        {
            try
            {
                return await studentApiService.GetStudentByFilter(studentFillter);
            }

            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.ToString(), "OK");
            }

            return null;
        }

        private bool CanLoadMoreItems()
        {
            return CanLoadStudent;
        }
        private async Task LoadMoreStudents()
        {
            IsStudentListLoading = true;
            CurrentSkipRow += 20;

            FilterReport studentFillter = CreateFilter(CurrentSkipRow);
            var retList = await AllStudentByFilter(studentFillter);
            if (retList != null)
            {
                var newRetList = retList.ToList();
                for (int i = 0; i < newRetList.Count; i++)
                {
                    Student student = newRetList[i];
                    CustomStudentReport.Add(student);
                }

                CanLoadStudent = retList.Count() >= 20;
            }
            IsStudentListLoading = false;
        }
        private FilterReport CreateFilter(int currentSkipRow)
        {
            var filterReport = new FilterReport()
            {
                TakeRows = 20,
                SkipRows = currentSkipRow,
                StartDate = FilterStartSpecificTime,//                new DateTime(2015, 03, 24, 00, 00, 00),// FilterStartSpecificTime,
                EndDate = FilterEndSpecificTime //new DateTime(2015, 03, 24, 11, 30, 00) // FilterEndSpecificTime
            };
            if (SelectedDomains != null)
            {
                foreach (var selectedDomain in SelectedDomains)
                {
                    filterReport.Domain.Add((string)selectedDomain);
                }
            }
            if (SelectedSubjects != null)
            {
                foreach (var selectedSubject in SelectedSubjects)
                {
                    filterReport.Subject.Add((string)selectedSubject);
                }
            }
            
            return filterReport;
        }
    }
}
