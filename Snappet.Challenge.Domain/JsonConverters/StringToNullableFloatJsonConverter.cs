using Newtonsoft.Json;
using System;

namespace Snappet.Challenge.Domain.JsonConverters
{
    internal class StringToNullableFloatJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(float?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            if (reader.TokenType == JsonToken.Float)
                return reader.Value;

            if (reader.TokenType == JsonToken.String)
            {
                if (string.IsNullOrEmpty((string)reader.Value))
                    return null;
                float num;
                if (float.TryParse((string)reader.Value, out num))
                    return num;

                return null;
            }
            throw new JsonReaderException(string.Format("Unexcepted token {0}", reader.TokenType));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }

}
