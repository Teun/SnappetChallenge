using System;
using ApiService.Properties;
using ApiService.Services.Settings;
using BlCore.DataProviders;
using Database.DataProviders.Csv;
using Database.DataProviders.Json;

namespace ApiService.Services
{
    public class DataProviderFactory
    {
        private readonly ApiServiceSettingsProvider _settingsProvider;

        public DataProviderFactory()
        {
            _settingsProvider = new ApiServiceSettingsProvider();
        }

        public IDataProvider BuilDataProvider()
        {
            var settings = _settingsProvider.GetReportServiceSettings();
            string currProvider = settings.CurrDataProvider;
            if (currProvider == "CsvDataProvider")
            {
                return new CsvDataProvider(settings.CsvDataProvider.DataFilePath);
            }
            if (currProvider == "JsonDataProvider")
            {
                return new JsonDataProvider(settings.JsonDataProvider.DataFilePath);
            }
            throw new Exception(Resources.UnknownDataProvider);
        }
    }
}
