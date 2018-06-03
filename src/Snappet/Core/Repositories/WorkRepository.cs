using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Snappet.Core.Model;
using Snappet.Core.Configuration;

namespace Snappet.Core.Repositories
{
    public interface IWorkRepository
    {
        IEnumerable<Work> GetWorksSubmittedBetween(DateTime start, DateTime end);
    }

    public class WorkRepository : IWorkRepository
    {
        private List<Work> works;

        public WorkRepository(SnappetSettings settings)
        {
            this.works = LoadJson<List<Work>>(settings.JsonDataPath);
        }
        
        public IEnumerable<Work> GetWorksSubmittedBetween(DateTime start, DateTime end)
        {
            return this.works.Where(w => w.SubmitDateTime > start && w.SubmitDateTime < end);
        }

        private static T LoadJson<T>(string path) 
        {
            using (var stream = File.OpenText(path))
            {
                var serializer = JsonSerializer.CreateDefault(new JsonSerializerSettings 
                {
                    // Ignore for now deserialization errors  
                    // (eg. due to field Difficult containing 'NULL')
                    Error = (s,e) => e.ErrorContext.Handled = true
                });

                return (T)serializer.Deserialize(stream, typeof(T));
            }
        }
    }
}