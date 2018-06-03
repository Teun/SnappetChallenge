using System;
using System.Collections.Generic;
using System.Linq;
using Snappet.Core.Repositories;
using Snappet.Reporting.Model;

namespace Snappet.Reporting.Services
{
    public interface IWorkStatisticsService 
    {
        IEnumerable<WorkStatisticsByTopic> GetWorkStatisticsByTopic(DateTime start, DateTime end);
    }

    public class WorkStatisticsService : IWorkStatisticsService
    {
        private readonly IWorkRepository repository;

        public WorkStatisticsService(IWorkRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<WorkStatisticsByTopic> GetWorkStatisticsByTopic(DateTime start, DateTime end)
        {
            var works = this.repository.GetWorksSubmittedBetween(start, end);

            // Group Subject, then by Domain and then by Learning Objective
            foreach (var worksBySubject in works.GroupBy(w => w.Subject))
            foreach (var worksByDomain in worksBySubject.GroupBy(s => s.Domain))
            foreach (var worksByObjective in worksByDomain.GroupBy(d => d.LearningObjective))
            {
                // Group by ExerciseId in order to calculate the number of distinct exercises 
                // and the average exercise difficulty for each Learning Objective group
                var worksByExercise = worksByObjective.GroupBy(o => o.ExerciseId);

                yield return new WorkStatisticsByTopic
                {
                    Subject = worksBySubject.Key,
                    Domain = worksByDomain.Key,
                    LearningObjective = worksByObjective.Key,
                    TotalAnswers = worksByObjective.Count(),
                    TotalProgress = worksByObjective.Sum(w => w.Progress),
                    TotalCorrect = worksByObjective.Sum(w => w.Correct),
                    TotalExercises = worksByExercise.Count(),
                    AverageDifficulty = worksByExercise.Average(e => e.First().Difficulty)
                };
            }
        }
    }
}