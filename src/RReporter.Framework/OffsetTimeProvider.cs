using System;
using System.Globalization;

namespace RReporter.Framework
{
    public class OffsetTimeProvider : ITimeProvider
    {
        static readonly DateTime ParticularTime = DateTime.Parse("2015-03-24 11:30:00", 
            CultureInfo.InvariantCulture, 
            DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal
            );

        readonly TimeSpan offset;

        public OffsetTimeProvider() 
        {
            offset = DateTime.UtcNow - ParticularTime;
        }            
        public DateTime CurrentUtcTime => DateTime.UtcNow - offset;
    }

 }