using Snappet.Challenge.Web.Dto;
using SnappetChallenge.Domain.Entities;
using SnappetChallenge.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
namespace Snappet.Challenge.Web.Api
{
    public class SubjectsController : ApiController
    {
        private readonly ISubjectService subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        [HttpGet]
        public HttpResponseMessage GetTimeSpentInPercentagesBySubject(DateTime from, DateTime until)
        {
            // preferrably return a dto here, just like a regular controller returns a viewmodel instead of an entity
            var percentages = subjectService.GetTimeSpentInPercentagesBySubject(from, until);

            var returnValue = percentages.Select(kvp => new { Description = kvp.Key, Value = kvp.Value });

            return Request.CreateResponse(HttpStatusCode.OK, returnValue);
        }
    }
}