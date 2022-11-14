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
    public partial class FilterStudentPage : ContentPage
    {
        FilterStudentViewModel viewModel;
        public FilterStudentPage()
        {
            InitializeComponent();
            viewModel = new FilterStudentViewModel();
            BindingContext = viewModel;
        }

        private void GetStudentByFilter(object sender, EventArgs e)
        {

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.LoadDomains();
            await  viewModel.LoadSubjects();
        }
    }
}