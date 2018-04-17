namespace EFGetStarted.AspNetCore.NewDb.Models
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Attribute for converting Difficulty
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.JsonConverter{System.Decimal?}" />
    public class DifficultyConverter : JsonConverter<decimal?>
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, decimal? value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read. If there is no existing value then <c>null</c> will be used.</param>
        /// <param name="hasExistingValue">The existing value has a value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        public override decimal? ReadJson(JsonReader reader, Type objectType, decimal? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var s = (string)reader.Value;

            if (decimal.TryParse(s, out decimal res))
            {
                return res;
            }

            return null;
        }
    }
}