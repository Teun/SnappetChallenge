using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snappet.WebAPI.Models
{
    public class LearningObjectiveProgress
    {
        public string LearningObjective { get; set; }
        public List<Student> Participants { get; set; }
        public int TotalExercise { get; set; }
        public int TotalAttempts { get; set; }
        public string Performance { get; set; }
        public int MasteryPercentage { get; set; }
    }
}