using Newtonsoft.Json;
using System;

namespace Snappet.Model
{
    public class StudentSkill
    {
        [JsonProperty("SubmittedAnswerId")]
        public int SubmittedAnswerId { get; set; }

        [JsonProperty("SubmitDateTime")]
        public DateTime SubmitDateTime { get; set; }

        [JsonProperty("Correct")]
        public bool Correct { get; set; }

        [JsonProperty("Progress")]
        public int Progress { get; set; }

        [JsonProperty("UserId")]
        public int UserId { get; set; }

        [JsonProperty("ExerciseId")]
        public int ExerciseId { get; set; }

        [JsonProperty("Difficulty")]
        public string Difficulty { get; set; }

        [JsonProperty("Subject")]
        public string Subject { get; set; }

        [JsonProperty("Domain")]
        public string Domain { get; set; }

        [JsonProperty("LearningObjective")]
        public string LearningObjective { get; set; }
    }
}
