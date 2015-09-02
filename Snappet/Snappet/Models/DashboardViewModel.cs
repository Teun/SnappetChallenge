using DotNet.Highcharts;
using Snappet.Data;

namespace Snappet.Models
{
	public class DashboardViewModel
	{
		public Highcharts AnswersPerDayChart { get; set; }

		public Highcharts TopSubjectsSpelling { get; set; }

		public Highcharts TopSubjectsBegrijpendLezen { get; set; }

		public Highcharts TopSubjectsRekenen { get; set; }


		public ObjectiveAndCount[] LowestSubjectsSpelling { get; set; }

		public ObjectiveAndCount[] LowestSubjectsBegrijpendLezen { get; set; }

		public ObjectiveAndCount[] LowestSubjectsRekenen { get; set; }
	
		//public Highcharts LowestSubjectsSpelling { get; set; }

		//public Highcharts LowestSubjectsBegrijpendLezen { get; set; }

		//public Highcharts LowestSubjectsRekenen { get; set; }
	}
}