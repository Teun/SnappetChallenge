using SnappetChallenge.Interfaces;
using SnappetChallenge.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System;

namespace SnappetChallenge.Controllers
{
    [RoutePrefix("api/workresults")]
    public class WorkResultsController : ApiController
    {
        /// <summary>
        /// Interface for WorkResults service. Using interface to avoid tight coupling using DI
        /// </summary>
        IWorkResultsService service = null;

        public WorkResultsController(IWorkResultsService service)
        {
            this.service = service;
        }

        //[HttpPost]
        ////[Route("getresultsfordate")]
        //public List<WorkResultModel> Post(DateTime date)
        //{
        //    //return this.service.GetAllResults().Take(20).ToList();
        //    return this.service.GetResultsByDay(date);
        //}


        [HttpPost] 
        [Route("getresultsfordate")]
        public List<WorkResultModel> GetResultsForSpecificDate([FromBody] DateTime date) //HttpRequestMessage request
        {
            return this.service.GetResultsByDay(date.ToLocalTime());
        }
    }
}
