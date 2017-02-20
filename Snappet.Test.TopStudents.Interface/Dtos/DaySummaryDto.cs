using System;

namespace Snappet.Test.TopStudents.Interface.Dtos
{
    public class DaySummaryDto
    {
        public DateTime RecordDate { get; set; }
        public string Subject { get; set; }

        public int NumberOfStudents { get; set; }
        public int NumberOfAnswers { get; set; }
        public decimal MaxProgress { get; set; }
        public decimal MinProgress { get; set; }
        public decimal AverageProgress { get; set; }
    }
}