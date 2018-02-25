using System;
using System.Collections.Generic;
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
        private static  QueryResult<string> SubjectList { get; set; }
   

        public HomeController()
        {
            _workRepository = new WorkRepository();
            _appLogRepository = new AppLogRepository();
        }

       // [OutputCache(Duration = 60,Location = OutputCacheLocation.Any)]
        public ActionResult Index()
        {
            try
            {
                #region -- Get WorkItems --

                var result = _workRepository.FindAll();
                ViewBag.WorkItems = result.Result;
                ViewBag.TotalRecords = result.TotalRecords;

                #endregion

                #region -- Get Subjects --

                var subjects = GetSubjects();
                ViewBag.Subjects = subjects.Result;

                #endregion

                ViewBag.Message = string.Empty;
            }
            catch (Exception exception)
            {
                ViewBag.Message = exception.Message;
                _appLogRepository.Log(exception);
            }

            return View();
        }

        private  QueryResult<string> GetSubjects()
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
