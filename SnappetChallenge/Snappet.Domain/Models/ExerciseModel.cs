using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Domain.Models
{
    public class ExerciseModel
    {
        public int ExerciseId { get; set; }
        public string? Difficulty { get; set; }
        public string? Subject { get; set; }
        public string? Domain { get; set; }
        public string? LearningObjective { get; set; }
        public int SubmittedAnswerId { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public bool Correct { get; set; }
        public int Progress { get; set; }
    }
}
