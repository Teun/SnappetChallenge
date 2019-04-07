using System;

namespace RReporter.Application.Domain
{
    public class WorkSummary
    {
        public static WorkSummary Create (DateTime now, PupilSummary[] pupilSummaries) => new WorkSummary
        {
            Timestamp = now,
            PupilSummaries = pupilSummaries
        };

        public DateTime Timestamp { get; private set; }

        public PupilSummary[] PupilSummaries { get; private set; }

    }
}