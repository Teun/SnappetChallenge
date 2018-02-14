using Snappet.Business.IManager;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Snappet.REST.Service.Controllers
{
    public class WorkController : ApiController
    {
        private IWorkManager _workManager;
        public WorkController(IWorkManager workManager)
        {
            _workManager = workManager;
        }

        [HttpGet]
        public HttpResponseMessage GetStudentResult()
        {
            try
            {
                var searchResult = _workManager.GetStudentWork();
                if (searchResult != null)
                    return Request.CreateResponse(HttpStatusCode.OK, new { TotalCount = searchResult.Count(), Data = searchResult.Take(200)});
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Data found.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
