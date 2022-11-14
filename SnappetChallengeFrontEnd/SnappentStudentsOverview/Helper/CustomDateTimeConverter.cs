using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnappetChallenge.Client.Helper
{
    public class CustomDateTimeConverter : JsonConverter<DateTime>
    {

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            //Don't implement this unless you're going to use the custom converter for serialization too
            throw new NotImplementedException();
        }
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString());
        }
    }
}
