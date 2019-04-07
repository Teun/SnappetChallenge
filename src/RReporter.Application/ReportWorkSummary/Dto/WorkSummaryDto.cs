using System;

namespace RReporter.Application.ReportWorkSummary.Dto
{
    public class WorkSummaryDto
    {

        public DateTime Timestamp { get; set; }

        public PupilSummaryDto[] PupilSummaries { get; set; }

    }
}