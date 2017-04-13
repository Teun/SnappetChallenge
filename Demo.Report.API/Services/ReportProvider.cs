// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ReportProvider.cs" company="Noordhoff Uitgevers BV">
//      © Noordhoff Uitgevers BV, the Netherlands
//  </copyright>
//  <author>Valiukevich, Evgeny</author>
// --------------------------------------------------------------------------------------------------------------------
namespace Demo.Report.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Extensions;
    using Model;

    public class ReportProvider
    {
        private readonly IEnumerable<UserWorkItem> items;

        public ReportProvider(IEnumerable<UserWorkItem> items)
        {
            this.items = items;
        }

        public ClassOverviewContract PrepareClassOverviewReport(DateTime today)
        {
            var filteredItems = items.Where(x => x.SubmitDateTime.Date == today.Date).ToList();
            var report = from item in filteredItems
                         group item by new
                         {
                             item.Subject,
                             item.Domain
                         }
                into grouped
                         select new SubjectDomainUserOverviewContract()
                         {
                             Domain = grouped.Key.Domain,
                             Subject = grouped.Key.Subject,
                             ObjectiveUserOverviews = (from objectives in grouped 
                                                       group objectives by objectives.LearningObjective into objectivesGrouped
                                                       select new SubjectObjectiveUserOverviewContract()
                                                       {
                                                            Objective = objectivesGrouped.Key,
                                                            UserProgressOverviews = (
                                                                from users in objectivesGrouped
                                                                group users by users.UserId
                                                                into usersGrouped
                                                                select new UserProgressOverviewContract()
                                                                {
                                                                    UserId = usersGrouped.Key,
                                                                    ExcerciseProgressOverviews = (
                                                                        from exercises in usersGrouped
                                                                        group exercises by exercises.ExerciseId
                                                                        into exercisesGrouped
                                                                        select new ExerciseProgressOverviewContract()
                                                                        {
                                                                            ExerciseId = exercisesGrouped.Key,
                                                                            Answers = (from ex in exercisesGrouped
                                                                                    select new ExerciseAnswersOverviewContract()
                                                                                    {
                                                                                        AnswerId = ex.SubmittedAnswerId,
                                                                                        Correct = ex.Correct,
                                                                                        Progress = ex.Progress,
                                                                                    }).OrderByDescending(x => x.Progress),
                                                                            SlidingAverageProgressHistory = BuildSlidingAverageHistoryForItem(items, usersGrouped.Key, exercisesGrouped.Key),
                                                                            ProgressHistory = BuildProgressHistoryForItem(items, usersGrouped.Key, exercisesGrouped.Key),
                                                                        }
                                                                    ).OrderBy(x => x.Warning).ThenBy(x=>x.Zero).ThenByDescending(x => x.Answers.Max(y => y.Progress))
                                                                }).OrderByDescending(x => x.ExcerciseProgressOverviews.Count(y => y.Warning))
                                                           
                                                       })
                         };
            var reportModel = new ClassOverviewContract()
            {
                CurrentDate = today,
                Subjects = report
            };
            return reportModel;
        }

        private float[] BuildSlidingAverageHistoryForItem(IEnumerable<UserWorkItem> dataSet, long userId, long exerciseId)
        {
            var slidingAverageProgressHistoryForItem = dataSet
                .Where(x => x.UserId == userId && x.ExerciseId == exerciseId)
                .Select(x => x.Progress)
                .CumulativeMovingAverage()
                .ToArray();
            return slidingAverageProgressHistoryForItem;
        }

        private float[] BuildProgressHistoryForItem(IEnumerable<UserWorkItem> dataSet, long userId, long exerciseId)
        {
            var progressHistoryForItem = dataSet
                .Where(x => x.UserId == userId && x.ExerciseId == exerciseId)
                .Select(x => x.Progress)
                .ToArray();
            return progressHistoryForItem;
        }
    }
}