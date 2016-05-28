using System;
using Newtonsoft.Json;
using Snappet.Challenge.Domain.JsonConverters;

namespace Snappet.Challenge.Domain.Entities
{
    public class StudentResult
    {
        public ulong SubmittedAnswerId { get; set; }

        public DateTime SubmitDateTime { get; set; }

        public bool Correct { get; set; }

        public short Progress { get; set; }

        public uint UserId { get; set; }

        public ulong ExerciseId { get; set; }

        [JsonConverter(typeof(StringToNullableFloatJsonConverter))]
        public float? Difficulty { get; set; }

        public string Subject { get; set; }

        public string Domain { get; set; }

        public string LearningObjective { get; set; }
    }
}
