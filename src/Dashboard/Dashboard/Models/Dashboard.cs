
using System;

namespace Dashboard.Dashboard.Models
{
    public class Dashboard
    {
        public DateTimeOffset Start { get; set;  }

        public DateTimeOffset End { get; set; }

        public int StudentsPresent { get; set; }

        public AnswersSlice SlicedStatistics { get; set; }
    }
}
