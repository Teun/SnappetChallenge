using System;

namespace SnappedChallengeApi._Corelib.Extensions
{
    /// <summary>
    /// TODO summary code required
    /// </summary>
    public static class Utilities
    {
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
    }
}
