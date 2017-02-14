using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.BusinessLogicLayer.BusinessObjects
{
    public class SubmittedAnswer
    {
        public long SubmittedAnswerId { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public bool IsCorrect { get; set; }
        public int Progress { get; set; }
        public long UserId { get; set; }
        public long ExerciseId { get; set; }
        public string Difficulty { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
    }
}
