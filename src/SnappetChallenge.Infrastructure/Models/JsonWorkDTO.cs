using Newtonsoft.Json;
using System;
using System.Globalization;

namespace SnappetChallenge.Infrastructure.Models
{
    public class JsonWorkDTO
    {
        public int SubmittedAnswerId { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public bool Correct { get; set; }
        public int Progress { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        [JsonConverter(typeof(DifficultyConverter))]
        public decimal Difficulty { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
    }

    public class DifficultyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value.ToString() == "NULL")
                return 0m;

            if (reader.ValueType == typeof(int) || reader.ValueType == typeof(decimal) || reader.ValueType == typeof(Int32))
                return (decimal)reader.Value;
            else if (reader.ValueType == typeof(string))
                return decimal.Parse(reader.Value.ToString(), CultureInfo.InvariantCulture);

            return reader.Value;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
