using System;

namespace Snappet.Challenge.Models
{
    public class WorkQuery
    {
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
        public bool? Correct { get; set; }
        public int? User { get; set; }
        public int? Exercise { get; set; }
        public DateTime DateSubmitted { get; set; }
        public int ClientTimeZoneOffset { get; set; }
        public int PageNumber { get; set; }
        public int ItemsPerPage { get; set; }
    }
}
