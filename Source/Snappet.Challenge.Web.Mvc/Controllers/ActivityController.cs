using System;
using System.Web.Mvc;
using Snappet.Challenge.Web.Mvc.ViewModels;

namespace Snappet.Challenge.Web.Mvc.Controllers
{
    public class ActivityController : BaseController
    {
        static readonly DateTime _timeOnDay = new DateTime(2015, 03, 24, 11, 30, 00, DateTimeKind.Utc);

        // GET: /Activity/Index
        [HttpGet]
        public ActionResult Index() {
            ActivityViewModel model = new ActivityViewModel()
            {
                DateTimeStamp = _timeOnDay.ToLocalTime(),
                ClassActivity = SnappetDataContext.GetClassActivityForTimeOnDay(_timeOnDay),
                Students = SnappetDataContext.GetStudents(_timeOnDay)
            };
            
            return View(model);
        }

        // POST: /Activity/GetStudentActivityForTimeOnDay
        [HttpPost]
        public JsonResult GetStudentActivityForTimeOnDay(int studentId, DateTime dateTimeStamp)
        {            
            StudentActivityViewModel model = new StudentActivityViewModel()
            {
                StudentId = studentId,
                StudentActivity = SnappetDataContext.GetStudentActivityForTimeOnDay(studentId, dateTimeStamp)
            };

            return Json(model);
        }
    }
}