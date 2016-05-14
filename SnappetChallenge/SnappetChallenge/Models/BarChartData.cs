using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnappetChallenge.Models
{
	public class BarChartData<T>
	{
		public List<string> Labels { get; set; }
		public List<T> Values { get; set; }
		public string ValueLabel { get; set; }
		
		public BarChartData()
		{
			Labels = new List<string>();
			Values = new List<T>();
			ValueLabel = string.Empty;
		}
	}
}