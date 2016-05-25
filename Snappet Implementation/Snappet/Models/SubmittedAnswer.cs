namespace Snappet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SubmittedAnswer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubmittedAnswerId { get; set; }

        public DateTime SubmitDateTime { get; set; }

        public byte Correct { get; set; }

        public int Progress { get; set; }

        public int UserId { get; set; }

        public int ExerciseId { get; set; }

        public long? Difficulty { get; set; }

        [Required]
        [StringLength(255)]
        public string Subject { get; set; }

        [Required]
        [StringLength(255)]
        public string Domain { get; set; }

        [Required]
        [StringLength(255)]
        public string LearningObjective { get; set; }

        public virtual User User { get; set; }
    }
}
