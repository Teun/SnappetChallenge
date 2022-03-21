using Snappet.Domain.Interface.Service;

namespace Snappet.Infrastructure.Services
{
    public class DateService : IDateService
    {
        private static DateTime CurrentDate = new DateTime(2015, 3, 24, 11, 30, 0, DateTimeKind.Utc);
        public DateTime GetCurrentDateUTC()
        {
            return CurrentDate;
        }
    }
}
