using Snappet.Model;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;

namespace Snappet.Repository.DataProvider
{
    public interface IDataProvider
    {
        IEnumerable<Work> getAllData();
    }

    public class DataProvider : IDataProvider
    {
        private string _filePath;

        public DataProvider(string filePath)
        {
            _filePath = filePath;
        }

        public virtual IEnumerable<Work> getAllData()
        {
            string file = HttpContext.Current.Server.MapPath(_filePath);
            string Json = System.IO.File.ReadAllText(file);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            var result = serializer.Deserialize<List<Work>>(Json);
            return result;
        }
    }
}
