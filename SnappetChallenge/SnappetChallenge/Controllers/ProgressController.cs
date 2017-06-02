using SnappetChallenge.DAL.Data;
using SnappetChallenge.DAL.Repositories;
using SnappetChallenge.DAL.Services;
using SnappetChallenge.DAL.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SnappetChallenge.Controllers
{
    [RoutePrefix("Progress")]
    public class ProgressController : ApiController
    {
        private readonly DateTime NOW = new DateTime(2015, 3, 24, 11, 30, 00);
        private IProgressService _progresService;

        public ProgressController(IProgressService progresService)
        {
            _progresService = progresService;
        }

        [Route("Assignments"), HttpGet]
        public IEnumerable<AssignmentProgress> GetAssignments()
        {
            return _progresService.GetAssignments(NOW.AddDays(-1), NOW);
        }

        [Route("Subjects"), HttpGet]
        public IEnumerable<SubjectProgress> GetAssignmentTypes()
        {
            return _progresService.GetGetSubjects(NOW.AddDays(-1), NOW);
        }
    }
}
