using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SnappetChallenge.Mvc.Models;

namespace SnappetChallenge.Mvc.DataLayer
{
    public class WorkItemRespository: IWorkItemRespository
    {
        public WorkItemRespository()
        {
        }

        public WorkItem[] GetAll(Uri uri)
        {
            var wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            var data = wc.DownloadString(uri);
            return JsonConvert.DeserializeObject<WorkItem[]>(data);
        }
    }
}
