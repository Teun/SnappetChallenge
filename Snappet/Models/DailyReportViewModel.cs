using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Snappet.Entities.Interfaces;
using Snappet.Services.Interfaces;

namespace Snappet.Web.Models
{
	public class DailyReportViewModel
	{
		public IEnumerable<IDailyReport> StudentReports { get; set; }
	}
}