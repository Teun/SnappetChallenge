using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using Snappet.Data;
using Snappet.Models;
using Snappet.Utility;

namespace Snappet.Controllers
{
	public class HomeController : Controller
	{
		private static DataSource _dataSource;
		private readonly DateTime _fakeTodayDate;
		private string _userTimeZone;

		public HomeController() : this(new DataSource(), new DateTime(2015, 03, 24, 11, 30, 00, DateTimeKind.Utc))
		{
		}

		public HomeController(DataSource dataSurce, DateTime fakeTodayDate)
		{
			_dataSource = dataSurce;
			_fakeTodayDate = fakeTodayDate;
		}

		public ActionResult Index()
		{
			if (string.IsNullOrEmpty(Request.Cookies["userTimeZone"]?.Value))
			{
				// We don't know user's time zone so we are redirecting to get it
				return RedirectToAction("GetTimeZone");
			}

			_userTimeZone = HttpUtility.UrlDecode(Request.Cookies["userTimeZone"].Value);

			ViewBag.UserTimeZone = _userTimeZone;

			var now = _fakeTodayDate.UtcToZoned(_userTimeZone);
            ViewBag.TodayTitle = now.ToLongDateString() + " " + now.ToLongTimeString();

			var model = new DashboardViewModel()
			{
				AnswersPerDayChart = CreateAnswersPerDayChart("answersPerDayChart"),

				TopSubjectsBegrijpendLezen = CreateTopStackedBarChart("topSubjectsBegrijpendLezen", Subjects.BegrijpendLezen),
				TopSubjectsRekenen = CreateTopStackedBarChart("topSubjectsRekenen", Subjects.Rekenen),
				TopSubjectsSpelling = CreateTopStackedBarChart("topSubjectsSpelling", Subjects.Spelling),

				LowestSubjectsBegrijpendLezen =
					_dataSource.GetLowestObjectivePerSubjectForADay(Subjects.BegrijpendLezen, _fakeTodayDate, _userTimeZone, 5),

				LowestSubjectsRekenen =
					_dataSource.GetLowestObjectivePerSubjectForADay(Subjects.Rekenen, _fakeTodayDate, _userTimeZone, 5),

				LowestSubjectsSpelling =
					_dataSource.GetLowestObjectivePerSubjectForADay(Subjects.Spelling, _fakeTodayDate, _userTimeZone, 5),
			};

			return View(model);
		}

		public ActionResult GetTimeZone()
		{
			return View();
		}
		public Highcharts CreateAnswersPerDayChart(string chartName)
		{
			var data = _dataSource.GetAnswersPerDay(_userTimeZone, _fakeTodayDate);

			var chart = new Highcharts(chartName)
				.InitChart(new Chart {DefaultSeriesType = ChartTypes.Spline})
				.SetOptions(new GlobalOptions {Global = new Global {UseUTC = false}})
				.SetTitle(new Title {Text = "Answers per day"})
				.SetXAxis(new XAxis
				{
					Type = AxisTypes.Datetime,
					DateTimeLabelFormats = new DateTimeLabel {Month = "%e. %B", Year = "%b", Day = "%A, %e. %B"}
				})
				.SetYAxis(new YAxis
				{
					Title = new YAxisTitle {Text = "Number of answers"},
					Min = 0
				})
				.SetTooltip(new Tooltip
				{
					Formatter =
						"function() { return '<b>'+ this.series.name +'</b><br/>'+ Highcharts.dateFormat('%A, %e. %B', this.x) +': '+ this.y +''; }"
				})
				.SetSeries(new[]
				{
					CreateDateCountSeries(data, "Begrijpend Lezen"),
					CreateDateCountSeries(data, "Rekenen"),
					CreateDateCountSeries(data, "Spelling")
				});
			return chart;
		}

		private Series CreateDateCountSeries(AnswersPerDay[] data, string name)
		{
			var res = data.Where(d => d.Subject.Equals(name, StringComparison.InvariantCultureIgnoreCase))
				.OrderBy(o => o.Date)

				.ToArray();

			int dataCount = res.Count();
			object[,] dataObjects = new object[dataCount, 2];

			for (int i = 0; i < dataCount; i++)
			{
				dataObjects[i, 0] = res[i].Date;
				dataObjects[i, 1] = res[i].Count;
			}

			return new Series
			{
				Name = name,
				Data = new DotNet.Highcharts.Helpers.Data(dataObjects)
			};
		}

		public Highcharts CreateTopStackedBarChart(string chartName, string subject, int limit = 5)
		{
			var data = _dataSource.GetTopObjectivePerSubjectForADay(subject, _fakeTodayDate, _userTimeZone, limit);

			Highcharts chart = new Highcharts(chartName)
				.InitChart(new Chart { DefaultSeriesType = ChartTypes.Bar })
				.SetTitle(new Title { Text = subject })
				.SetXAxis(new XAxis
				{
					Categories = data.Select(s => s.Name).ToArray(),
					Title = new XAxisTitle() { Text = null },
					Labels = new XAxisLabels()
					{
						Formatter = "function () { var text = this.value,"
						            + "formatted = text.length > 25 ? text.substring(0, 25) + '...' : text;"
						            +
						            "return '<div class=\"js -ellipse\" style=\"width:150px; overflow:hidden\" title=\"' + text + '\">' + formatted + '</div>'; }",
						Style = "width: '150px'",
						UseHTML = true
					},
				})
				.SetYAxis(new YAxis
				{
					Min = 0,
					Title = new YAxisTitle { Text = "Answers per Learning Objective" }
				})
				.SetTooltip(new Tooltip { Formatter = "function() { return ''+ this.series.name +': '+ this.y +''; }" })
				.SetPlotOptions(new PlotOptions { Bar = new PlotOptionsBar { Stacking = Stackings.Normal } })
				.SetLegend(new Legend() { Enabled = false })
				.SetSeries(new[]
				{
					new Series
					{
						Name = "Answers",
						Data = new DotNet.Highcharts.Helpers.Data(data.Select(s => (object) s.Count).ToArray())
					},
				});

			return chart;
		}
	}
}