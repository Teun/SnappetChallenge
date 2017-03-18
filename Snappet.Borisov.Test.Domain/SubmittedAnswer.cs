using System;

namespace Snappet.Borisov.Test.Domain
{
    public class SubmittedAnswer
    {
        public int SubmittedAnswerId { get; set; }
        public DateTimeOffset SubmitDateTime { get; set; }
        public int Correct { get; set; }
        public int Progress { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public decimal? Difficulty { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }

        public override string ToString()
        {
            return $"Student {UserId} Day {SubmitDateTime:d} Subject: {Subject} Domain: {Domain} Objective: {LearningObjective} Correct: {Correct} Difficulty: {Difficulty} Progress: {Progress}";
        }
    }
}