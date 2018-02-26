using System;
using System.Web.Mvc;
using Snappet.Core.Dtos;
using Snappet.Core.Utils;
using Snappet.Repository.Dao;
using Snappet.Repository.Helpers;
using Snappet.Repository.Interfaces;

namespace Snappet.Controllers
{
    public class LogsController : Controller
    {
        public LogsController()
        {

            _appLogRepository = AppLogRepository.GetInstance();
        }
        private readonly IAppLogRepository _appLogRepository;
        //
        // GET: /Logs/
        public ActionResult Index(bool isRefresh = false)
        {
            var applogs = new QueryResult<AppLog>(null, 0);
            try
            {
                applogs = _appLogRepository.FindAll();
                ViewBag.Message = isRefresh ? ApplicationConstants.LogRefresh : string.Empty;
            }
            catch (Exception exception)
            {
                _appLogRepository.Log(exception);
                ViewBag.Message = exception.Message;
            }
            ViewBag.TotalRecords = applogs.TotalRecords;
            ViewBag.ApplicationLogs = applogs.Result;
            return View();
        }

        //
        // GET: /Logs/Details/5


        //
        // GET: /Logs/Delete/5
        public ActionResult Delete(int logId = 0)
        {
            _appLogRepository.DeleteErrorLogs(logId);
            return RedirectToAction("Index");
        }

    }
}
