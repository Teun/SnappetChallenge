using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappedChallengeApi.DAL.Models
{
    /// <summary>
    /// Main entity model class for Exercise Results
    /// </summary>
    public class ExerciseResult
    {
        /// <summary>
        /// Sample Data Property
        /// </summary>
        public int SubmittedAnswerId { get; set; }
        /// <summary>
        /// Sample Data Property Exercise Finish Date
        /// </summary>
        public DateTime SubmitDateTime { get; set; }
        /// <summary>
        /// Sample Data Property Correct / Wrong Flag
        /// </summary>
        public int Correct { get; set; }
        /// <summary>
        /// Sample Data Property Progress
        /// </summary>
        public decimal Progress { get; set; }
        /// <summary>
        /// Sample Data Property UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Sample Data Property Exercise Id
        /// </summary>
        public int ExerciseId { get; set; }
        /// <summary>
        /// private difficulty propert
        /// </summary>
        private string _difficulty;
        /// <summary>
        /// Sample Data Property Difficulty
        /// </summary>
        public string Difficulty
        {
            get
            {
                return _difficulty;
            }
            set
            {
                _difficulty = value;
                var parsedResult = 0;
                if (int.TryParse(value, out parsedResult))
                {
                    DifficultyValue = parsedResult;
                }
                else
                {
                    DifficultyValue = 0;
                }
            }
        }
        /// <summary>
        /// Sample Data Property Difficulty Decimal
        /// </summary>
        public decimal DifficultyValue { get; set; }
        /// <summary>
        /// Sample Data Property Subject
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Sample Data Property Domain
        /// </summary>
        public string Domain { get; set; }
        /// <summary>
        /// Sample Data Property Learning Objective
        /// </summary>
        public string LearningObjective { get; set; }
    }
}
