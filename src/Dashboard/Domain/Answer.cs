using System;

namespace Dashboard.Domain
{
    public class Answer
    {
        public int SubmittedAnswerId { get; }

        public DateTimeOffset SubmitDateTime { get; }

        public bool IsCorrect { get; }

        public int Progress { get; }

        public int UserId { get; }

        public int ExerciseId { get; }

        public float? Difficulty { get; }

        public string Subject { get; }

        public string Domain { get; }

        public string LearningObjective { get; }

        public Answer(
            int submittedAnswerId,
            DateTimeOffset submitDateTime,
            bool isCorrect,
            int progress,
            int userId,
            int exerciseId,
            float? difficulty,
            string subject,
            string domain,
            string learningObjective
        )
        {
            SubmittedAnswerId = submittedAnswerId;
            SubmitDateTime = submitDateTime;
            IsCorrect = isCorrect;
            Progress = progress;
            UserId = userId;
            ExerciseId = exerciseId;
            Difficulty = difficulty;
            Subject = subject;
            Domain = domain;
            LearningObjective = learningObjective;
        }
    }
}
