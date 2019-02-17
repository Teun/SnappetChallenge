
using System;
using System.Collections.Generic;

namespace Dashboard.Dashboard.Models
{
    public class Dashboard
    {
        public DateTimeOffset Start { get; set;  }

        public DateTimeOffset End { get; set; }

        public int StudentsPresent { get; set; }

        public IReadOnlyCollection<TopicDashboardModel> TopicStatistics { get; set; }
    }
}
