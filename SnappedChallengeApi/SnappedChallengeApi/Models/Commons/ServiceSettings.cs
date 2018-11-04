using System;
using Microsoft.Extensions.Configuration;
using SnappedChallengeApi.Models.Constants;

namespace SnappedChallengeApi.Models.Commons
{
    /// <summary>
    /// Settings model class for the service all settings required to launch servis is stored in this model
    /// </summary>
    public class ServiceSettings
    {
        /// <summary>
        /// Exercise work.json file path
        /// </summary>
        public static string DataPath { get; set; }

        /// <summary>
        /// Service Api Backend Url For UI http rest calls
        /// </summary>
        public static string ServiceAddress { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
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
