using System.Collections.Generic;

namespace SnappetChallenge.DAL.Entities
{
    public class Subject : BaseEntity
    {
        public string SubjectName { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
