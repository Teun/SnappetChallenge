using JW.SnappetChallenge.Data;
using JW.SnappetChallenge.Data.Repositories;
using JW.SnappetChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JW.SnappetChallenge.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index(DateTime ?date)
        {
            DateTime dateFilter = date ?? new DateTime(2015, 3, 2); // use default date

            // Get repo
            IDashboardRepository dashboardRepository = new DashboardRepository();

            // Get subject list for the date
            List<string> subjects = dashboardRepository.GetSubjects(dateFilter);

            DashboardIndexViewModel model = new DashboardIndexViewModel()
            {
                Date = dateFilter,
                Subjects = subjects
            };

            return View(model);
        }

        // GET: Subject summary view
        public ActionResult SubjectSummary(string subject, DateTime ?date)
        {
            DateTime dateFilter = date ?? new DateTime(2015, 3, 2); // use default date

            // Get repo
            IDashboardRepository dashboardRepository = new DashboardRepository();

            // Get progress data from repo sort by total average progress on subject
            List<AggregatedProgressData> subjectProgress = dashboardRepository.GetSubjectData(subject, dateFilter);

            // Populate list with user progress
            IEnumerable<Progress> p = from apd in subjectProgress
                                      group apd by apd.UserId into groupedUserProgress
                                      select new Progress()
                                      {
                                          Description = groupedUserProgress.Key.ToString(),
                                          TotalAnwers = groupedUserProgress.Count(),
                                          CorrectAnswers = groupedUserProgress.Where(up => up.Correct).Count(),
                                          OverallProgress = groupedUserProgress.Sum(up => up.Progress)
                                      } into userProgress
                                      orderby userProgress.OverallProgress ascending
                                      select userProgress;

            // Populate model
            SubjectSummaryViewModel model = new SubjectSummaryViewModel()
            {
                Subject = subject,
                Date = dateFilter,
                UserProgress = p
            };

            return View(model);
        }

        // GET: User summary view
        public ActionResult UserSummary(int userId, string subject, DateTime ?date)
        {
            DateTime dateFilter = date ?? new DateTime(2015, 3, 2); // use default date

            // Get repo
            IDashboardRepository dashboardRepository = new DashboardRepository();

            // Get user data from repo
            List<AggregatedProgressData> learningOjectiveProgress = dashboardRepository.GetUserData(userId, subject, dateFilter);

            // Populate list with user progress: overall progress per learning objective
            IEnumerable<Progress> p = from apd in learningOjectiveProgress
                                      group apd by apd.LearningObjective into groupedLearningObjectiveProgress
                                      select new Progress()
                                      {
                                          Description = groupedLearningObjectiveProgress.Key,
                                          TotalAnwers = groupedLearningObjectiveProgress.Count(),
                                          CorrectAnswers = groupedLearningObjectiveProgress.Where(up => up.Correct).Count(),
                                          OverallProgress = groupedLearningObjectiveProgress.Sum(up => up.Progress)
                                      } into userProgress
                                      orderby userProgress.OverallProgress ascending
                                      select userProgress;

            // Populate model
            UserSummaryViewModel model = new UserSummaryViewModel()
            {
                User = userId.ToString(),
                Date = dateFilter,
                LearningObjectiveProgress = p
            };

            return View(model);
        }
    }
}