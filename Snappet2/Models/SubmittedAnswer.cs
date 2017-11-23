using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snappet2.Models
{
    public class SubmittedAnswer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubmittedAnswerId { get; set; }
        [Display(Name = "Date/Time")]
        public DateTime SubmitDateTime { get; set; }
        public int Correct { get; set; }
        public int Progress { get; set; }
        [Display(Name = "User Id")]
        public int UserId { get; set; }
        [Display(Name = "Excercise Id")]
        public int ExerciseId { get; set; }
        public string Difficulty { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }

        [Display(Name = "Learning Objective")]
        public string LearningObjective { get; set; }
    }
}
