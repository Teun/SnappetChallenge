using System;

namespace Report.Data
{
    public class UserActivity
    {
        public UserActivity(
            int submittedAnserId,
            DateTime submittedDateTimeUtc,
            bool correct,
            int progress,
            int userId,
            int excerciseId,
            float difficulty,
            string subject,
            string domain,
            string objective)
        {
            SubmittedAnswerId = submittedAnserId;
            SubmittedDateTimeUtc = submittedDateTimeUtc;
            Correct = correct;
            Progress = progress;
            UserId = userId;
            ExcerciseId = excerciseId;
            Difficulty = difficulty;
            Subject = subject;
            Domain = domain;
            Objective = objective;
        }

        public int SubmittedAnswerId { get; }

        public DateTime SubmittedDateTimeUtc { get; }

        public bool Correct { get; }

        public int Progress { get; }

        public int UserId { get; }

        public int ExcerciseId { get; }

        public float Difficulty { get; }

        public string Subject { get; }

        public string Domain { get; }

        public string Objective { get; }
    }
}
