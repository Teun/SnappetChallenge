using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Model
{
    public class Report
    {
        public int CorrectAttempts { get; set; }
        public int IncorrectAttempts { get; set; }
        public string Key { get; set; }
        public int NoOfStudents { get; set; }
        public int NoOfExercises { get; set; }
    }
}
