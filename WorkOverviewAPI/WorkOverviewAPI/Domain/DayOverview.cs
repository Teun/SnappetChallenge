using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOverviewAPI.Domain
{
    public class DayOverview
    {
        public int Id { get; set; }
        public DateTime TillDateTime { get; set; }
        public int NumberOfSubmission { get; set; }
        public int SumOfProgress { get; set; }
        public int NumberOfWorkedPupil { get; set; }
        public int NumberOfProgresseddPupil { get; set; }
        public string Subject { get; set; }
    }
}
