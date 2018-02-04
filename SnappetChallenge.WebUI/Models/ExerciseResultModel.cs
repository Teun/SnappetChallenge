namespace SnappetChallenge.WebUI.Models
{
    using System;

    public class ExerciseResultModel : ExerciseModel
    {
        public DateTime SubmittedDateTime { get; set; }

        public int SubmittedAnswerId { get; set; }

        public bool IsCorrect { get; set; }

        public int Progress { get; set; }
    }
}
