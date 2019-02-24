using Newtonsoft.Json;
using SnappetDomain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SnappetRepository.Services
{
    public class SnappetRepositorySeeder : ISnappetRepositorySeeder
    {
        public List<LearningData> ReadLearningData()
        {
            var result = Enumerable.Empty<LearningData>();
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "SnappetRepository.Data.work.json";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader sr = new StreamReader(stream))
            {
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    result = serializer.Deserialize<List<LearningData>>(reader);
                }
            }
            return result.ToList();
        }
    }

    public interface ISnappetRepositorySeeder
    {
        List<LearningData> ReadLearningData();
    }
}
