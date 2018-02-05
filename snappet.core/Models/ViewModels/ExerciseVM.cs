using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snappet.core.Models.ViewModels
{
    public class ExerciseVM
    {
        public int ExerciseID { get; set; }
        public int LearningObjectiveID { get; set; }
        public double? Difficulty { get; set; }
        public int NumberOfUsers { get; set; }
        public List<SubmittedAnswerVM> UserAnswers { get; set; }
    }
}
