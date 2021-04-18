using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace ApiService.Services.Settings
{
    public class ApiServiceSettingsProvider
    {
        private readonly IConfigurationRoot _configuration;
            
        public const string DEVELOP_FILE_NAME = "appsettings.Development.json";

        public const string COMMON_FILE_NAME = "appsettings.json";

        public ApiServiceSettingsProvider()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile(GetSettingsPath(COMMON_FILE_NAME), false, true)
                .AddJsonFile(GetSettingsPath(DEVELOP_FILE_NAME), false, true)
                .Build();
        }

        public ReportServiceSettings GetReportServiceSettings()
        {
            var result = new ReportServiceSettings();
            _configuration.GetSection("AppSections:ReportServiceSettings").Bind(result);
            return result;
        }

        private string GetSettingsPath(string fileName)
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
        }
    }
}
