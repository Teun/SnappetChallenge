using SnappetChallenge.WebAPI.Models;
using SnappetChallenge.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SnappetChallenge.WebAPI.Controllers
{
    public class LearningObjectivesController : ApiController
    {
        private SubmittedAnswerService submittedAnswerService;

        public LearningObjectivesController()
        {
            this.submittedAnswerService = new SubmittedAnswerService();
        }

        public IEnumerable<LearningObjective> Get(DateTime from, DateTime to)
        {
            return this.submittedAnswerService.GetSubmittedAnswers(from, to)
                .GroupBy(x => x.LearningObjective)
                .Select(x => new LearningObjective(x))
                .OrderByDescending(x => x.FirstQuestionAnswered);
        }
    }
}