using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snappet.Presentation.Models
{
	public class RequestColumnSettingsViewModel<T>
	{
		public RequestColumnSettingsViewModel()
		{
			Filter = new List<T>();
		}

		public bool IsActive { get; set; }
		public IEnumerable<T> Filter { get; set; }
	}
}