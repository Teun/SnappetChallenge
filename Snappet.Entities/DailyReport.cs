using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snappet.Entities.Interfaces;
using Snappet.Services.Interfaces;

namespace Snappet.Entities
{
	public class DailyReport : IDailyReport
	{
		public DailyReport(string student, IEnumerable<IProgressByStudent> progressByStudent)
		{
			Student = student;
			ProgressByStudent = progressByStudent;
		}

		public string Student { get; }

		public IEnumerable<IProgressByStudent> ProgressByStudent { get; }
	}
}
