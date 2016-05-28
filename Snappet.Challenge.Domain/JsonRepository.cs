using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Snappet.Challenge.Domain
{
    public class JsonRepository<T>
        : IRepository<T>
        where T : class
    {
        private readonly string _filePath;
        private IEnumerable<T> _cache;

        public JsonRepository(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<T> GetAll()
        {
            if (_cache == null)
            {
                using (var reader = new StreamReader(_filePath))
                {
                    _cache = JsonConvert.DeserializeObject<IEnumerable<T>>(reader.ReadToEnd());
                }
            }

            return _cache;
        }
    }
}