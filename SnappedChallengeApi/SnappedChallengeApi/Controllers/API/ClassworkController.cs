﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SnappedChallengeApi._Corelib.Extensions;
using SnappedChallengeApi.Controllers.API.Base;
using SnappedChallengeApi.DAL.Models;
using SnappedChallengeApi.Models.Bussiness;
using SnappedChallengeApi.Models.Commons;
using SnappedChallengeApi.Models.Commons.ApiCommons;
using SnappedChallengeApi.Services.Implementations;
using SnappedChallengeApi.Services.Interfaces;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Net;

namespace SnappedChallengeApi.Controllers.API
{
    public class ClassworkController : BaseController
    {
        private ClassworkService _service = null;

        public ClassworkController(IClassworkService classworkService)
        {
            if (classworkService.IsNullOrEmpty())
                throw new Exception(nameof(classworkService));

            _service = (ClassworkService)classworkService;
        }

        [HttpGet]
        [Route("classworks")]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(List<ExerciseResult>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, description: "no response")]
        public IActionResult GetClassworkResults()
        {
            QueryParameter qp = ParseQueryString();
            var records = _service.GetExerciseRecords(qp);
            return Ok(records);
        }

        [HttpPost]
        [Route("classworks/summary")]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(List<ClassworkSummary>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, description: "no response")]
        public IActionResult GetClassworkResults([FromBody]FilterParameter filterParam)
        {
            QueryParameter qp = ParseQueryString();
            var records = _service.GetClassworkSummary(filterParam.StartDate, filterParam.EndDate);
            return Ok(records);
        }
    }
}