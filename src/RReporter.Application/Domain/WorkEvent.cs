using System;
using System.Globalization;
using System.Linq;

namespace RReporter.Application.Domain
{
    public class WorkEvent
    {
        public static WorkEvent CreateNew (
            int userId,
            Exercise exercise,
            int correct, int progress) => Create (
            BitConverter.ToInt32 (Guid.NewGuid ().ToByteArray ().Take (4).ToArray (), 0),
            DateTime.UtcNow,
            userId, exercise, correct, progress);

        public static WorkEvent Create (
            int id, DateTime submittedAt, int userId,
            Exercise exercise,
            int correct, int progress
        )
        {
            return new WorkEvent
            {
                SubmittedAnswerId = id,
                    SubmitDateTime = submittedAt,
                    UserId = userId,
                    Exercise = exercise,
                    Correct = correct,
                    Progress = progress,
            };
        }

        public int SubmittedAnswerId { get; private set; }
        public DateTime SubmitDateTime { get; private set; }
        public int UserId { get; private set; }

        public Exercise Exercise { get; private set; }

        public int Correct { get; private set; }
        public int Progress { get; private set; }
    }
}