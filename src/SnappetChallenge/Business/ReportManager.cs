using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SnappetChallenge.Models;
using SnappetChallenge.Models.ViewModels;

namespace SnappetChallenge.Business
{
    public class ReportManager
    {
        private readonly StudyContext _context;
        private readonly IMapper _mapper;

        public ReportManager(StudyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CorrectAnswerReport BuildAnswerReport(CorrectAnswerRequest request)
        {
            //DateTime today = DateTime.Parse("2015-03-24 11:30:00Z"); // Just like in description of task

            IEnumerable<AnsweredDateResult> answeredResults = _context.Answers
                .Where(x => x.SubmitedDate <= request.ToDate.ToUniversalTime() && x.SubmitedDate >= request.FromDate.ToUniversalTime())
                .Where(x => x.Exercise.LearningObjective.Domain.Subject.Name == request.Subject)
                .Where(x => string.IsNullOrEmpty(request.Domain) || x.Exercise.LearningObjective.Domain.Name == request.Domain)
                .Where( x => string.IsNullOrEmpty(request.LearningObjective) || x.Exercise.LearningObjective.Name == request.LearningObjective)
                .GroupBy(x => x.SubmitedDate.Date)
                .Select(group => new AnsweredDateResult()
                {
                    CorrectCount = group.Count(x => x.Correct),
                    IncorrectCount = group.Count(x => !x.Correct),
                    AnsweredDate = group.Key
                }).ToList();

            return new CorrectAnswerReport()
            {
                AnsweredDateResults = answeredResults,
                MaxAnsweredCount = answeredResults.Select(x=>x.CorrectCount + x.IncorrectCount)
                    .DefaultIfEmpty(0)
                    .Max()
            };
        }

        public FilterOption GetFilters()
        {
            FilterOption filter = new FilterOption
            {
                Subjects = _mapper.Map<IEnumerable<SubjectFilter>>(_context.Subjects
                    .Include(subject => subject.Domains)
                    .ThenInclude(domain => domain.LearningObjectives))
            };
            return filter;
        }
    }
}
