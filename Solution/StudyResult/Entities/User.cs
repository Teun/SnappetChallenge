using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyReport.Entities
{
    public class User : BaseEntity
    {
        [Index]
        public int UserId { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
