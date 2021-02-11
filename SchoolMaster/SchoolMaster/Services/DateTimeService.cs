using System;

namespace SchoolMaster.Services
{
    public class DateTimeService : IDateTimeService
    {
        private const string FakeCurrentTime = "2015-03-24 11:30:00";

        public DateTime Now => DateTime.SpecifyKind(DateTime.Parse(FakeCurrentTime)
            , DateTimeKind.Utc);

        public bool IsDateBeforeNow(DateTime date)
        {
            return date <= Now;
        }
    }
}