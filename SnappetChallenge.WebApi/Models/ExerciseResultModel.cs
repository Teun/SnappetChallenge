namespace SnappetChallenge.WebApi.Models
{
    using System;

    using Newtonsoft.Json;

    public class ExerciseResultModel
    {
        [JsonProperty("SubmittedAnswerId")]
        public int SubmittedAnswerId { get; set; }

        [JsonProperty("SubmitDateTime")]
        public DateTime SubmitDateTime { get; set; }

        [JsonProperty("Correct")]
        public bool Correct { get; set; }

        [JsonProperty("Progress")]
        public sbyte Progress { get; set; }

        [JsonProperty("UserId")]
        public int UserId { get; set; }

        [JsonProperty("ExerciseId")]
        public int ExerciseId { get; set; }

        [JsonProperty("Difficulty")]
        public float Difficulty { get; set; }

        [JsonProperty("Subject")]
        public string Subject { get; set; }

        [JsonProperty("Domain")]
        public string Domain { get; set; }

        [JsonProperty("LearningObjective")]
        public string LearningObjective { get; set; }
    }
}
