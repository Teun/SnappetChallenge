using SnappetChallenge.Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnappetChallenge.Client.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodayStatisticalReportPage : ContentPage
    {
        TodayStatisticalReportViewModel viewModel;
        public TodayStatisticalReportPage()
        {
            InitializeComponent();
            viewModel = new TodayStatisticalReportViewModel();
            BindingContext = viewModel;
        }

        private async void LoadTodayStatisticalReport(object sender, EventArgs e)
        {
            if (viewModel != null)
            {
                await viewModel.LoadTodayStatisticalReport();
            }
        }

       
    }
}