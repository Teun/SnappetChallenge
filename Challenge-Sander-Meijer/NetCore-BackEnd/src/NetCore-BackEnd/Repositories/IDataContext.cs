using System.Collections.Generic;
using NetCore.BackEnd.Models.Poco;

namespace NetCore.BackEnd.Repositories
{
	public interface IDataContext
	{
		IList<WorkResult> WorkResults { get; }
	}
}