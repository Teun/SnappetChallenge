using System.ComponentModel.DataAnnotations;

namespace Snappet2.ViewModel
{
    public class ExerciseResultViewModel
    {
        [Display(Name = "Exercise")]
        public int ExerciseId { get; set; }
        public int Correct { get; set; }
    }
}
