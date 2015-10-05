using Newtonsoft.Json;
using SnappetChallenge.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace SnappetChallenge.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = int.MaxValue)]
        public ActionResult Index(WorkFilter workFilter = WorkFilter.NoFilter)
        {
            var now = new DateTime(2015, 03, 24, 11, 30, 00, DateTimeKind.Utc);
           
            var workItems = ReadJsonWorkData();
            var workItemsToday = workItems.Where(w => w.SubmitDateTime.Date.Equals(now.Date) && w.SubmitDateTime <= now);
            var groupedByUser = workItemsToday.GroupBy(w => w.UserId);

            var workSummaryList = groupedByUser.Select(g => GroupBy(g, workFilter));
            
            return View(workSummaryList);
        }

        private static Func<Work, string> GetFilterExpression(WorkFilter workFilter)
        {
            var filterDictionary = new Dictionary<WorkFilter, Func<Work, string>>
            {
                { WorkFilter.NoFilter, d => string.Empty },
                { WorkFilter.Domain, d => d.Domain },
                { WorkFilter.LearningObjective, d => d.LearningObjective },
                { WorkFilter.Subject, d => d.Subject }
            };
            return filterDictionary[workFilter];
        }

        private static TotalWorkSummary GroupBy(IGrouping<int, Work> userData, WorkFilter workFilter)
        {
            var groupExpression = GetFilterExpression(workFilter);

            var groupedByObjective = userData.GroupBy(groupExpression);
            return new TotalWorkSummary
            {
                UserId = userData.Key,
                WorkSummaries = groupedByObjective.Select(CalculateSummary).OrderBy(s => s.ProgressToday),
                GroupedBy = workFilter
            };
        }

        private static WorkSummary CalculateSummary(IGrouping<string, Work> userData)
        {
            return new WorkSummary
            {
                TotalQuestions = userData.Count(),
                QuestionsOk = userData.Count(d => d.Correct),
                QuestionsNok = userData.Count(d => !d.Correct),
                ProgressToday = userData.Sum(d => d.Progress),
                AverageDifficulty = userData.Average(d => d.Difficulty),
                GroupedBy = userData.Key
            };
        }

        private static IEnumerable<Work> ReadJsonWorkData()
        {
            var dataPath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();            
            var jsonData = System.IO.File.ReadAllText(Path.Combine(dataPath, "work.json"));
            return JsonConvert.DeserializeObject<IList<Work>>(jsonData);            
        }
    }
}