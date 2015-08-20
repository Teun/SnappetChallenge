using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnappetChallenge.DAL.Entities
{
    public class Exercise : BaseEntity
    {

        public long DomainId { get; set; }

        public long SubjectId { get; set; }

        public double Difficulty { get; set; }

        public string LearningObjective { get; set; }

        public virtual Domain Domain { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
