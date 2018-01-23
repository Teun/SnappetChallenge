using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Interfaces.Services;
using SnappetChallenge.WebApp.Models;

namespace SnappetChallenge.WebApp.Controllers
{
    public class StudentController : Controller
    {
        #region Fields
        private readonly IWorkResultService _workResultService;
        #endregion

        #region Constructors
        public StudentController(IWorkResultService workResultService)
        {
            _workResultService = workResultService;
        }
        #endregion

        #region Actions

        public ActionResult Performance()
        {
            var model = new PerformanceViewModel {Students = _workResultService.GetAllStudents()};
            return View(model);
        }

        public ActionResult StudentSummary(int userId,DateTime startDate,DateTime endDate)
        {
            var studentSummary = _workResultService.GetStudentSummary(userId, startDate, endDate);
            var studentSubjects = _workResultService.GetStudentSubjects(userId, startDate, endDate);
            return Json(new {StudentSummary = studentSummary, StudentSubjects = studentSubjects }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}