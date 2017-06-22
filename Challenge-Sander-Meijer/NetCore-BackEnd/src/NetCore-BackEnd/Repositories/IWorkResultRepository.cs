using System;
using System.Collections.Generic;
using NetCore.BackEnd.Models.Poco;

namespace NetCore.BackEnd.Repositories
{
	public interface IWorkResultRepository
	{
		IList<WorkResult> GetWorkResultsForPeriod(DateTime startTimeUtc, DateTime endTimeUtc);
	}
}