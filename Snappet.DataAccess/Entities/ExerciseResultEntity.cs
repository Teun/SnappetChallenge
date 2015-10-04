
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snappet.DataAccess
{

    [Table("ExerciseResult")]
    public  class ExerciseResultEntity
    {
        public ExerciseResultEntity() 
        {
        }

        [Key]
        public int Id { get; set; }

        public int SubmittedAnswerId { get; set; }
        public System.DateTime SubmitDateTime { get; set; }
        public bool IsCorrect { get; set; }
        public int Progress { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public decimal Difficulty { get; set; }
        public int SubjectId { get; set; }
        public int DomainId { get; set; }
        public int LearningObjectiveId { get; set; }

        public virtual DomainEntity Domain { get; set; }
        public virtual SubjectEntity Subject { get; set; }
        public virtual LearningObjectiveEntity LearningObjective { get; set; }
    }
}


