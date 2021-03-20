using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnappetChallenge.Repository.JsonConvertors
{
    /// <summary>
    /// Trims a string before converting with DateTime.Parse.
    /// </summary>
    public class DateTimeTrimWhitespaceConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString().Trim());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }
}
