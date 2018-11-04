using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SnappedChallengeApi._Corelib.Extensions;
using SnappedChallengeApi.Controllers.API.Base;
using SnappedChallengeApi.DAL.Models;
using SnappedChallengeApi.Filters;
using SnappedChallengeApi.Models.Bussiness;
using SnappedChallengeApi.Models.Commons.ApiCommons;
using SnappedChallengeApi.Services.Implementations;
using SnappedChallengeApi.Services.Interfaces;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Net;

namespace SnappedChallengeApi.Controllers.API
{
    /// <summary>
    /// Classworks Controller Main Data Controller for this exercise inherits base controller
    /// </summary>
    public class ClassworkController : BaseController
    {
        /// <summary>
        /// Classwork service instance
        /// </summary>
        private ClassworkService _service = null;

        /// <summary>
        /// constructor classworkService is being injected
        /// </summary>
        /// <param name="classworkService"></param>
        public ClassworkController(IClassworkService classworkService)
        {
            if (classworkService.IsNullOrEmpty())
                throw new Exception(nameof(classworkService));

            _service = (ClassworkService)classworkService;
        }

        /// <summary>
        /// Basic get api for classwork exercise data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("classworks")]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(List<ExerciseResult>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, description: "no response")]
        [ClientAuthorize()]
        public IActionResult GetClassworkResults()
        {
            QueryParameter qp = ParseQueryString();
            var records = _service.GetExerciseRecords(qp);
            return Ok(records);
        }

        /// <summary>
        /// Exercise's Main api for date interval queries for the UI
        /// </summary>
        /// <param name="filterParam"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("classworks/summary")]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(List<ClassworkSummary>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, description: "no response")]
        [ClientAuthorize()]
        public IActionResult GetClassworkResults([FromBody]FilterParameter filterParam)
        {
            QueryParameter qp = ParseQueryString();
            var records = _service.GetClassworkSummary(filterParam.StartDate, filterParam.EndDate);
            return Ok(records);
        }
    }
}
