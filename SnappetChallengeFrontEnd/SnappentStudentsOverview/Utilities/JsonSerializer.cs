using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SnappetChallenge.Client.Utilities
{
    public class JsonSerializer
    {
        public static string Serialize<T>(T obj)
        {
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.DateFormatString = "yyyy-MM-ddTHH:mm:ssZ";
            return JsonConvert.SerializeObject(obj, obj.GetType(), Formatting.None, settings);
        }

        public static T Deserialize<T>(string json)
        {
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.DateFormatString = "yyyy-MM-ddTHH:mm:ssZ";

            T obj = JsonConvert.DeserializeObject<T>(json, settings);

            return obj;
        }
    }
}
