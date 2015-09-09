using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyReport.Entities
{
    public class Domain : BaseEntity
    {
        [Index]
        [MaxLength(500)]
        public string Name { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<LearningObjective> LearningObjectives { get; set; }
    }
}
