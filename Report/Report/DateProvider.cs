using System;

namespace Report
{
    public class DateProvider : IDateProvider
    {
        public DateTime Now => new DateTime(2015, 3, 24, 11, 30, 00, DateTimeKind.Utc);
    }
}
