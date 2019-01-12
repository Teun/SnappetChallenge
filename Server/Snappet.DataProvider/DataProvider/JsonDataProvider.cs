using Snappet.Model.DataProvider;
using Snappet.Model.Domain;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using Newtonsoft.Json;

namespace Snappet.DataProvider.DataProvider
{
    public class JsonDataProvider : IDataProvider
    {
        public JsonDataProvider()
        {
        }
        string _filePath = null;
        public string FilePath
        {
            get
            {
                return _filePath = _filePath ?? HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["filePath"]);
            }
            set { _filePath = value; }
        }
        public virtual IEnumerable<Work> GetWorkDetails()
        {
            IEnumerable<Work> items = null;
            if (!string.IsNullOrEmpty(FilePath))
            {
                using (StreamReader r = new StreamReader(FilePath))
                {
                    string json = r.ReadToEnd();
                    items = JsonConvert.DeserializeObject<List<Work>>(json);
                }
            }

            return items;
        }
    }
}
