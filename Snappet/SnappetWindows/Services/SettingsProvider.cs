using System.Configuration;
using System.Linq;

namespace Windows.Services
{
    public class SettingsProvider
    {
        public const string SNAPPET_API_SERVICE_URI = "SNAPPET_API_SERVICE_URI";
        public const string DEFAULT_API_SERVICE_URI = "https://localhost:44375";

        private readonly Configuration _config;

        public SettingsProvider()
        {
            _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        public string GetSnappetApiServiceUri()
        {
            string uri = GetValue(SNAPPET_API_SERVICE_URI);
            if (string.IsNullOrEmpty(uri))
            {
                SetValue(SNAPPET_API_SERVICE_URI, DEFAULT_API_SERVICE_URI);
                uri = GetValue(SNAPPET_API_SERVICE_URI);
            }
            return uri;
        }

        private string GetValue(string key)
        {
            var settings = _config.AppSettings.Settings;

            if (settings.AllKeys.Any(k => k == key))
            {
                return settings[key].Value;
            }

            return null;
        }

        private void SetValue(string key, string value)
        {
            var settings = _config.AppSettings.Settings;

            if (settings.AllKeys.Any(k => k == key))
            {
                settings[key].Value = value;
            }
            else
            {
                settings.Add(key, value);
            }
            _config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
