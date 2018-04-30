using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Snappet.Common.JsonConverters
{
    public class CustomJsonConverter
    {
        public static T DeserializeFromStream<T>(Stream stream)
        {
            var serializer = new JsonSerializer();

            using (var sr = new StreamReader(stream))
            using (var jsonTextReader = new JsonTextReader(sr))
            {                
                return serializer.Deserialize<T>(jsonTextReader);
            }
        }
    }
}