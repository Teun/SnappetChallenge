using System.Collections.Generic;

namespace SnappetChallenge.DAL.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }

        public double AverageProgress { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
