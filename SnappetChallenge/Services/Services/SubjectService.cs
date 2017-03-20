using System.Linq;
using System.Collections.Generic;
using Services.Dto;
using Services.Repositories;
using System;
using Services.Entities;
using Services.Parsers;

namespace Services.Services
{
    public class SubjectService : ISubjectService
    {
        public const string Dash = "-";

        private readonly IWorkRepository _workRepository;
        private readonly IDateTimeService _dateTimeService;

        public SubjectService(IWorkRepository workRepository, IDateTimeService dateTimeService)
        {
            _workRepository = workRepository;
            _dateTimeService = dateTimeService;
        }

        public IReadOnlyCollection<Subject> GetSubjects()
        {
            var timestamp = _dateTimeService.GetCurrent();
            return _workRepository.GetCurrentWork(timestamp)
                .OrderBy(w => w.Subject)
                .GroupBy(w => w.Subject)
                .Select(w => new Subject
                {
                    Name = w.Key,
                    AverageProgress = CalculateAverageProgress(w),
                    Domains = w
                        .Select(d => d.Domain)
                        .Distinct()
                        .Where(d => !string.Equals(d, Dash, StringComparison.OrdinalIgnoreCase))
                        .OrderBy(d => d)
                        .ToArray()
                })
                .ToArray();
        }

        public SubjectStatistics GetSubject(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentNullException(nameof(subject));
            }

            var timestamp = _dateTimeService.GetCurrent();
            var domainStatistics = _workRepository.GetCurrentWork(timestamp)
                .Where(w => w.Subject == subject)
                .OrderBy(d => d.Domain)
                .GroupBy(d => d.Domain)
                .Select(w => new DomainStatistics
                {
                    Name = w.Key,
                    LearningObjectives = w
                        .GroupBy(o => o.LearningObjective)
                        .Select(o => new LearningObjectiveStatistics
                        {
                            Name = o.Key,

                            TotalCount = o.Count(),
                            CorrectCount = o.Count(a => a.Correct),
                            IncorrectCount = o.Count(a => !a.Correct),

                            AverageProgress = CalculateAverageProgress(o),
                            AverageDifficulty = CalculateAverageDifficulty(o),
                        })
                        .OrderByDescending(o => o.TotalCount)
                        .ToArray()
                })
                .ToArray();

            return new SubjectStatistics
            {
                Name = subject,
                Domains = domainStatistics
            };
        }

        private static int CalculateAverageProgress(IEnumerable<Work> work)
        {
            return (int)Math.Round(work.Average(a => a.Progress), MidpointRounding.AwayFromZero);
        }

        private static int CalculateAverageDifficulty(IEnumerable<Work> work)
        {
            var averageDifficulty = work
                .Select(w => DifficultyParser.Parse(w.Difficulty))
                .Where(d => d.HasValue)
                .Average(d => d.Value);

            return (int)Math.Round(averageDifficulty, MidpointRounding.AwayFromZero);
        }
    }
}
