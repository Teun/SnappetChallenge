﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using Snappet.Reporting.Application;
using Snappet.Reporting.Application.Domain.Model;
using Snappet.Reporting.Application.Dto;

namespace Snappet.Reporting.Storage.Sql
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly ReportingDbContext _reportingDbContext;

        private IQueryable<Answer> _answers => _reportingDbContext.Answers.AsNoTracking();

        public AnswerRepository(ReportingDbContext reportingDbContext)
        {
            _reportingDbContext = reportingDbContext;
        }

        public IQueryable<CorrectAnswersPerUserDto> CorrectAnswersPerUser()
        {
            return _answers
                .GroupBy(x => new { x.UserId, x.Subject, x.LearningObjective })
                .Select(s => new CorrectAnswersPerUserDto
                {
                    UserId = s.Key.UserId,
                    Subject = s.Key.Subject,
                    LearningObjective = s.Key.LearningObjective,
                    Count = s.Count(x => x.Correct),
                    Total = s.Count()
                })
                .OrderBy(a => a.UserId).ThenBy(a => a.Subject).ThenBy(a => a.Count);
        }

        public IQueryable<CorrectAnswersPerLearningObjectiveDto> CorrectAnswersPerLearningObjective()
        {
            return _answers
                .GroupBy(x => new { x.Subject, x.LearningObjective })
                .Select(s => new CorrectAnswersPerLearningObjectiveDto
                {
                    Subject = s.Key.Subject,
                    LearningObjective = s.Key.LearningObjective,
                    Count = s.Count(x => x.Correct),
                    Total = s.Count()
                })
                .OrderBy(a => a.Subject).ThenBy(a => a.LearningObjective);
        }
    }
}
