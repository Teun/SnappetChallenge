using System;

namespace BlCore.TimeServices
{
    public static class TimeService
    {
        public static TimeSpan NetherlandsTimeZone { get; }

        static TimeService()
        {
            NetherlandsTimeZone = TimeSpan.FromHours(2);
        }

        public static DateTime ConvertTimeZoneToUtc(DateTime now, TimeSpan fromTimeZone)
        {
            return new DateTimeOffset(now, fromTimeZone).UtcDateTime;
        }
    }
}
