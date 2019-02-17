using System;
using System.Globalization;
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;

namespace Dashboard.CsvImport
{
    // should match the CSV structure
    public class AnswerCsvRow
    {
        public int SubmittedAnswerId { get; set; }

        [DateTimeStyles(DateTimeStyles.AssumeUniversal)]
        public DateTimeOffset SubmitDateTime { get; set; }

        // what's the hell does "3" mean in that column? I assume it's correct but need to clarify
        [BooleanTrueValues("1", "3")]
        public bool Correct { get; set; }

        public int Progress { get; set; }

        public int UserId { get; set; }

        public int ExerciseId { get; set; }

        [NullValues("NULL")]
        public float? Difficulty { get; set; }

        public string Subject { get; set; }

        public string Domain { get; set; }

        public string LearningObjective { get; set; }
    }
}
