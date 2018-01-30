using SnappetChallenge.Core.Interfaces;
using System;

namespace SnappetChallenge.Core.Entities
{
    public class Assessment
    {
        public long SubmittedAnswerId { get; set; }
        
        public DateTime SubmitDateTime { get; set; }
        public bool Correct { get; set; }


        public int Progress { get; set; }


        public long UserId { get; set; }


        public long ExerciseId { get; set; }


        public string Difficulty { get; set; }


        public string Subject { get; set; }


        public string Domain { get; set; }


        public string LearningObjective { get; set; }


    }
}
