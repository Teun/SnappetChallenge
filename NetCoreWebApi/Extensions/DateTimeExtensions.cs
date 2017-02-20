using System;

namespace SnappetWorkApp.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime NextWorkingDay(this DateTime currentDay)
        {
            return currentDay.RetrieveWorkingDayAtOffset(1);
        }

        public static DateTime PreviousWorkingDay(this DateTime currentDay)
        {
            return currentDay.RetrieveWorkingDayAtOffset(-1);
        }

        private static DateTime RetrieveWorkingDayAtOffset(this DateTime startDay, int offSet){

            var offSetDay = startDay;

            do
            {
                offSetDay = offSetDay.AddDays(offSet);
            }
            while(offSetDay.DayOfWeek == DayOfWeek.Saturday || offSetDay.DayOfWeek == DayOfWeek.Sunday);

            return offSetDay;
        }
    }
}