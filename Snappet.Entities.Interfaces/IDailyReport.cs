using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snappet.Services.Interfaces;

namespace Snappet.Entities.Interfaces
{
	public interface IDailyReport
	{
		string Student { get; }

		IEnumerable<IProgressByStudent> ProgressByStudent { get; }
	}
}
