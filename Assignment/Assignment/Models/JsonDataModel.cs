#region Imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

#region namespace
namespace Assignment.Models
{
    #region class
    /// <summary>
    /// Model to bind Json Data
    /// </summary>
    public class JsonDataModel
    {

        public long SubmittedAnswerId { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public int Correct { get; set; }
        public int Progress { get; set; }
        public long UserId { get; set; }
        public long ExerciseId { get; set; }
        public string Difficulty { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
    }
    #endregion
}
#endregion