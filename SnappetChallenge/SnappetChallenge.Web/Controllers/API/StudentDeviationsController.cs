
using System;

namespace SnappetChallenge.Web.Controllers.API
{
    using System.Web.Mvc;
    using Services.Interfaces;

    public class StudentDeviationsController : Controller
    {
        private readonly IStudentDeviationsService _studentDeviationService;

        public StudentDeviationsController(IStudentDeviationsService studentDeviationService)
        {
            _studentDeviationService = studentDeviationService;
        }

        public JsonResult Retrieve(DateTime? start, DateTime? end)
        {
            start = start ?? AppSettings.DefaultDateTimeStart;
            end = end ?? AppSettings.DefaultDateTimeEnd;

            var items = _studentDeviationService.Get((DateTime)start, (DateTime)end);

            return Json(new { students = items }, JsonRequestBehavior.AllowGet);
        }
    }
}