using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepositories.Data
{
    /// <summary>
    /// Represents an individual answer
    /// </summary>
    public class Answer
    {
        /// <summary>
        /// Gets or sets the number of correct answers
        /// </summary>
        /// <remarks>For a single answer, this value can only be 0 or 1</remarks>
        public int Correct { get; set; }

        /// <summary>
        /// Gets or sets the domain associated with this answer
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Gets orsets the difficulty rating of the answer
        /// </summary>
        public string Difficulty { get; set; }

        /// <summary>
        /// Gets or sets the ID of the exercise this answer was a part of
        /// </summary>
        public int ExerciseId { get; set; }

        /// <summary>
        /// Gets or sets the learning objective associated with this answer
        /// </summary>
        public string LearningObjective { get; set; }

        /// <summary>
        /// Gets or sets the value that indicates the student's progress
        /// </summary>
        public int Progress { get; set; }

        /// <summary>
        /// Gets or sets the subject associated with this answer
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the ID of the submitted answer
        /// </summary>
        public int SubmittedAnswerId { get; set; }

        /// <summary>
        /// Gets or sets the date/time the answer was submitted
        /// </summary>
        public DateTime SubmitDateTime { get; set; }

        /// <summary>
        /// Gets or sets the ID of the student who answered
        /// </summary>
        public int UserId { get; set; }
    }
}
