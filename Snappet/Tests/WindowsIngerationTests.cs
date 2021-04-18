using System.Threading.Tasks;
using Windows.ViewModels;
using ApiService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace Tests
{
    public class WindowsIngerationTests
    {
        [Fact]
        public void ShowObjectivesTest()
        {
            var windowsSettingsProvider = new Windows.Services.SettingsProvider();

            Task.Run(() => Host
                .CreateDefaultBuilder(new string[0])
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls(windowsSettingsProvider.GetSnappetApiServiceUri());
                })
                .Build()
                .Run());
            
            var viewModel = new MainWindowViewModel();
            Assert.Empty(viewModel.Items);
            viewModel.TodayCommand.Execute(null);
            viewModel.ShowObjectivesCommand.Execute(null);
            Assert.NotEmpty(viewModel.Items);
        }
    }
}
