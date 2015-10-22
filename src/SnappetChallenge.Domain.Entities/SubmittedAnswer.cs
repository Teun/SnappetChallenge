using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.Domain.Entities
{
    public class SubmittedAnswer : IEntity
    {
        public virtual long Id { get; set; }
        public virtual DateTime SubmittedOn { get; set; }
        public virtual bool IsCorrect { get; set; }
        public virtual int Progress { get; set; }
        public virtual Exercise Exercise { get; set; }
        public virtual User SubmittedBy { get; set; }
    }
}
