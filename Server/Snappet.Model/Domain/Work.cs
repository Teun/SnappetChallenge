using System;
using System.Globalization;

namespace Snappet.Model.Domain
{
    public class Work
    {
        public int SubmittedAnswerId { get; set; }

        private string _submitDateTime;

        public string SubmitDateTime
        {
            get { return _submitDateTime; }
            set
            {
                _submitDateTime = value;
                try
                {
                    var date = Convert.ToDateTime(value);
                    SubmitDate = date.Date;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public DateTime SubmitDate { get; set; }

        public bool Correct { get; set; }

        public int Progress { get; set; }

        public int UserId { get; set; }

        public int ExerciseId { get; set; }

        public double? DifficultyDouble { get; set; }

        private string _difficulty;
        public string Difficulty
        {
            get { return _difficulty; }
            set
            {
                try
                {
                    DifficultyDouble = "NULL".Trim().Equals(value.ToUpper().Trim()) ? 0 : Convert.ToDouble(value);
                    _difficulty = value;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public string Subject { get; set; }

        private string _domain;

        public string Domain
        {
            get { return _domain; }
            set { _domain = "-".Trim().Equals(value.Trim()) ? "General" : value; }
        }

        public string LearningObjective { get; set; }

    }
}
