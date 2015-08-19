namespace SnappetChallenge.Web.Controllers.API
{
    using System;
    using System.Web.Mvc;

    using Services.Interfaces;

    public class StudentAnswerController : Controller
    {
        private readonly IStudentAnswerService _studentAnswerService;

        // use Unity constructor injection
        public StudentAnswerController(IStudentAnswerService studentAnswerService)
        {
            _studentAnswerService = studentAnswerService;
        }

        public JsonResult Retrieve(int offset, int pageSize, DateTime? start, DateTime? end)
        {
            start = start ?? AppSettings.DefaultDateTimeStart;
            end = end ?? AppSettings.DefaultDateTimeEnd;

            var items = _studentAnswerService.Get(
                (sa => sa.SubmitDateTime >= start && sa.SubmitDateTime <= end ), offset, pageSize);

            return Json(new {items = items}, JsonRequestBehavior.AllowGet);
        }
    }
}