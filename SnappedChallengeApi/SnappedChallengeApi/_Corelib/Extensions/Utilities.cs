using System;
using System.IO;
using System.Reflection;

namespace SnappedChallengeApi._Corelib.Extensions
{
    /// <summary>
    /// TODO summary code required
    /// </summary>
    public static class Utilities
    {
        #region Datetime Extensions
        public static DateTime GetStartOfWeek(this DateTime dt)
        {
            DateTime ndt = dt.Subtract(TimeSpan.FromDays((int)dt.DayOfWeek));
            return new DateTime(ndt.Year, ndt.Month, ndt.Day, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfWeek(this DateTime dt)
        {
            DateTime ndt = dt.GetStartOfWeek().AddDays(6);
            return new DateTime(ndt.Year, ndt.Month, ndt.Day, 23, 59, 59, 999);
        }

        public static DateTime GetStartOfWeek(this DateTime dt, int year, int week)
        {
            DateTime dayInWeek = new DateTime(year, 1, 1).AddDays((week - 1) * 7);
            return dayInWeek.GetStartOfWeek();
        }

        public static DateTime GetEndOfWeek(this DateTime dt, int year, int week)
        {
            DateTime dayInWeek = new DateTime(year, 1, 1).AddDays((week - 1) * 7);
            return dayInWeek.GetEndOfWeek();
        }

        public static DateTime GetStartOfMonth(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }
        
        #endregion

        #region Utils Extensions

        public static bool IsNotNullOrEmpty(this Guid source)
        {
            return !Guid.Empty.Equals(source);
        }

        public static bool IsNotNullOrEmpty(this string source)
        {
            return !String.IsNullOrEmpty(source);
        }

        public static bool IsNotNullAndEmpty(this DateTime source)
        {
            return ((DateTime)source > DateTime.MinValue);
        }

        public static bool IsNotNullAndEmpty(this Double source)
        {
            return !double.IsNaN(source);
        }

        public static bool IsNotNullAndEmpty(this object source)
        {
            if (source is DateTime) return IsNotNullAndEmpty(Convert.ToDateTime(source));
            else if (source is String) return IsNotNullAndEmpty(Convert.ToString(source));
            else if (source is double) return IsNotNullAndEmpty(Convert.ToDouble(source));
            else if (source is Guid) return IsNotNullAndEmpty((Guid)source);
            else return ((source != null) && (source != DBNull.Value));
        }

        public static bool IsNullOrEmpty(this Guid source)
        {
            return !IsNotNullAndEmpty(source);
        }

        public static bool IsNullOrEmpty(this object source)
        {
            return !IsNotNullAndEmpty(source);
        }

        public static bool IsNullOrEmpty(this string source)
        {
            return !IsNotNullAndEmpty(source);
        }

        public static bool IsNullOrEmpty(this DateTime source)
        {
            return !IsNotNullAndEmpty(source);
        }

        public static bool IsNullOrEmpty(this Double source)
        {
            return !IsNotNullAndEmpty(source);
        }
        #endregion
    }
}
