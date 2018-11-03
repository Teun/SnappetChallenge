using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappedChallengeApi.Models.Bussiness
{
    /// <summary>
    /// Main data model class for work.json parse TODO summary
    /// </summary>
    public class ExerciseResult
    {
        public int SubmittedAnswerId { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public byte Correct { get; set; }
        public int Progress { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public int Difficulty { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
    }
}
