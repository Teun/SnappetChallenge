using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnappetChallenge.Models
{
    [Table("WorkData")]
    public class WorkDataModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubmittedAnswerId { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public int Correct { get; set; }
        public int Progress { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }

        [StringLength(200)]
        public string Difficulty { get; set; } = String.Empty;

        [StringLength(200)]
        public string Subject { get; set; } = String.Empty;

        [StringLength(200)]
        public string Domain { get; set; } = String.Empty;

        [StringLength(200)]
        public string LearningObjective { get; set; } = String.Empty;
    }
}
