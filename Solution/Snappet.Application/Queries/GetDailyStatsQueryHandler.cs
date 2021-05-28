using MediatR;
using Snappet.Application.Dtos;
using Snappet.Common;
using Snappet.Common.Helpers;
using Snappet.Data;
using Snappet.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snappet.Application.Queries
{
    public class GetDailyStatsQueryHandler : IRequestHandler<GetDailyStatsQuery, DailyStatsSummary>
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IAnswersRepository _answersRepository;

        public GetDailyStatsQueryHandler(IAnswersRepository answersRepository, IDateTimeProvider dateTimeProvider)
        {
            _answersRepository = answersRepository;
            _dateTimeProvider = dateTimeProvider;
        }
       
        public async Task<DailyStatsSummary> Handle(GetDailyStatsQuery request, CancellationToken cancellationToken)
        {
            //get answers submittedd by date
            List<AnswerEntity> answers = await _answersRepository.GetByDate(_dateTimeProvider.Now);

            //filter answers submitted before 11:30 (specified time )
            answers = answers.Where(a => a.SubmitDateTime <= _dateTimeProvider.Now).ToList();

            //calculate progress
            var progressByLearningObjective = GetStatsByLearningObjective(answers);
            var progressBySubjects = GetStatsBySubjects(answers);
            var progressByDomain = GetStatsByDomain(answers);
            var individualStudentStats = GetStatsByIndividualStudent(answers);
            
            //return summary of stats
            return new DailyStatsSummary
            {
                Domains = progressByDomain,
                LearningObjectives = progressByLearningObjective,
                Subjects = progressBySubjects,
                Students = individualStudentStats
            };

        }

        private List<LearningObjectiveStats> GetStatsByLearningObjective(List<AnswerEntity> answers)
        {
            var progressByLearningObjective =
                        answers
                            .GroupBy(a => a.LearningObjective)
                            .Select(x => new LearningObjectiveStats
                            {
                                LearningObjective = x.Key,
                                Progress = x.Average(p => p.Progress)
                            })
                            .ToList();

            return progressByLearningObjective;
        }

        private List<SubjectStats> GetStatsBySubjects(List<AnswerEntity> answers)
        {
            var progressBySubjects = answers
                        .GroupBy(x => x.Subject)
                        .Select(x => new SubjectStats
                        {
                            Subject = x.Key,
                            AnswersSubmitted = x.Count(),
                            CorrectAnswers = x.Where(x => x.Correct == 1).Count(),
                            InCorrectAnswers = x.Where(x => x.Correct != 1).Count(),
                            AverageDifficulty = x.Average(p => p.Difficulty == "NULL" ? 0 : double.Parse(p.Difficulty)),
                            AverageProgress = x.Average(p => p.Progress)
                        })
                        .ToList();
            return progressBySubjects;
        }

        private List<DomainStats> GetStatsByDomain(List<AnswerEntity> answers)
        {
            var progressByDomain =
                       answers
                           .GroupBy(x => x.Domain)
                           .Select(x => new DomainStats
                           {
                               DomainName = x.Key,
                               Progress = x.Average(p => p.Progress)
                           }).ToList();

            return progressByDomain;
        }

        private List<IndividualStudentStats> GetStatsByIndividualStudent(List<AnswerEntity> answers)
        {
            var progressByStudentGrps =
                        answers
                            .GroupBy(x => x.UserId);

            var individualStudentStats = new List<IndividualStudentStats>();
            foreach (var group in progressByStudentGrps)
            {
                var studentId = group.Key;
                var progressByStudent = group.ToList()
                            .GroupBy(x => x.Subject)
                            .Select(x => new IndividualStudentStats
                            {
                                StudentId = studentId,
                                Subject = x.Key,
                                AnswersSubmitted = x.Count(),
                                Correct = x.Where(a => a.Correct == 1).Count(),
                                InCorrect = x.Where(a => a.Correct != 1).Count()
                            }).ToList();
                individualStudentStats.AddRange(progressByStudent);
            }

            return individualStudentStats;
        }


    }
}
