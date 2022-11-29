using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeacherApp.Models
{
    public class Work
    {
        [Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int SubmittedAnswerId { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public int Correct { get; set; }
        public int Progress { get; set; }
        [ForeignKey("Student")]
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public string? Difficulty { get; set; }
        public string? Subject { get; set; }
        public string? Domain { get; set; }
        public string? LearningObjective { get; set; }

    }
}