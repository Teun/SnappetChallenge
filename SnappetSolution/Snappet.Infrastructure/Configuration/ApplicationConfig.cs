using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Infrastructure.Configuration
{
	public static class ApplicationConfig
	{
		public static DateTime SnappetUtcNow
		{
			get
			{
				return new DateTime(2015, 03, 24, 11, 30, 0, DateTimeKind.Utc);
			}
		}
	}
}
