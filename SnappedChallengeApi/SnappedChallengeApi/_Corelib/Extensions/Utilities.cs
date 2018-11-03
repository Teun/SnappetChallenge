using System;

namespace SnappedChallengeApi._Corelib.Extensions
{
    /// <summary>
    /// TODO summary code required
    /// </summary>
    public static class Utilities
    {
        public static bool IsNotNullAndEmpty(this Guid source)
        {
            return !Guid.Empty.Equals(source);
        }

        public static bool IsNotNullAndEmpty(this string source)
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

        public static bool IsNullAndEmpty(this Guid source)
        {
            return !IsNotNullAndEmpty(source);
        }

        public static bool IsNullAndEmpty(this object source)
        {
            return !IsNullAndEmpty(source);
        }

        public static bool IsNullAndEmpty(this string source)
        {
            return !IsNullAndEmpty(source);
        }

        public static bool IsNullAndEmpty(this DateTime source)
        {
            return !IsNullAndEmpty(source);
        }

        public static bool IsNullAndEmpty(this Double source)
        {
            return !IsNullAndEmpty(source);
        }
    }
}
