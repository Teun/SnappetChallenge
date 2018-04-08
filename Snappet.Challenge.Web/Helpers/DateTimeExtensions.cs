using System;

namespace Snappet.Challenge.Web.Helpers
{
    public static class DateTimeExtensions
    {
        public static DateTime NowAtSnappet(this DateTime source)
        {
            return new DateTime(2015, 3, 24, 11, 30, 0);
        }
    }
}