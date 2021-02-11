using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMaster.Models
{
    [Table("Works")]
    public class Work
    {
        [Key] public int SubmittedAnswerId { get; set; }

        public DateTimeOffset SubmitDateTime { get; set; }
        public int Correct { get; set; }
        public int Progress { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public double? Difficulty { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }

        [ForeignKey(nameof(UserId))] public User User { get; set; }
    }
}