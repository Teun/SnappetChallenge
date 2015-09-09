using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyReport.Entities
{
    public class LearningObjective : BaseEntity
    {
        [Index]
        [MaxLength(500)]
        public string Name { get; set; }
        public virtual Domain Domain { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
