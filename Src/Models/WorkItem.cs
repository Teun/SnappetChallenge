using MongoDB.Bson;
using System;

namespace StudentsAPI.WebApi.Models
{
    /// <summary>
    /// Hold information about progress of a student in a given date
    /// </summary>
    public class WorkItem
    {
        public ObjectId Id { get; set; }
        public int SubmittedAnswerId { get; set; }
        public DateTime? SubmitDateTime { get; set; }
        public string Correct { get; set; }
        public string Progress { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public string Difficulty { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
    }
}
