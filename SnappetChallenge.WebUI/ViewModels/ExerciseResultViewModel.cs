namespace SnappetChallenge.WebUI.ViewModels
{
    using SnappetChallenge.WebUI.Models;

    public class ExerciseResultViewModel
    {
        public ExerciseResultViewModel() { }

        public ExerciseResultViewModel(ExerciseResultModel exerciseResult)
        {
            this.IsCorrect = exerciseResult.IsCorrect;
        }

        public bool IsCorrect { get; set; }
    }
}
