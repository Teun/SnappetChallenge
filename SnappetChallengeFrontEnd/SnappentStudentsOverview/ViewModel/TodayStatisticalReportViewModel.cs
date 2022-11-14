using SnappetChallenge.Client.Helper;
using SnappetChallenge.Client.Model;
using SnappetChallenge.Client.Service;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SnappetChallenge.Client.ViewModel
{
    public class TodayStatisticalReportViewModel : BaseViewModel
    {
        private readonly StudentApiService studentApiService;

       
        private ObservableCollection<StatisticalReport> _statisticalReport;
        public ObservableCollection<StatisticalReport> StatisticalReport
        {
            get => _statisticalReport;
            set {
                _statisticalReport = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }

        public TodayStatisticalReportViewModel()
        {
            studentApiService = new StudentApiService();
        }

        public async Task LoadTodayStatisticalReport()
        {
            try {
                var remoteReport = await studentApiService.LoadTodayStatisticalReport();
                if (remoteReport != null)
                {
                    StatisticalReport = ConvertEnumerableListToObservableCollection.ToObservableCollection(remoteReport);
                }
            }
            catch (Exception ex)
            {

            }
        }

      

        //public async Task LoadGetStudentByFilter(FilterReport filterReport)
        //{
        //    try
        //    {
        //        // FilterReport filterReport = new FilterReport("Begrijpend Lezen", "",new DateTime(2015, 03, 24, 00, 00, 00), new DateTime(2015, 03, 24, 11, 30, 00),0);
        //        var customStudentReport = await studentApiService.GetStudentByFilter(filterReport);
        //        if (customStudentReport != null)
        //        {
        //            CustomStudentReport = ConvertEnumerableListToObservableCollection.ToObservableCollection(customStudentReport);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
       
    }
}