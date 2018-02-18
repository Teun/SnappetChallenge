using System.Collections.Generic;
using System.Linq;
using Snappet.Challenge.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Newtonsoft.Json;
using System;

namespace Snappet.Challenge.Infrastructure
{
    public class WorkService : IWorkService
    {
        private static IEnumerable<WorkItem> _allWorkItems = null;
        private static bool _isDataAvailable = true;

        public WorkService(IHostingEnvironment env)
        {
            if (_allWorkItems == null)
                GetAllWorkItems(env.WebRootPath);
        }

        private void GetAllWorkItems(string webRoot)
        {
            var file = Path.Combine(webRoot, "work.json");
            var json = File.ReadAllText(file);
            try
            {
                _allWorkItems = JsonConvert.DeserializeObject<IEnumerable<WorkItem>>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DateTimeZoneHandling = DateTimeZoneHandling.Utc });                
            }
            catch
            {
                _isDataAvailable = false;
            }
        }

        public bool IsDataAvailable()
        {
            return _isDataAvailable;
        }

        public WorkSearchResults Search(WorkQuery query)
        {
            var allItems = _allWorkItems
                .Where(item => {
                    var dateClientTimeZone = item.SubmitDateTime.AddMinutes(query.ClientTimeZoneOffset);
                    return dateClientTimeZone.Year == query.DateSubmitted.Year 
                        && dateClientTimeZone.Month == query.DateSubmitted.Month 
                        && dateClientTimeZone.Day == query.DateSubmitted.Day
                        && (query.Correct == null || query.Correct == item.Correct)
                        && (query.Domain == null || query.Domain == item.Domain)
                        && (query.Subject == null || query.Subject == item.Subject)
                        && (query.LearningObjective == null || query.LearningObjective == item.LearningObjective)
                        && (query.Exercise == null || query.Exercise == item.ExerciseId)
                        && (query.User == null || query.User == item.UserId);
                });
            
            var totalCount = allItems.Count();
            var pagesCount = (int)Math.Floor((double)totalCount / query.ItemsPerPage) + (totalCount % query.ItemsPerPage > 0 ? 1 : 0);
            var correctRate = totalCount == 0 ? 0 : Math.Round((double)(allItems.Count(item => item.Correct) * 100 / totalCount), 2);
            var avgProgress = totalCount == 0 ? 0 : Math.Round(allItems.Average(item => item.Progress), 2);
            var items = allItems
                .OrderBy(item => item.SubmittedAnswerId)
                .Skip(query.PageNumber * query.ItemsPerPage)
                .Take(query.ItemsPerPage)
                .ToArray();
            var result = new WorkSearchResults {
                TotalCount = totalCount,
                PagesCount = pagesCount,
                CorrectRate = correctRate,
                AvgProgress = avgProgress,
                WorkItems = items
            };

            return result;
        }

        public IEnumerable<DateTime> GetDateList()
        {
            return _allWorkItems.Select(i => new DateTime(i.SubmitDateTime.Year, i.SubmitDateTime.Month, i.SubmitDateTime.Day)).Distinct();
        }

        public WorkQueryLists GetWorkQueryLists(DateTime date, int offset)
        {
            var workItemsByDate = _allWorkItems.Where(item => {
                var dateClientTimeZone = item.SubmitDateTime.AddMinutes(offset);
                return dateClientTimeZone.Year == date.Year
                    && dateClientTimeZone.Month == date.Month
                    && dateClientTimeZone.Day == date.Day;
            });
            return new WorkQueryLists {
                Subjects = workItemsByDate.Select(i => i.Subject).Distinct(),
                Domains = workItemsByDate.Select(i => i.Domain).Distinct(),
                LearningObjectives = workItemsByDate.Select(i => i.LearningObjective).Distinct(),
                Correct = workItemsByDate.Select(i => i.Correct).Distinct(),
                Users = workItemsByDate.Select(i => i.UserId).Distinct(),
                Exercises = workItemsByDate.Select(i => i.ExerciseId).Distinct()
            }; 
                    
        }
    }
}
