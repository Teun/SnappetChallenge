using System;

namespace Snappet.Borisov.Test.Domain
{
    public class Date : IEquatable<Date>
    {
        public Date(DateTimeOffset value)
        {
            Value = value.Date;
            Year = value.Year;
            Month = value.Month;
            Day = value.Day;
        }

        public int Year { get; }
        public int Month { get; }
        public int Day { get; }
        public DateTimeOffset Value { get; private set; }

        public bool Equals(Date other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return (Year == other.Year) && (Month == other.Month) && (Day == other.Day);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Date) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Year;
                hashCode = (hashCode*397) ^ Month;
                hashCode = (hashCode*397) ^ Day;
                return hashCode;
            }
        }

        public static bool operator ==(Date left, Date right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Date left, Date right)
        {
            return !Equals(left, right);
        }
    }
}