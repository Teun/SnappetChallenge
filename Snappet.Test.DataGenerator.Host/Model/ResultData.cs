using System;

namespace Snappet.Test.DataGenerator.Host.Model
{
    public class ResultDataJson
    {
        public int SubmittedAnswerId { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public bool Correct { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public int Progress { get; set; }
        public string Difficulty { get; set; }

        public decimal? DifficultyValue
        {
            get
            {
                decimal value;
                if (!decimal.TryParse(Difficulty, out value))
                {
                    return null;
                }
                return value;
            }
        }

        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
    }
}