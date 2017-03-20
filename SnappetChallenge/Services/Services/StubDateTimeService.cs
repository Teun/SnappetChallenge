using Microsoft.Extensions.Configuration;
using Services.Constants;
using Services.Properties;
using System;
using System.Globalization;

namespace Services.Services
{
    public class StubDateTimeService : IDateTimeService
    {
        private readonly IConfigurationRoot _configurationRoot;

        public StubDateTimeService(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }

        public DateTime GetCurrent()
        {
            var stubDateTime = _configurationRoot.GetSection(AppSettings.StubCurrentDateTime).Value;
            if (stubDateTime == null)
            {
                throw new InvalidOperationException(Resources.StubDateTimeRequiredException);
            }

            DateTime currentDateTime;
            if (!DateTime.TryParse(stubDateTime, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out currentDateTime))
            {
                throw new InvalidOperationException(Resources.StubDateTimeInvalidException);
            }

            return currentDateTime.ToUniversalTime();
        }
    }
}
