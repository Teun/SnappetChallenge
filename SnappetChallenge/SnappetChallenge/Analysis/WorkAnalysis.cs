using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SnappetChallenge.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SnappetChallenge.Global;

namespace SnappetChallenge.Analysis
{
	public class WorkAnalysis
	{
		//This class will do various data analyses on the dataset, which we can feed to various outputs

		private IEnumerable<SubmittedAnswer> submittedAnswers;

		public WorkAnalysis(IEnumerable<SubmittedAnswer> submittedAnswers)
		{
			this.submittedAnswers = submittedAnswers;
		}

		public int GetNumberOfStudents()
		{
			return submittedAnswers.GroupBy(x => x.UserId).Count();
		}

		public int GetNumberOfCorrectAnswers()
		{
			return submittedAnswers.Where(x => x.Correct == true).Count();
		}

		public double GetHighestDifficulty()
		{
			return submittedAnswers.Max(x => x.Difficulty);
		}

		public double GetAverageDifficulty()
		{
			return submittedAnswers.Where(x => x.Difficulty >= 0).Average(x => x.Difficulty);
		}

		public double GetLowestDifficulty()
		{
			return submittedAnswers.Where(x => x.Difficulty >= 0).Min(x => x.Difficulty);
		}

		public BarChartData<double> GetAnswersPerStudentPerDayChartData()
		{
			BarChartData<double> data = new BarChartData<double>();
			data.ValueLabel = "Antwoorden per student per dag";

			List<DateTime> distinctDates = submittedAnswers.Select(x => x.SubmittedDate).Distinct().ToList();

			foreach (DateTime date in distinctDates)
			{
				data.Labels.Add(date.Day.ToString());
				int numberOfStudents = submittedAnswers.Where(x => x.SubmittedDate == date).GroupBy(x => x.UserId).Count();
				data.Values.Add((double)submittedAnswers.Where(x => x.SubmittedDate == date).Count() / (double)numberOfStudents);
			}

			return data;
		}

		public BarChartData<double> GetPercentCorrectPerDayChartData()
		{
			BarChartData<double> data = new BarChartData<double>();
			data.ValueLabel = "Procent antwoorden correct";

			var groupedData = from answers in submittedAnswers
							  group answers by answers.SubmittedDate into grouping
							  select new
							  {
								  Day = grouping.Key.Day.ToString(),
								  Answers = grouping.Count(),
								  Correct = grouping.Sum(x => x.Correct ? 1 : 0)

							  };

			foreach (var item in groupedData)
			{
				data.Labels.Add(item.Day);
				data.Values.Add(((double)item.Correct / (double)item.Answers) * 100);
			}
			return data;
		}

		public BarChartData<double> GetPercentCorrectPerStudentChartData()
		{
			BarChartData<double> data = new BarChartData<double>();
			data.ValueLabel = "Procent correct per student";

			var groupedData = from answers in submittedAnswers
							  group answers by answers.UserId into grouping
							  select new
							  {
								  UserId = grouping.Key.ToString(),
								  Answers = grouping.Count(),
								  Correct = grouping.Sum(x => x.Correct ? 1 : 0)

							  };

			foreach (var item in groupedData)
			{
				data.Labels.Add(item.UserId);
				data.Values.Add(((double)item.Correct / (double)item.Answers) * 100);
			}
			return data;
		}

		public BarChartData<int> GetProgressPerStudentChartData()
		{
			BarChartData<int> data = new BarChartData<int>();
			data.ValueLabel = "Vooruitgang per student";

			var groupedData = from answers in submittedAnswers
							  group answers by answers.UserId into grouping
							  select new
							  {
								  UserId = grouping.Key.ToString(),
								  Progress = grouping.Sum(x => x.Progress)
							  };

			foreach (var item in groupedData)
			{
				data.Labels.Add(item.UserId);
				data.Values.Add(item.Progress);
			}
			return data;
		}

