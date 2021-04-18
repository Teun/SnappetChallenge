using System;
using System.Linq;
using BlCore.DataProviders;
using BlCore.Properties;
using BlCore.ReportServices.Models;
using BlCore.TimeServices;

namespace BlCore.ReportServices
{
    class ReportService : IReportService
    {
        private readonly IDataProvider _dataProvider;

        public ReportService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public ObjectivesReport GetObjectivesReport(DateTime begin, DateTime end)
        {
            ValidateIntervals(begin, end, out DateTime utcBegin, out DateTime utcEnd);

            var query = _dataProvider
                .Executions
                .Get()
                .Where(i => utcBegin <= i.SubmitDateTime && i.SubmitDateTime < utcEnd)
                .GroupBy(i => new
                {
                    i.Domain,
                    i.Subject,
                    i.LearningObjective
                });

            var rawItems = query.ToArray();

            var items = rawItems
                .Select(i => new ObjectivesReportItem
                {
                    Domain = i.Key.Domain,
                    Objective = i.Key.LearningObjective,
                    Subject = i.Key.Subject,
                    Count = i.Count()
                })
                .OrderBy(i => i.Domain)
                .ThenBy(i => i.Subject)
                .ThenBy(i => i.Objective)
                .ToArray();

            var total = new ObjectivesReportTotal
            {
                ObjectiveCount = rawItems.Length
            };

            var report = new ObjectivesReport
            {
                Items = items,
                Total = total
            };

            return report;
        }

        public OneObjectiveReport GetOneObjectiveReport(string objective, DateTime begin, DateTime end)
        {
            ValidateIntervals(begin, end, out DateTime utcBegin, out DateTime utcEnd);

            var query = _dataProvider
                .Executions
                .Get()
                .Where(i => utcBegin <= i.SubmitDateTime && i.SubmitDateTime < utcEnd && i.LearningObjective == objective);

            var items = query
                .Select(i => new OneObjectiveReportItem
                {
                    User = i.UserId,
                    Progress = i.Progress
                })
                .OrderBy(i => i.User)
                .ToArray();

            var total = new OneObjectiveReportTotal
            {
                Objective = objective,
                UsersCount = items.Length,
                Progress = items.Sum(i => i.Progress)
            };
            
            if (total.UsersCount < 1)
            {
                total.AverageProgress = 0;
            }
            else
            {
                total.AverageProgress = total.Progress / total.UsersCount;
            }

            var report = new OneObjectiveReport
            {
                Items = items,
                Total = total
            };

            return report;
        }

        public OneUserReport GetOneUserReport(int userId, DateTime begin, DateTime end)
        {
            ValidateIntervals(begin, end, out DateTime utcBegin, out DateTime utcEnd);

            var query = _dataProvider
                .Executions
                .Get()
                .Where(i => utcBegin <= i.SubmitDateTime && i.SubmitDateTime < utcEnd && i.UserId == userId);

            var rawItems = query.ToArray();

            var items = rawItems
                .Select(i =>
                    new OneUserReportItem
                    {
                        ActionDt = i.SubmitDateTime,
                        Correct = i.Correct > 0 ? Resources.Yes : Resources.No,
                        Difficulty = i.Difficulty,
                        User = i.UserId,
                        Exercise = i.ExerciseId.ToString(),
                        Domain = i.Domain,
                        Subject = i.Subject,
                        Objective = i.LearningObjective,
                        Progress = i.Progress
                    })
                .OrderBy(i => i.ActionDt)
                .ToArray();

            var total = new OneUserReportTotal
            {
                User = userId.ToString(),
                ItemsCount = items.Length,
                Progress = rawItems.Sum(f => f.Progress)
            };
            if (total.ItemsCount < 1)
            {
                total.AverageProgress = 0;
            }
            else
            {
                total.AverageProgress = total.Progress / total.ItemsCount;
            }
            var report = new OneUserReport
            {
                Items = items,
                Total = total
            };

            return report;
        }

        public UsersReport GetUsersReport(DateTime begin, DateTime end)
        {
            ValidateIntervals(begin, end, out DateTime utcBegin, out DateTime utcEnd);

            var query = _dataProvider
                .Executions
                .Get()
                 .Where(i => utcBegin <= i.SubmitDateTime && i.SubmitDateTime < utcEnd);

            var items = query
                .GroupBy(i => i.UserId)
                .Select(i => new UsersReportItem
                {
                    User = i.Key,
                    Progress = i.Sum(j => j.Progress)
                })
                .OrderBy(i => i.User)
                .ToArray();

            var total = new UsersReportTotal
            {
                UsersCount = items.Length,
                Progress = items.Sum(f => f.Progress)
            };
            if (total.UsersCount < 1)
            {
                total.AverageProgress = 0;
            }
            else
            {
                total.AverageProgress = total.Progress / total.UsersCount;
            }


            var report = new UsersReport
            {
                Items = items,
                Total = total
            };

            return report;
        }

        private void ValidateIntervals(DateTime begin, DateTime end, out DateTime utcBegin, out DateTime utcEnd)
        {
            if (begin > end)
            {
                throw new Exception(Resources.BeginGreaterEnd);
            }

            if (end.Subtract(begin) > TimeSpan.FromDays(31))
            {
                throw new Exception(Resources.TooBigInterval);
            }

            if (begin == end)
            {
                end = begin.Date.AddDays(1);
            }

            utcBegin = TimeService.ConvertTimeZoneToUtc(begin, TimeService.NetherlandsTimeZone);

            utcEnd = TimeService.ConvertTimeZoneToUtc(end, TimeService.NetherlandsTimeZone);
        }
    }
}
