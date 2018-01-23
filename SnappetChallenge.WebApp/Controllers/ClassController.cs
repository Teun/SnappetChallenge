using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Core.Interfaces.Services;
using SnappetChallenge.WebApp.Models;

namespace SnappetChallenge.WebApp.Controllers
{
    public class ClassController : Controller
    {
        #region Fields
        private readonly IWorkResultService _workResultService;
        #endregion

        #region Constructors
        public ClassController(IWorkResultService workResultService)
        {
            _workResultService = workResultService;
        }

        #endregion

        #region Actions

        public ActionResult TodayWork()
        {
            TodayResultViewModel todayResultViewModel = new TodayResultViewModel();
            var result = _workResultService.GetTodayWorkResults();
            todayResultViewModel.numberOfStudents = result.Count(x => x.UserId > 0);
            todayResultViewModel.numberOfQuestions = result.Sum(x => x.NumberOfQuestions);
            todayResultViewModel.correctRatio = Math.Round((100 * result.Sum(x => x.CorrectAnswers) / (decimal)todayResultViewModel.numberOfQuestions), 2);
            todayResultViewModel.incorrectRatio = Math.Round((100 * result.Sum(x => x.IncorrectAnswers) / (decimal)todayResultViewModel.numberOfQuestions), 2);
            todayResultViewModel.progressAverage = Math.Round((result.Sum(x => x.TotalProgress) / (decimal)todayResultViewModel.numberOfStudents), 2);
            return View(todayResultViewModel);
        }

        public ActionResult Search()
        {
            var viewModel = new SearchViewModel();
            viewModel.Students = _workResultService.GetAllStudents();
            viewModel.Subjects = _workResultService.GetAllSubjects();
            viewModel.LearningObjectives = _workResultService.GetAllLearningObjectives();
            viewModel.Domains = _workResultService.GetAllDomains();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult GetSearchResult(DateTime? startDate,
            DateTime? endDate,
            int? userId,
            string subject,
            string domain,
            string learningObjective)
        {
            var result = _workResultService.SearchWorkResults(startDate, endDate, null, null, userId, null, subject,domain, learningObjective);
            
            var serializer = new JavaScriptSerializer {MaxJsonLength = Int32.MaxValue};
            var resultData = new { data = result };
            return new ContentResult
            {
                Content = serializer.Serialize(resultData),
                ContentType = "application/json"
            };
        }

        public ActionResult GetTodayWork()
        {
            var result = _workResultService.GetTodayWorkResults();
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
            //return Json(new { Result = "OK", Records = result, TotalRecordCount = result.Count }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetStudentTodayWork(int userId)
        {
            var result = _workResultService.GetStudentTodayWork(userId);
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
            //return Json(new { Result = "OK", Records = result, TotalRecordCount = result.Count }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Error()
        {
            return View();
        }

        #endregion

    }
}