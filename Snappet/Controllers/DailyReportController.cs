using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Snappet.Entities.Interfaces;
using Snappet.Services.Interfaces;
using Snappet.Web.Models;

namespace Snappet.Web.Controllers
{
    public class DailyReportController : Controller
    {
	    private readonly IProgressReportService _service;

	    public DailyReportController(IProgressReportService service)
	    {
		    _service = service;
	    }

        // GET: DailyReport
        public ActionResult Index()
        {
	        IEnumerable<IDailyReport> dailyReports = _service.GetDailyProgressBefore(new DateTime(2015, 3, 24, 11, 30, 00));

	        DailyReportViewModel viewmodel = new DailyReportViewModel();
	        viewmodel.StudentReports = dailyReports;
			
	        return View(viewmodel);
        }

		// TODO: Data los opvraagbaar maken via Json / AJAX methode
	}
}