using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Snappet.Models;

namespace Snappet.Services
{
    public class WorkResultService: IWorkResultService
    {
        private List<WorkResult> workResults = new List<WorkResult>();

        public WorkResultService()
        {            
            string path = System.Web.HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["JsonFilePath"]);
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                workResults = JsonConvert.DeserializeObject<List<WorkResult>>(json);
            }
        }

        public IList<WorkResult> GetResults()
        {
            return workResults;
        }

        public IList<WorkResult> GetResults(DateTime startDate, DateTime endDate)
        {
            return workResults.Where(w => w.SubmitDateTime >= startDate && w.SubmitDateTime < endDate).ToList();
        }
    }
}
