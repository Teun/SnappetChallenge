using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.Core
{
    public class JsonFileDeserilizer : IJsonFileDeserilizer
    {
        public async Task<T> Deserilize<T>(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (var sourceStream = new FileStream(filePath, FileMode.Open,
                    FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
                using (var streamReader = new StreamReader(sourceStream))
                using (var reader = new JsonTextReader(streamReader))
                {
                    if (await reader.ReadAsync())
                    {
                        var serializer = new JsonSerializer();

                        return serializer.Deserialize<T>(reader);
                    }
                }

                return default(T);
            }
            else
            {
                throw new FileNotFoundException("Json file not found", filePath);
            }
        }
    }
}
