using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Snappet.Reporting.Application;
using Snappet.Reporting.Application.Dto;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

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
        public Task<List<CorrectAnswersPerSubjectDto>> CorrectAnswersPerSubject(DateTimeOffset date)
        {
            var result = _answerRepository.CorrectAnswersPerSubject(date.UtcDateTime.Date);
            return result.ToListAsync();
        }

        [HttpGet]
        public Task<List<CorrectAnswersPerLearningObjectiveDto>> CorrectAnswersPerLearningObjective(DateTimeOffset date)
        {
            var result = _answerRepository.CorrectAnswersPerLearningObjective(date.UtcDateTime.Date);
            return result.ToListAsync();
        }

        [HttpGet]
        public Task<List<CorrectAnswersPerUserDto>> CorrectAnswersPerUser(DateTimeOffset date)
        {
            var result = _answerRepository.CorrectAnswersPerUser(date.UtcDateTime.Date);
            return result.ToListAsync();
        }
    }
}

