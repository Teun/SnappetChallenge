using Newtonsoft.Json;
using System;

namespace TutorBoard.Dal.Dtos
{
    public class WorkDto
    {
        public long SubmittedAnswerId { get; set; }

        public DateTime SubmitDateTime { get; set; }

        public int Correct { get; set; }

        public int Progress { get; set; }
        
        public int UserId { get; set; }

        public int ExerciseId { get; set; }
        
        // @TODO: Fix "NULL" handling
        public string Difficulty { get; set; }

        public string Subject { get; set; }

        public string Domain { get; set; }
        
        public string LearningObjective { get; set; }
    }
}
