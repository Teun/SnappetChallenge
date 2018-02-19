using Snappet.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Snappet.Infrastructure.Configuration;
using Snappet.Infrastructure.DAL.Contract;
using AutoMapper;

namespace Snappet.Presentation.Controllers
{
	public class HomeController : Controller
	{
		IMemoryReadOnlyRepository _memoryRepository = null;

		public HomeController(IMemoryReadOnlyRepository memoryRepository)
		{
			_memoryRepository = memoryRepository;
		}

		public ActionResult Index()
		{
			var model = new SummaryReportViewModel()
			{
				ReportDate = ApplicationConfig.SnappetUtcNow,
			};

			model.SubjectColumn.IsActive = true;
			model.UserIdColumn.IsActive = true;

			return View(model);
		}

		[HttpGet]
		public ActionResult GetDimensionValues(Dimensions dimensionType, string term)
		{
			var values = _memoryRepository.GetDimensionValues(dimensionType, term);

			return new JsonResult
			{
				Data = new { results = values.Select(x => new { id = x, text = x }) },
				JsonRequestBehavior = JsonRequestBehavior.AllowGet
			};
		}

		[HttpGet]
		public ActionResult GetReportData(SummaryReportViewModel model)
		{
			var result = _memoryRepository.Find(Mapper.Map<ReportRequest>(model));

			return new JsonResult
			{
				Data = result,
				JsonRequestBehavior = JsonRequestBehavior.AllowGet
			};
		}

		public ActionResult Contact()
		{
			return View();
		}
	}
}