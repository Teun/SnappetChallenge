using System.IO;
using Newtonsoft.Json;

namespace Snappet.Challenge.Web.Mvc.Extensions
{   
    public static class ObjectExtensions
    {
        /// <summary>
        /// Extension method to serialize object to Json
        /// </summary>
        /// <param name="obj">Object to serialize</param>
        /// <returns>Serialized object Json string</returns>
        public static string ToJson(this object obj)
        {
            JsonSerializer serializer = JsonSerializer.Create(new JsonSerializerSettings());
            var sw = new StringWriter();
            serializer.Serialize(sw, obj);
            return sw.ToString();
        }
    }
}