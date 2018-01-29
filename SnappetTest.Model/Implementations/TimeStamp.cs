using System;
using System.Collections.Generic;
using System.Text;
using SnappetTest.Model.Abstract;

namespace SnappetTest.Model.Implementations
{
    public class TimeStamp : ITimeStamp
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public TimeStamp(DateTime starttime, DateTime endtime)
        {
            StartTime = starttime;
            EndTime = endtime;
        }
    }
}
