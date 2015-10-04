using System;
using System.Collections.Generic;

namespace SnappetChallenge.Models
{
    public class TotalWorkSummary
    {
        public DateTime Date { get; set; }
        public WorkFilter GroupedBy { get; set; }
        public int UserId { get; set; }
        public IEnumerable<WorkSummary> WorkSummaries { get; set; }
    }
}