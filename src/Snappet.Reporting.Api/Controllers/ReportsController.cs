using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Snappet.Reporting.Application;
using Snappet.Reporting.Application.Dto;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Snappet.Reporting.Api.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IAnswerRepository _answerRepository;

        public ReportsController(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        [HttpGet]
        public Task<List<CorrectAnswersPerLearningObjectiveDto>> GetCorrectAnswersPerLearningObjective()
        {
            var result = _answerRepository.CorrectAnswersPerLearningObjective();
            return result.ToListAsync();
        }

        [HttpGet]
        public Task<List<CorrectAnswersPerUserDto>> GetCorrectAnswersPerUser()
        {
            var result = _answerRepository.CorrectAnswersPerUser();
            return result.ToListAsync();
        }
    }
}

