using System;

namespace SnappedChallengeApi._Corelib.Extensions
{
    /// <summary>
    /// Utilities extensions about date and referance check
    /// </summary>
    public static class Utilities
    {
        #region Datetime Extensions
        /// <summary>
        /// Calculates the start of week from date
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime GetStartOfWeek(this DateTime dt)
        {
            DateTime ndt = dt.Subtract(TimeSpan.FromDays((int)dt.DayOfWeek));
            return new DateTime(ndt.Year, ndt.Month, ndt.Day, 0, 0, 0, 0);
        }
        /// <summary>
        /// Calculates end of week from date
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime GetEndOfWeek(this DateTime dt)
        {
            DateTime ndt = dt.GetStartOfWeek().AddDays(6);
            return new DateTime(ndt.Year, ndt.Month, ndt.Day, 23, 59, 59, 999);
        }
        /// <summary>
        /// Calculates start of week with year and week
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="year"></param>
        /// <param name="week"></param>
        /// <returns></returns>
        public static DateTime GetStartOfWeek(this DateTime dt, int year, int week)
        {
            DateTime dayInWeek = new DateTime(year, 1, 1).AddDays((week - 1) * 7);
            return dayInWeek.GetStartOfWeek();
        }
        /// <summary>
        /// Calculates end of week with year and week
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="year"></param>
        /// <param name="week"></param>
        /// <returns></returns>
        public static DateTime GetEndOfWeek(this DateTime dt, int year, int week)
        {
            DateTime dayInWeek = new DateTime(year, 1, 1).AddDays((week - 1) * 7);
            return dayInWeek.GetEndOfWeek();
        }
        /// <summary>
        /// Calculcates the start date of month with the given date's month in
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime GetStartOfMonth(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }
        
        #endregion

        #region Utils Extensions
        /// <summary>
        /// Reference and value check for guid
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty(this Guid source)
        {
            return !Guid.Empty.Equals(source);
        }
        /// <summary>
        /// reference and value check for string 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty(this string source)
        {
            return !String.IsNullOrEmpty(source);
        }
        /// <summary>
        /// reference and value check for datetime
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNotNullAndEmpty(this DateTime source)
        {
            return ((DateTime)source > DateTime.MinValue);
        }
        /// <summary>
        /// reference and value check for double
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNotNullAndEmpty(this Double source)
        {
            return !double.IsNaN(source);
        }
        /// <summary>
        /// reference and value check for any object
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNotNullAndEmpty(this object source)
        {
            if (source is DateTime) return IsNotNullAndEmpty(Convert.ToDateTime(source));
            else if (source is String) return IsNotNullAndEmpty(Convert.ToString(source));
            else if (source is double) return IsNotNullAndEmpty(Convert.ToDouble(source));
            else if (source is Guid) return IsNotNullAndEmpty((Guid)source);
            else return ((source != null) && (source != DBNull.Value));
        }
        /// <summary>
        /// reference and value check for guid
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this Guid source)
        {
            return !IsNotNullAndEmpty(source);
        }
        /// <summary>
        /// reference and value check for any object
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this object source)
        {
            return !IsNotNullAndEmpty(source);
        }
        /// <summary>
        /// reference and value check for string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string source)
        {
            return !IsNotNullAndEmpty(source);
        }
        /// <summary>
        /// reference and value check for datetime
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this DateTime source)
        {
            return !IsNotNullAndEmpty(source);
        }
        /// <summary>
        /// reference and value check for double
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this Double source)
        {
            return !IsNotNullAndEmpty(source);
        }
        #endregion
    }
}
