using System;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Snappet.Challenge.Services;
using AutoMapper;
using Snappet.Challenge.Web.Models;
using Snappet.Challenge.Services.Dto;
using System.Collections.Generic;

namespace Snappet.Challenge.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentResultAnalysisService _studentResultAnalysisService;

        public HomeController(IStudentResultAnalysisService studentResultAnalysisService)
        {
            _studentResultAnalysisService = studentResultAnalysisService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SearchForSubectDomains(string query)
        {
            var result = _studentResultAnalysisService.SearchForSubectDomains(query);

            var jsonResult = JsonConvert.SerializeObject(
                result,
                Formatting.Indented,
                new JsonSerializerSettings {ContractResolver = new CamelCasePropertyNamesContractResolver()});

            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetClassLearningObjectiveStatChartData(string subject, string domain,
            DateTime? from, DateTime? to)
        {
            var result = _studentResultAnalysisService.GetClassLearningObjectiveStatisticsFor(subject, domain, from, to);
            var mappedResult = Mapper.Map<IEnumerable<LearningObjectiveStatisticsDto>, IEnumerable<LearningObjectiveStatisticsChartModel>>(result);

            var jsonResult = JsonConvert.SerializeObject(
                mappedResult,
                Formatting.Indented,
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            return Json(jsonResult, "application/json", JsonRequestBehavior.AllowGet);
        }
    }
}