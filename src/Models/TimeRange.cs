using System;

using SnappetChallenge.Models.Contracts;

namespace SnappetChallenge.Models
{
    public class TimeRange : ITimeRange
    {
        public TimeRange(DateTime start, DateTime end)
        {
            if (start <= end)
            {
                Start = start;
                End = end;
            }
            else
            {
                End = start;
                Start = end;
            }
        }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}