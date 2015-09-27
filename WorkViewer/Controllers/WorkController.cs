

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Web.Http;
namespace WorkViewer.Controllers
{
    public class WorkController : ApiController
    {
        public IHttpActionResult Get()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, "", "application/json");
            byte[] data = GetSubmittedAnswersData();
            if (data == null)
            {
                    return NotFound();
            }
            response.Content = new ByteArrayContent(data);
            return ResponseMessage(response);
        }

        private byte[] GetSubmittedAnswersData()
        {
            var data = MemoryCache.Default.Get("WorkData") as byte[];
            if (data == null)
            {
                data = LoadSubmittedAnswersData();

                MemoryCache.Default.Add(new CacheItem("WorkData", data), new CacheItemPolicy { SlidingExpiration = TimeSpan.FromMinutes(5) });
            }

            return data;
        }

        private byte[] LoadSubmittedAnswersData()
        {
            using (var fs = new FileStream("work.json", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var data = new byte[(int)fs.Length];
                fs.Read(data, 0, (int)fs.Length);
                return data;
            }
        }
    }
}
