using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Snappet.Common.Configurations;
using Snappet.Contracts.Assesments.Contracts;
using Snappet.Contracts.Assesments.Models;
using Snappet.Contracts.Assesments.ViewModels;
using Snappet.Contracts.ConfigrationSettings;
using Snappet.Contracts.Databases;

namespace SnappetSolution.Controllers
{
    [Produces("application/json")]
    [Route("api/assesments")]
    public class AssesmentController : Controller
    {
        private readonly IStorage _storage;
        private readonly IResultsProcessor _resultsProcessor;     
        private readonly DateTimeOffset _dateTimeNow;

        public AssesmentController(IStorage storage, IResultsProcessor resultsProcessor, IOptions<ConfigurationSettings> settings)
        {
            _storage = storage;
            _resultsProcessor = resultsProcessor;
            _dateTimeNow = settings.Value.DateTimeNow;
        }

        [HttpGet]
        [Route("work-results")]
        public ClassModel GetWorkResults()
        {
            var result =  _resultsProcessor.GetProgress(_storage.GetWorksResult(), _dateTimeNow);

            return result;
        }
    }
}