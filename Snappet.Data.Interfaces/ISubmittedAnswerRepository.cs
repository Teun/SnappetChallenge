using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snappet.Entities.Interfaces;

namespace Snappet.Data.Interfaces
{
	public interface ISubmittedAnswerRepository
	{
		IEnumerable<ISubmittedAnswer> GetSubmittedAnswersBefore(DateTime time);
	}
}
