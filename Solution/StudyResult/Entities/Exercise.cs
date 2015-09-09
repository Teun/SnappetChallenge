using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyReport.Entities
{
    public class Exercise : BaseEntity
    {
        [Index]
        public int ExerciseId { get; set; }
        public double? Difficulty { get; set; }
        public virtual LearningObjective LearningObjective { get; set; }
    }
}
