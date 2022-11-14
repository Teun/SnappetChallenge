using SnappetChallenge.Client.Model;
using SnappetChallenge.Client.View;
using SnappetChallenge.Client.ViewModel;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SnappetChallenge.View
{
    public partial class MainPage : ContentPage
    {
        BaseViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            viewModel = new BaseViewModel();
            BindingContext = viewModel;
        }
        private async void OpenStatisticalReportClikced(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new TodayStatisticalReportPage(), false);
        }

        private async void OpenFilterStudentClikced(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new FilterStudentPage(), false);
        }
    }
}
    

