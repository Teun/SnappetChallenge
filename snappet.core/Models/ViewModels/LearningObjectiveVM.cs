using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snappet.core.Models.ViewModels
{
    public class LearningObjectiveVM
    {
        public int LearningObjectiveID { get; set; }
        public string LearningObjective { get; set; }
        public List<ExerciseVM> Exercises { get; set; }
    }
}
