using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Snappet.Data.DataObjects;

namespace Snappet.Data.QueryRepositories
{
    public class JsonDataRepository : IDataRepository
    {
        private static readonly JsonSerializer Serializer = new JsonSerializer();

        public JsonDataRepository()
        {
            Serializer.MissingMemberHandling = MissingMemberHandling.Error;
        }

        public IEnumerable<JsonData> GetDataFromJson(string fileName)
        {
            using (var fileStream = File.OpenText(fileName))
            {
                foreach (var responseJson in DeserializeFromJson<JsonData>(fileStream))
                {
                    yield return responseJson;
                }
            }
        }

        private IEnumerable<T> DeserializeFromJson<T>(TextReader readerStream)
        {
            using (var reader = new JsonTextReader(readerStream))
            {
                if (!reader.Read() || reader.TokenType != JsonToken.StartArray)
                {
                    throw new Exception("Expected start of array in the deserialized json string");
                }

                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.EndArray)
                    {
                        break;
                    }
                    var item = Serializer.Deserialize<T>(reader);
                    yield return item;
                }
            }
        }
    }
}
