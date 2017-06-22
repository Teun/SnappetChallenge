using System;
using System.Collections.Generic;
using System.Linq;
using NetCore.BackEnd.Models.Poco;

namespace NetCore.BackEnd.Repositories
{
	public class WorkResultRepository : IWorkResultRepository
	{
		private readonly IDataContext _dataContext;

		public WorkResultRepository(IDataContext dataContext)
		{
			if (dataContext == null)
			{
				throw new ArgumentNullException(nameof(dataContext));
			}

			_dataContext = dataContext;
		}

		public IList<WorkResult> GetWorkResultsForPeriod(DateTime startTimeUtc, DateTime endTimeUtc)
		{
			return _dataContext.WorkResults
				.Where(workResult => workResult.SubmitDateTime >= startTimeUtc)
				.Where(workResult => workResult.SubmitDateTime <= endTimeUtc)
				.ToList();
		}
	}
}