using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Snappet.ImportConsole.JsonConverters
{
    public class NullStringConverter:JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) return null;
            if (reader.TokenType == JsonToken.String)
            {
                decimal attempt;
                if (decimal.TryParse(reader.Value.ToString(), out attempt)) return attempt;
                return null;
            }
            if (reader.TokenType == JsonToken.Float) return Convert.ToDecimal(reader.Value);
            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return  objectType== typeof(decimal?);
        }
    }
}
