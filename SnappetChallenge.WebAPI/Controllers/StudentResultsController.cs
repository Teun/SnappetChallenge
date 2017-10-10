using SnappetChallenge.WebAPI.Models;
using SnappetChallenge.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SnappetChallenge.WebAPI.Controllers
{
    public class StudentResultsController : ApiController
    {
        private SubmittedAnswerService submittedAnswerService;

        public StudentResultsController()
        {
            this.submittedAnswerService = new SubmittedAnswerService();
        }

        public IEnumerable<StudentResult> Get(DateTime from, DateTime to, int studentId)
        {
            return this.submittedAnswerService.GetSubmittedAnswers(from, to)
                .Where(x => x.UserId == studentId)
                .GroupBy(x => new { x.Subject, x.Domain })
                .Select(x => new StudentResult(x));
        }
    }
}