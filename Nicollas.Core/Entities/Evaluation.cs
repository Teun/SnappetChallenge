using System;
using System.Collections.Generic;
using System.Text;

namespace Nicollas.Core.Entities
{
    public class Evaluation: BaseEntity<int>
    {
        public bool IsCorrect { get; set; }
        public int Progress { get; set; }
        
        public int UserId { get; set; }
        public int ExerciseId { get; set; }

        public string LearningObjective { get; set; }

        public float Difficulty { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public int DomainId { get; set; }
        public virtual Domain Domain { get; set; }

    }
}
