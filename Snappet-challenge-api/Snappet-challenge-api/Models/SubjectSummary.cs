using System;
namespace Snappet_challenge_api.Models
{
    public class SubjectSummary
    {
        public string SubjectName { get; set; }
        public int AnswersSubmitted { get; set; }
        public int CorrectAnswers { get; set; }
        public float Aggregate { get; set; }
        public int Progress { get; set; }

        public SubjectSummary(
            string subjectName,
            int answersSubmitted,
            int correctAnswers,
            int progress
            )
        {
            SubjectName = subjectName;
            AnswersSubmitted = answersSubmitted;
            CorrectAnswers = correctAnswers;
            Aggregate = CalculateAggregate();
            Progress = progress;
        }

        private float CalculateAggregate()
        {
            double aggregate = (float)CorrectAnswers / (float)AnswersSubmitted;
            aggregate = aggregate * 100;
            aggregate = Math.Round(aggregate, 2);

            return (float)aggregate;
        }
    }
}
