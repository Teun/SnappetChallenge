using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnappetChallenge.Models
{
    public class ExerciseSummary
    {
        public List<KeyValuePair<string, int>> Domains { get; set; }
        public List<KeyValuePair<string, int>> LearningObjectives { get; set; }
        public List<KeyValuePair<string, int>> Subjects { get; set; }
        public int ExerciseCount { get; set; }
        public int CorrectCount { get; set; }
        public int StudentCount { get; set; }
        public List<KeyValuePair<string, int>> SubmittedDateRanges { get; set; }

    }
}