		public BarChartData<int> GetStudentsWithAnswersPerDayChartData()
		{
			BarChartData<int> data = new BarChartData<int>();
			data.ValueLabel = "Aantal studenten met antwoorden";

			List<DateTime> distinctDates = submittedAnswers.Select(x => x.SubmittedDate).Distinct().ToList();

			foreach(DateTime date in distinctDates)
			{
				data.Labels.Add(date.Day.ToString());
				data.Values.Add(submittedAnswers.Where(x => x.SubmittedDate == date).GroupBy(x => x.UserId).Count());
			}

			return data;
		}

		public BarChartData<double> GetAverageDifficultyPerStudentChartData()
		{
			BarChartData<double> data = new BarChartData<double>();
			data.ValueLabel = "Gemiddeld moeilijkheid per student";

			var groupedData = from answers in submittedAnswers
							  where answers.Difficulty >= 0
							  group answers by answers.UserId into grouping
							  select new
							  {
								  UserId = grouping.Key.ToString(),
								  Difficulty = grouping.Average(x => x.Difficulty)
							  };

			foreach (var item in groupedData)
			{
				data.Labels.Add(item.UserId);
				data.Values.Add(item.Difficulty);
			}
			return data;
		}

		public PieChartData<double> GetAnswerBreakdownChartData(DataLevelEnum dataLevel)
		{
			//for the answer breakdown, we will split up the data differently depending on data level. So if the filters have all subjects, then
			//show the subject breakdown, else if we have subject set but have all domains then show domain breakdown etc.
			PieChartData<double> data = new PieChartData<double>();

			//Colors to assign to each item.
			string[] colors = new string[20] { "#0000cc", "#00cc00", "#cc0000", "#00cccc", "#cc00cc", "#cccc00", "#000066", "#006600", "#660000", "#006666",
											   "#660066", "#660000", "#0033cc", "#00cc33", "#cc0033", "#3300cc", "#33cc00", "#cc3300", "#3333cc", "#33cc33"};
			string[] hoverColors = new string[20] { "#0000ff", "#00ff00", "#ff0000", "#00ffff", "#ff00ff", "#ffff00", "#000099", "#009900", "#990000", "#009999",
											   "#990099", "#990000", "#0066ff", "#00ff66", "#ff0066", "#6600ff", "#66ff00", "#ff6600", "#6666ff", "#66ff66"};
			int i = 0;
			switch (dataLevel)
			{
				case DataLevelEnum.TimePeriod:
					//Only time period selected - subject set to all
					data.ValueLabel = "Vak gedeelte";
					var groupedData = from answers in submittedAnswers
									   group answers by answers.Subject into grouping
									   select new
									   {
										   Label = grouping.Key.ToString(),
										   Answers = grouping.Count()
									   };
					foreach (var item in groupedData)
					{
						data.Labels.Add(item.Label);
						data.Values.Add(item.Answers);
						data.Colors.Add(colors[i % 20]);
						data.HoverColors.Add(hoverColors[i % 20]);
						i++;
					}
					break;
				case DataLevelEnum.Subject:
					//Subject selected - domain set to all
					data.ValueLabel = "Domein gedeelte";
					groupedData = from answers in submittedAnswers
									  group answers by answers.Domain into grouping
									  select new
									  {
										  Label = grouping.Key.ToString(),
										  Answers = grouping.Count()
									  };
					foreach (var item in groupedData)
					{
						data.Labels.Add(item.Label);
						data.Values.Add(item.Answers);
						data.Colors.Add(colors[i % 20]);
						data.HoverColors.Add(hoverColors[i % 20]);
						i++;
					}
					break;
				default:
					//domain selected - Learning objective either set to all or a selected value, in both cases we just use learning objective
					data.ValueLabel = "Domein gedeelte";
					groupedData = from answers in submittedAnswers
									  group answers by answers.LearningObjective into grouping
									  select new
									  {
										  Label = grouping.Key.ToString(),
										  Answers = grouping.Count()
									  };
					foreach (var item in groupedData)
					{
						data.Labels.Add(item.Label);
						data.Values.Add(item.Answers);
						data.Colors.Add(colors[i % 20]);
						data.HoverColors.Add(hoverColors[i % 20]);
						i++;
					}
					break;

			}
			
			return data;
		}
	}
}