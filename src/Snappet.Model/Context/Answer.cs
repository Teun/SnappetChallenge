using Snappet.Model.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Model
{
    public class Answer : IBasicContext
    {
        [Key]
        public int ID { get; set; }

        public DateTime SubmitDateTime { get; set; }

        public bool Correct { get; set; }

        public int Progress { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int ExerciseId { get; set; }

        public double Difficulty { get; set; }

        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

        public int DomainID { get; set; }
        public Domain Domain { get; set; }

        public int LearningObjectiveID { get; set; }
        public LearningObjective LearningObjective { get; set; }
    }
}
