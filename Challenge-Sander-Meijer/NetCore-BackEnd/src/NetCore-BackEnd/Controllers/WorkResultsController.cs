using System;
using Microsoft.AspNetCore.Mvc;
using NetCore.BackEnd.Facades;

namespace NetCore.BackEnd.Controllers
{
	[Route("api/WorkResults")]
	public class WorkResultsController : Controller
	{
		private readonly IWorkResultFacade _workResultFacade;

		public WorkResultsController(IWorkResultFacade workResultFacade)
		{
			if (workResultFacade == null)
			{
				throw new ArgumentNullException(nameof(workResultFacade));
			}
			_workResultFacade = workResultFacade;
		}

		[HttpGet]
		public ActionResult GetForPeriod(DateTime startTimeUtc, DateTime endTimeUtc)
		{
			var items = _workResultFacade.GetAllForPeriod(startTimeUtc, endTimeUtc);
			return Ok(items);
		}
	}
}