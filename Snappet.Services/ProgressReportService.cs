using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snappet.Data.Interfaces;
using Snappet.Entities;
using Snappet.Entities.Interfaces;
using Snappet.Services.Interfaces;

namespace Snappet.Services
{
	public class ProgressReportService : IProgressReportService
	{
		private readonly ISubmittedAnswerRepository _repository;

		public ProgressReportService(ISubmittedAnswerRepository repository)
		{
			_repository = repository;
		}

		public IEnumerable<IDailyReport> GetDailyProgressBefore(DateTime before)
		{
			List<IDailyReport> result = new List<IDailyReport>();

			IEnumerable<ISubmittedAnswer> answersToday = _repository.GetSubmittedAnswersBefore(before);
			var answersGroupedByStudents = answersToday.GroupBy(answer => answer.User);

			foreach (var answerGroupedByStudent in answersGroupedByStudents)
			{
				List<ProgressByStudent> progressByStudentList = new List<ProgressByStudent>();
				foreach (ISubmittedAnswer answer in answerGroupedByStudent)
				{
					var progressByStudent = progressByStudentList.FirstOrDefault(p => p.LearningObjective.Equals(answer.LearningObjective));
					if (progressByStudent != null)
					{
						progressByStudent.AddProgress(answer.Progress);
					}
					else
					{
						progressByStudentList.Add(new ProgressByStudent(answer.LearningObjective, answer.Progress));
					}
				}
				var dailyReport = new DailyReport(answerGroupedByStudent.Key, progressByStudentList);
				result.Add(dailyReport);
			}

			return result;
		}
	}
}
