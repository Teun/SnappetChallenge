using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SnappetChallenge.Builders;
using SnappetChallenge.Core;
using SnappetChallenge.Models;

namespace SnappetChallenge.Controllers
{
    [Produces("application/json")]
    [Route("api/LearningObjective")]
    public class LearningObjectiveController : Controller
    {
        private readonly ILearningObjectiveSubmittedAnswersFilterBuilder submittedAnswersFilterBuilder;
        private readonly ILearningObjectivesProvider learningObjectivesProvider;
        private readonly ILearningObjectiveDtoBuilder learningObjectiveDtoBuilder;

        public LearningObjectiveController(ILearningObjectiveSubmittedAnswersFilterBuilder submittedAnswersFilterBuilder,
            ILearningObjectivesProvider learningObjectivesProvider,
            ILearningObjectiveDtoBuilder learningObjectiveDtoBuilder)
        {
            this.submittedAnswersFilterBuilder = submittedAnswersFilterBuilder;
            this.learningObjectivesProvider = learningObjectivesProvider;
            this.learningObjectiveDtoBuilder = learningObjectiveDtoBuilder;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<LearningObjectiveDto> GetLearningObjectives([FromQuery] LearningObjectivesFilterDto filter)
        {
            var internalFilter = submittedAnswersFilterBuilder.Build(filter);
            var learningObjectives = learningObjectivesProvider.GetLearningObjectivesStatistics(internalFilter);
            return learningObjectives.Select(learningObjectiveDtoBuilder.Build)
                .ToArray();
        }
    }
}