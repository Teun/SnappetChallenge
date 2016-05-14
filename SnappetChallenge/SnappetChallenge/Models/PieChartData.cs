using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnappetChallenge.Models
{
	public class PieChartData<T>
	{
		public List<string> Labels { get; set; }
		public List<T> Values { get; set; }

		public List<string> Colors { get; set; }
		public List<string> HoverColors { get; set; }

		public string ValueLabel { get; set; }

		public PieChartData()
		{
			Labels = new List<string>();
			Colors = new List<string>();
			HoverColors = new List<string>();
			Values = new List<T>();
			ValueLabel = string.Empty;
		}
	}
}