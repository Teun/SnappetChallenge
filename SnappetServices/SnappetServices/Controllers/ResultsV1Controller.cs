using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SnappetServices.Services;

namespace SnappetServices.Controllers
{
    [Route("api/snappet/v1/results")]
    [ApiController]
    public class ResultsV1Controller : ControllerBase
    {
        private readonly IResultsServices resultsServices;

        public ResultsV1Controller(IResultsServices resultsServices)
        {
            this.resultsServices = resultsServices;
        }

        /// <summary>
        /// Gets all the results.
        /// </summary>
        /// <param name="date">Pass in the date for filter</param>
        /// <returns></returns>
        [HttpGet]        
        public ActionResult<IEnumerable<string>> Get([FromQuery]string date)
        {
            return this.Ok(this.resultsServices.GetAllResults(date));
        }        
    }
}
