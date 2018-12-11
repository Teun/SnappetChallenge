using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnappetAPI.Models
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