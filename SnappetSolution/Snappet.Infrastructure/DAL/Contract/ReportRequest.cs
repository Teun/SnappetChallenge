using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Infrastructure.DAL.Contract
{
	public class ReportRequest
	{
		public DateTime ReportDate { get; set; }
		public RequestColumnSettings<int> CorrectColumn { get; set; }
		public RequestColumnSettings<int> UserIdColumn { get; set; }
		public RequestColumnSettings<int> ExerciseIdColumn { get; set; }
		public RequestColumnSettings<string> SubjectColumn { get; set; }
		public RequestColumnSettings<string> DomainColumn { get; set; }
		public RequestColumnSettings<string> LearningObjectiveColumn { get; set; }
	}
}
