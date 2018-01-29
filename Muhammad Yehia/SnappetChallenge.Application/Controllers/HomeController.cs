using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;
using SnappetChallenge.Application.Utilities;
using SnappetChallenge.Application.Models;
using System.Net;
using SnappetChallenge.Core.Entities;
using SnappetChallenge.Core.Interfaces;
using AssessmentFilterModel = SnappetChallenge.Core.Entities.AssessmentFilterModel;

namespace SnappetChallenge.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAssessmentService _assessmentService;

        public HomeController(IAssessmentService assessmentService)
        {
            _assessmentService = assessmentService;

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(AssessmentFilterModel assessmentFilterModel)
        {
            var result = _assessmentService.Query(assessmentFilterModel).Select(c => new AssessmentFilterModel() {
                Correct = c.Correct,
                Difficulty = c.Difficulty,
                Domain = c.Domain,
                ExerciseId = c.ExerciseId,
                LearningObjective = c.LearningObjective,
                Progress = c.Progress,
                Subject = c.Subject,
                SubmittedAnswerId = c.SubmittedAnswerId,
                UserId = c.UserId,
                SubmitDateTime = c.SubmitDateTime==null? "": c.SubmitDateTime.ToString()

            });
            return new JsonResult
            {
                Data = new DataResponse<AssessmentFilterModel>
                {
                    List = result,
                    TotalPages = assessmentFilterModel.TotalPages,
                    TotalRecords = assessmentFilterModel.TotalRecords,
                    StatusCode = HttpStatusCode.OK,
                    Success = true,
                    Message = "MessageSuccessed"

                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = int.MaxValue
            };
        }
        [HttpGet]
        public ActionResult Upload()
        {
            ViewBag.Message = "Upload Your Excel File";

            return View();
        }

        [HttpGet]
        public void ClearData()
        {
            _assessmentService.ClearData();
        }
        [HttpPost]
        public ActionResult Upload(FormCollection formCollection)
        {

            var file = Request?.Files["UploadedFile"];
            if (file == null || (file.ContentLength <= 0) || string.IsNullOrEmpty(file.FileName))
            {
                ViewBag.ErrorMessage = "File is empty";
                return View("Upload");
            }
            if (!file.FileName.Contains(".csv"))
            {
                ViewBag.ErrorMessage = "File is not in correct formate";
                return View("Upload");
            }
            _assessmentService.ClearData();
            long insertStatmentCount;

            var insertStatments = CsvFileHelper.ConvertCsvStreamToSqlInsertStatmentList(file.InputStream,
                out insertStatmentCount);
            TempData.Add("insertStatmentCount", insertStatmentCount);

            Task.Run(() =>
                Parallel.For(0, insertStatments.Count, x =>
                {
                    _assessmentService.InsertBulkAssessments(insertStatments[x]);

                })
            );

            return RedirectToAction("Status");
        }

        public ActionResult Status()
        {
            ViewBag.Status = GetPresentageStatus();
            return View();
        }
        [HttpGet]
        public double GetPresentageStatus()
        {
            var count = TempData.Peek("insertStatmentCount");
            if (count != null)
            {
                var assessmentInFile = (long)count;
                var insertedCostumer = _assessmentService.GetAssessmentsCount();
                return Math.Round((insertedCostumer * 100.0 / assessmentInFile), 2);
            }
            return 0;
        }
    }
}