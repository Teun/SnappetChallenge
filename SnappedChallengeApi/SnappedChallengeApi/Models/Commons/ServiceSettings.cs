using System;
using Microsoft.Extensions.Configuration;

namespace SnappedChallengeApi.Models.Commons
{
    public class ServiceSettings
    {
        public static string DataPath { get; set; }

        public static void InitializeSettings(IConfiguration configuration)
        {
            try
            {
                DataPath = configuration.GetSection("ServiceSettings:DataPath").Value;
            }
            catch (Exception ex)
            {
                //ignored
            }
        }
    }
}
