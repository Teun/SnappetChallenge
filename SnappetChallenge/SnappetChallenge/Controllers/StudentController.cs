using SnappetChallenge.Contracts;
using SnappetChallenge.Contracts.Abstractions;
using SnappetChallenge.Contracts.Adapters;
using SnappetChallenge.Models;
using SnappetChallenge.Service;
using SnappetChallenge.Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http;

namespace SnappetChallenge.Controllers.Web
{
    [RoutePrefix("api")]
    public class StudentController : ApiController
    {
        public string AzureUrl => WebConfigurationManager.AppSettings["arure_url"];

        // GET api/values
        [Route("getWork")]
        public async Task<IHttpActionResult> Get(DateTime from, DateTime to, int page, int pageSize, long studentId)
        {
            if (to < from || from > to)
                return BadRequest();

            IClassWorkService classWorkService = new ClassWorkService(AzureUrl); // with more time, Ioc could be done with dependency injection 
            IModelAdapter<IEnumerable<Work>, IEnumerable<WorkDto>> adapter = new ClassWorkAdapter();

            var works = await classWorkService.RetrieveClassWork(from, to);

            if (studentId > 0)
                works = works.Where(x => x.UserId == studentId).ToArray();

            var worksTranferedObjects = adapter.Transform(works).Skip(pageSize * page).Take(pageSize);

            return Ok(worksTranferedObjects);
        }

        [Route("getStudents")]
        public async Task<IHttpActionResult> GetStudentdIds()
        {
            IClassWorkService classWorkService = new ClassWorkService(AzureUrl); // with more time, Ioc could be done with dependency injection 
            var ids = await classWorkService.RetrieveStudentsIds();

            return Ok(ids);
        }
    }
}
