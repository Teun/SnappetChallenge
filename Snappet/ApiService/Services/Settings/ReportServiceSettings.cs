namespace ApiService.Services.Settings
{
    public class ReportServiceSettings
    {
        public string CurrDataProvider { get; set; }

        public JsonDataProviderSettings JsonDataProvider { get; set; }

        public CsvDataProviderSettings CsvDataProvider { get; set; }
    }
}