using System;
using CsvHelper.Configuration.Attributes;

namespace SnappetTrueskill
{
    public class ExerciseInteraction
    {
        public int SubmittedAnswerId { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public int Correct { get; set; }
        public int Progress { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }

        [NullValues("NULL")]
        public double? Difficulty { get; set; }

        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
    }
}
