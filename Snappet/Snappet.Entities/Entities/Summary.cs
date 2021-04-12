using System;

namespace Snappet.Entities.Entities
{
    public class Summary
    {
        /// <summary>
        /// Summary id
        /// </summary>
        public int Id { set; get; }
        
        /// <summary>
        /// Submitted answer id
        /// </summary>
        public int SubmittedAnswerId { get; set; }
        
        /// <summary>
        /// Submit date time 
        /// </summary>
        public DateTime? SubmitDateTime { get; set; }
        
        /// <summary>
        /// Correct 
        /// </summary>
        public int Correct { get; set; }
        
        /// <summary>
        /// Progress
        /// </summary>
        public int Progress { get; set; }
        
        /// <summary>
        /// User id
        /// </summary>
        public int UserId { get; set; }
        
        /// <summary>
        /// Exercise id
        /// </summary>
        public int ExerciseId { get; set; }
        
        /// <summary>
        /// Difficulty
        /// </summary>
        public string Difficulty { get; set; }
        
        /// <summary>
        /// Subject
        /// </summary>
        public string Subject { get; set; }
        
        /// <summary>
        /// Domain
        /// </summary>
        public string Domain { get; set; }
        
        /// <summary>
        /// Learning objective
        /// </summary>
        public string LearningObjective { get; set; }
    }
}
