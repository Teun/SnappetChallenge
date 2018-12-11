using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Model
{
    public class Student
    {
        public int Id { get; set; }
        public int Progress { get; set; }
        public int NoOfExercise { get; set; }
        public int NoOfAttempts { get; set; }
        public int WrongAttemptCount { get; set; }
        public int RightAttemptCount { get; set; }
    }
}
