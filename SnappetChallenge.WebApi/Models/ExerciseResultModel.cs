namespace SnappetChallenge.WebApi.Models
{
    using System;

    public class ExerciseResultModel : ExerciseModel
    {
        public ExerciseResultModel() : base() { }

        public ExerciseResultModel(ExerciseResultJsonDeserializeModel exerciseResult) : base(exerciseResult)
        {
            if (exerciseResult != null)
            {
                this.SubmittedAnswerId = exerciseResult.SubmittedAnswerId;
                this.IsCorrect = exerciseResult.Correct;
                this.Progress = exerciseResult.Progress;
                this.SubmittedDateTime = exerciseResult.SubmitDateTime;
            }
        }

        public DateTime SubmittedDateTime { get; set; }

        public int SubmittedAnswerId { get; set; }

        public bool IsCorrect { get; set; }

        public int Progress { get; set; }
    }
}
