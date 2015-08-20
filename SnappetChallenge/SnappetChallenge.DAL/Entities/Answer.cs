using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnappetChallenge.DAL.Entities
{
    using System;

    public class Answer : BaseEntity
    {
        //[Key, ForeignKey("Student")]
        public long StudentId { get; set; }

        //[Key, ForeignKey("Exercise")]
        public long ExerciseId { get; set; }

        public bool Correct { get; set; }

        public DateTime SubmitDateTime { get; set; }

        public double Progress { get; set; }

        public virtual Exercise Exercise { get; set; }

        public virtual Student Student { get; set; }
    }
}
