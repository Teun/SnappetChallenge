using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using Snappet.Repository.Dao;
using Snappet.Repository.Interfaces;
using Snappet.Repository.Helpers;

namespace Snappet.Controllers
{
    public class HomeController : Controller
    {
        readonly IWorkRepository _workRepository;
        readonly IAppLogRepository _appLogRepository;
        private static QueryResult<string> SubjectList { get; set; }


        public HomeController()
        {
            _workRepository = new WorkRepository();
            _appLogRepository = new AppLogRepository();
        }

        /// <summary>
        /// Work Report.
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param> 
        /// <param name="userId"></param>
        /// <param name="exerciseId"></param>
        /// <param name="difficulty"></param>
        /// <param name="subject"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [OutputCache(Duration = 60, Location = OutputCacheLocation.Any, VaryByParam = "*", VaryByHeader = "X-Requested-With")]
        public ActionResult Index(DateTime? dateFrom, DateTime? dateTo, int userId = 0, int exerciseId = 0,
            string difficulty = "", string subject = "", int pageIndex = 1, int pageSize = 10)
        {
            try
            {
                #region -- Get WorkItems --

                var to = dateTo == null ? new DateTime(2015, 03, 24, 11, 30, 00).Date.AddDays(1).AddMilliseconds(-1) : dateTo.Value.AddDays(1).AddMilliseconds(-1);
                var from = dateFrom == null ? new DateTime(2015, 03, 24, 11, 30, 00) : dateFrom.Value.AddDays(1).AddMilliseconds(-1);

                var result = _workRepository.WorkItemsReport(from, to, userId, exerciseId, difficulty, subject, pageIndex, pageSize);
                ViewBag.WorkItems = result.Result;
                ViewBag.TotalRecords = result.TotalRecords;

                #endregion

                #region -- Get Subjects --

                var subjects = GetSubjects();
                ViewBag.Subjects = subjects.Result.Select(
                    x => new SelectListItem
                    {
                        Text = x,
                        Value = x

                    }).ToList();

                #endregion

                ViewBag.Message = string.Empty;
            }
            catch (Exception exception)
            {
                ViewBag.Message = exception.Message;
                ViewBag.WorkItems = null;
                ViewBag.TotalRecords = 0;
                _appLogRepository.Log(exception);
            }

            return View();
        }

        private QueryResult<string> GetSubjects()
        {
            return SubjectList ?? _workRepository.GetAllSubject();
        }

        public ActionResult Details(int id)
        {
            try
            {
                ViewBag.WorkItems = _workRepository.Find(id);
            }
            catch (Exception exception)
            {
                ViewBag.Message = exception.Message;
                _appLogRepository.Log(exception);
            }

            return View();
        }
    }
}
