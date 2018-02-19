using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Infrastructure.DAL.Contract
{
	public class RequestColumnSettings<T>
	{
		public bool IsActive { get; set; }
		public IEnumerable<T> Filter { get; set; }
	}
}
