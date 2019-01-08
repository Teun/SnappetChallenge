using Snappet.Model.DataProvider;
using Snappet.Model.Domain;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using Newtonsoft.Json;

namespace Snappet.DataProvider.DataProvider
{
    public class JsonDataProvider : IWorkDataProvider
    {
        private string _filePath;

        public JsonDataProvider(string filePath)
        {
            _filePath = filePath;
        }
        public virtual IEnumerable<Work> GetWorkDetails()
        {
            IEnumerable<Work> items = null;
            using (StreamReader r = new StreamReader(_filePath))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Work>>(json);
            }

            return items;
        }
    }
}
