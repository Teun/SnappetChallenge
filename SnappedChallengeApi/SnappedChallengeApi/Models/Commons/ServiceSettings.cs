using System;
using Microsoft.Extensions.Configuration;
using SnappedChallengeApi.Models.Constants;

namespace SnappedChallengeApi.Models.Commons
{
    public class ServiceSettings
    {
        public static string DataPath { get; set; }
        public static string ServiceAddress { get; set; }

        public static void InitializeSettings(IConfiguration configuration)
        {
            try
            {
                DataPath = configuration.GetSection(string.Format(ServiceConstants.SettingTemplate, nameof(DataPath))).Value;
                ServiceAddress = configuration.GetSection(string.Format(ServiceConstants.SettingTemplate, nameof(ServiceAddress))).Value;
            }
            catch (Exception ex)
            {
                //ignored
            }
        }
    }
}
