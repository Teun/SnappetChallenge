using System;
using System.Net.Http;
using BlCore.ReportServices.Models;
using Newtonsoft.Json;

namespace Windows.Services
{
    public class SnappetApiService
    {
        public const string DEFAULT_DATE_FORMAT = "yyyy-MM-dd";

        private readonly SettingsProvider _settingsProvider;

        public SnappetApiService()
        {
            _settingsProvider = new SettingsProvider();
        }

        public ObjectivesReport GetObjectiveReport(DateTime begin, DateTime end)
        {
            string baseUri = _settingsProvider.GetSnappetApiServiceUri();
            string uri = $"{baseUri}/Reports/Objectives?begin={ToDateFormat(begin)}&end={ToDateFormat(end)}";
            return GetHttp<ObjectivesReport>(uri);
        }

        public UsersReport GetUsersReport(DateTime begin, DateTime end)
        {
            string baseUri = _settingsProvider.GetSnappetApiServiceUri();
            string uri = $"{baseUri}/Reports/Users?begin={ToDateFormat(begin)}&end={ToDateFormat(end)}";
            return GetHttp<UsersReport>(uri);
        }

        public OneUserReport GetOneUserReport(string user, DateTime begin, DateTime end)
        {
            string baseUri = _settingsProvider.GetSnappetApiServiceUri();
            string uri = $"{baseUri}/Reports/Users/One?user={user}&begin={ToDateFormat(begin)}&end={ToDateFormat(end)}";
            return GetHttp<OneUserReport>(uri);
        }

        public OneObjectiveReport GetOneObjectiveReport(string objective, DateTime begin, DateTime end)
        {
            string baseUri = _settingsProvider.GetSnappetApiServiceUri();
            string uri = $"{baseUri}/Reports/Objectives/One?obj={objective}&begin={ToDateFormat(begin)}&end={ToDateFormat(end)}";
            return GetHttp<OneObjectiveReport>(uri);
        }

        private T GetHttp<T>(string uri)
        {
            using var httpClient = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };
            var result = httpClient.GetAsync(uri).Result;
            string resultString = result.Content.ReadAsStringAsync().Result;
            if (!result.IsSuccessStatusCode)
            {
                if (string.IsNullOrWhiteSpace(resultString))
                {
                    throw new Exception(result.StatusCode.ToString());
                }
                throw new Exception(resultString);
            }
            return JsonConvert.DeserializeObject<T>(resultString);
        }

        private string ToDateFormat(DateTime dt)
        {
            return dt.ToString(DEFAULT_DATE_FORMAT);
        }
    }
}
