using System;
using System.Collections.Generic;
using System.Linq;
using Snappet.Challenge.Domain;
using Snappet.Challenge.Domain.Entities;
using Snappet.Challenge.Services.Dto;
using Snappet.Challenge.Services.Extensions;

namespace Snappet.Challenge.Services
{
    public class StudentResultAnalysisService : IStudentResultAnalysisService
    {
        private readonly IRepository<StudentResult> _studentResultRepository;

        public StudentResultAnalysisService(IRepository<StudentResult> studentResultRepository)
        {
            _studentResultRepository = studentResultRepository;
        }

        /// <summary>
        /// Returns collection of unique subjects and pair of subject/domains containing input query
        /// </summary>
        public IEnumerable<SubjectDomainDto> SearchForSubectDomains(string query)
        {
            var allEntries = _studentResultRepository.GetAll().ToArray();

            var uniqueSubjects = allEntries
                .Where(sr => sr.Subject.Contains(query, StringComparison.OrdinalIgnoreCase) 
                            || query.Contains(sr.Subject, StringComparison.OrdinalIgnoreCase))
                .Select(sr => new SubjectDomainDto { Subject = sr.Subject, Domain = string.Empty })
                .Distinct();

            var uniqueSubjectDomains = allEntries
                .Where(sr => sr.Domain.Contains(query, StringComparison.OrdinalIgnoreCase)
                            || sr.Subject.Contains(query, StringComparison.OrdinalIgnoreCase)
                            || query.Contains(sr.Subject, StringComparison.OrdinalIgnoreCase)
                            || query.Contains(sr.Domain, StringComparison.OrdinalIgnoreCase))
                .Select(sr => new SubjectDomainDto { Subject = sr.Subject, Domain = sr.Domain })
                .Distinct();

            return uniqueSubjects.Union(uniqueSubjectDomains);               
        }

        /// <summary>
        /// Return daily statistics per learning objective for defined time span.
        /// </summary>
        public IEnumerable<LearningObjectiveStatisticsDto> GetClassLearningObjectiveStatisticsFor(string subject, string domain,
            DateTime? @from, DateTime? to)
        {
            return _studentResultRepository.GetAll()
                .Where(sr => !@from.HasValue || sr.SubmitDateTime.Date >= @from.Value.Date)
                .Where(sr => !to.HasValue || sr.SubmitDateTime.Date <= to.Value.Date)
                .Where(sr => sr.Subject.Equals(subject))
                .Where(sr => string.IsNullOrWhiteSpace(domain) || sr.Domain.Equals(domain))
                .GroupBy(sr => new
                {
                    sr.Subject,
                    sr.Domain,
                    sr.LearningObjective
                })
                .Select(gsr => new LearningObjectiveStatisticsDto
                {
                    LearningObjective = gsr.Key.LearningObjective,
                    DailyStatistics = gsr
                        .GroupBy(g => new
                        {
                            g.SubmitDateTime.Year,
                            g.SubmitDateTime.Month,
                            g.SubmitDateTime.Day
                        })
                        .Select(dgsr => new DailyClassStatisticsDto
                        {
                            AmountOfProgressedStudents = dgsr
                                                            .GroupBy(u => u.UserId)
                                                            .Count(gu => gu.Sum(guu => guu.Progress) > 0),
                            AvgDifficulty = dgsr.Sum(sr => sr.Difficulty ?? 0) / dgsr.Count(),
                            Correct = dgsr.Count(sr => sr.Correct),
                            Incorrect = dgsr.Count(sr => !sr.Correct),
                            AvgProgress = (float)dgsr.Sum(sr => sr.Progress) / dgsr.Count(),
                            SubmitDateTime = new DateTime(dgsr.Key.Year, dgsr.Key.Month, dgsr.Key.Day)
                        })
                });             
        }
    }
}
