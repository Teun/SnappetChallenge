using System;
using System.Globalization;

namespace Snappet.Challenge.Helpers
{
    public static class DateValidater
    {
        public static DateTime ValidateDate(string givenDateTimeUTC)
        {
            DateTime targetDate;
            try
            {
                targetDate = DateTime.ParseExact(givenDateTimeUTC, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                       DateTimeStyles.None);
            }
            catch (FormatException ex)
            {
                return DateTime.MinValue;
            }
            return targetDate;
        }
    }
}