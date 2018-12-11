using Snappet.Model;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;

namespace Snappet.Repository.Provider
{
    public interface IReportProvider
    {
        IEnumerable<Work> getAllReports();
    }

    public class ReportProvider : IReportProvider
    {
        private string _filePath;

        public ReportProvider(string filePath)
        {
            _filePath = filePath;
        }

        public virtual IEnumerable<Work> getAllReports()
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
