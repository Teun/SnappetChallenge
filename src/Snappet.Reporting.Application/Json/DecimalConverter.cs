using System;
using System.Globalization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Snappet.Reporting.Application.Json
{
    public class DecimalConverter : JsonConverter
    {
        private readonly ILogger _logger;

        public DecimalConverter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(DecimalConverter));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            double result;

            if(reader?.Value == null)
            {
                _logger.LogWarning("Null value converted to 0.");
                return 0.0;
            }

            if (double.TryParse(reader.Value.ToString(), NumberStyles.Number, CultureInfo.InvariantCulture, out result))
                return result;

            if (reader.Value.ToString().Equals("NULL", StringComparison.OrdinalIgnoreCase))
            {
                _logger.LogWarning($"String with value {reader.Value} converted to 0.");
                return 0.0;
            }
            throw new JsonSerializationException("Unexpected token value: '" + reader.Value + "'");
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(double) || objectType == typeof(double?);
        }
    }
}
