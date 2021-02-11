using System;

namespace SchoolMaster.Services
{
    public interface IDateTimeService
    {
        DateTime Now { get; }
        bool IsDateBeforeNow(DateTime date);
    }
}