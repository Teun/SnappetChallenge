using System;

namespace SnappetChallenge.Models
{
    public class AnswerForLearningObjectiveForUserDto
    {
        public int AnswerId { get; set; }
        public int ExerciseId { get; set; }
        public string Difficulty { get; set; }
        public bool Correct { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public double Progress { get; set; }
    }
}