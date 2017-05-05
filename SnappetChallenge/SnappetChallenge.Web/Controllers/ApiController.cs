using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SnappetChallenge.Services.Interfaces;

namespace SnappetChallenge.Web.Controllers
{
    public class ApiController : Controller
    {
        private readonly IAnswerService _answerService;
        private readonly IExerciseService _exerciseService;
        private readonly IObjectiveService _objectiveService;
        private readonly IStudentService _studentService;
        private readonly IStudentAnswerService _studentAnswerService;
        private readonly IStudentDeviationsService _studentDeviationService;

        public ApiController(
            IAnswerService answerService, 
            IExerciseService exerciseService, 
            IObjectiveService objectiveService, 
            IStudentService studentService,
            IStudentAnswerService studentAnswerService,
            IStudentDeviationsService studentDeviationService)
        {
            _answerService = answerService;
            _exerciseService = exerciseService;
            _objectiveService = objectiveService;
            _studentService = studentService;
            _studentAnswerService = studentAnswerService;
            _studentDeviationService = studentDeviationService;
        }

        public JsonResult GetObjectives(DateTime? start, DateTime? end)
        {
            {
                start = start ?? AppSettings.DefaultDateTimeStart;
                end = end ?? AppSettings.DefaultDateTimeEnd;

                var items = _objectiveService.GetObjectivesInRange((DateTime)start, (DateTime)end);
                return Json(new { objectives = items }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetExercises(long objectiveId, DateTime? start, DateTime? end)
        {
            {
                start = start ?? AppSettings.DefaultDateTimeStart;
                end = end ?? AppSettings.DefaultDateTimeEnd;

                var items = _exerciseService.GetExercisesByObjectiveInRange(objectiveId, (DateTime) start,
                    (DateTime) end);
                return Json(new { exercises = items }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetStudents()
        {
            var students = _studentService.Get(s => true);

            return Json(new {students = students}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAnswersForStudentAndExercise(long studentId, long[] exerciseIds, DateTime? start, DateTime? end)
        {
            start = start ?? AppSettings.DefaultDateTimeStart;
            end = end ?? AppSettings.DefaultDateTimeEnd;

            var answers = _answerService.GetAnswersByStudentAndExerciseInRange(studentId, exerciseIds, (DateTime) start, (DateTime) end);

            return Json(new { answers = answers, studentId = studentId}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult StudentAnswers(int offset, int pageSize, DateTime? start, DateTime? end)
        {
            start = start ?? AppSettings.DefaultDateTimeStart;
            end = end ?? AppSettings.DefaultDateTimeEnd;

            var items = _studentAnswerService.Get(
                (sa => sa.SubmitDateTime >= start && sa.SubmitDateTime <= end), offset, pageSize);

            return Json(new { items = items }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult StudentDeviations(DateTime? start, DateTime? end)
        {
            start = start ?? AppSettings.DefaultDateTimeStart;
            end = end ?? AppSettings.DefaultDateTimeEnd;

            var items = _studentDeviationService.Get((DateTime)start, (DateTime)end);

            return Json(new { students = items }, JsonRequestBehavior.AllowGet);
        }
    }
}