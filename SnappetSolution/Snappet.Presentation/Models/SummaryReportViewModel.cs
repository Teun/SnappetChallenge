using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snappet.Presentation.Models
{
	public class SummaryReportViewModel
	{
		public SummaryReportViewModel()
		{
			CorrectColumn = new RequestColumnSettingsViewModel<int>();
			UserIdColumn = new RequestColumnSettingsViewModel<int>();
			ExerciseIdColumn = new RequestColumnSettingsViewModel<int>();
			SubjectColumn = new RequestColumnSettingsViewModel<string>();
			DomainColumn = new RequestColumnSettingsViewModel<string>();
			LearningObjectiveColumn = new RequestColumnSettingsViewModel<string>();
		}

		public DateTime ReportDate { get; set; }
		public RequestColumnSettingsViewModel<int> CorrectColumn { get; set; }
		public RequestColumnSettingsViewModel<int> UserIdColumn { get; set; }
		public RequestColumnSettingsViewModel<int> ExerciseIdColumn { get; set; }
		public RequestColumnSettingsViewModel<string> SubjectColumn { get; set; }
		public RequestColumnSettingsViewModel<string> DomainColumn { get; set; }
		public RequestColumnSettingsViewModel<string> LearningObjectiveColumn { get; set; }
	}
}