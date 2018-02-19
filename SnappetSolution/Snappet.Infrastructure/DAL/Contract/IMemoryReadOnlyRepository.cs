using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Infrastructure.DAL.Contract
{
	public interface IMemoryReadOnlyRepository
	{
		IEnumerable<ReportResponse> Find(ReportRequest request);
		IEnumerable<string> GetDimensionValues(Dimensions dimensionType, string term);
		void LoadData(string filePath);
	}
}
