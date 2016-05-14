using SnappetChallenge.Analysis;
using SnappetChallenge.Models;
using SnappetChallenge.Webservices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SnappetChallenge.Global;

namespace SnappetChallenge.Controllers
{
	public class WorkDataController : Controller
	{ 
		private List<SubmittedAnswer> SubmittedAnswers
		{
			get
			{
				if (ControllerContext.HttpContext.Session["SubmittedAnswers"] == null)
					return null;
				return (List<SubmittedAnswer>)ControllerContext.HttpContext.Session["SubmittedAnswers"];
			}
			set
			{
				ControllerContext.HttpContext.Session["SubmittedAnswers"] = value;
			}
		}

		private SchoolClass SchoolClass
		{
			get
			{
				if (ControllerContext.HttpContext.Session["SchoolClass"] == null)
					return null;
				return (SchoolClass)ControllerContext.HttpContext.Session["SchoolClass"];
			}
			set
			{
				ControllerContext.HttpContext.Session["SchoolClass"] = value;
			}
		}


		public JsonResult GetSubjects(int timePeriod)
		{
			//Set time to 2015-03-24 11:30:00 UTC
			DateTime currentDateTime = new DateTime(2015, 3, 24, 11, 30, 0);
			DateTime startDateTime = Utility.GetStartDateTime((TimePeriodEnum)timePeriod, currentDateTime);
			List<string> subjects = SubmittedAnswers.Where(x => x.SubmittedDateTime >= startDateTime && x.SubmittedDateTime < currentDateTime)
															.Select(x => x.Subject).Distinct().ToList<string>();

			List<SelectListItem> subjectsSelectListItems = new List<SelectListItem>();
			if (subjects.Count != 1)
				subjectsSelectListItems.Add(new SelectListItem { Text = "Alles", Value = "All" });

			foreach (string subject in subjects)
				subjectsSelectListItems.Add(new SelectListItem { Text = subject, Value = subject });
			
			return Json(new SelectList(subjectsSelectListItems, "Value", "Text"));
		}

		public JsonResult GetDomains(int timePeriod, string subject)
		{
			//Set time to 2015-03-24 11:30:00 UTC
			DateTime currentDateTime = new DateTime(2015, 3, 24, 11, 30, 0);
			DateTime startDateTime = Utility.GetStartDateTime((TimePeriodEnum)timePeriod, currentDateTime);
			List<string> domains = SubmittedAnswers.Where(x => x.SubmittedDateTime >= startDateTime && x.SubmittedDateTime < currentDateTime && x.Subject == subject)
															.Select(x => x.Domain).Distinct().ToList<string>();

			List<SelectListItem> domainsSelectListItems = new List<SelectListItem>();
			if (domains.Count != 1)
				domainsSelectListItems.Add(new SelectListItem { Text = "Alles", Value = "All" });

			foreach (string domain in domains)
				domainsSelectListItems.Add(new SelectListItem { Text = domain, Value = domain });

			return Json(new SelectList(domainsSelectListItems, "Value", "Text"));
		}

		public JsonResult GetLearningObjectives(int timePeriod, string subject, string domain)
		{
			//Set time to 2015-03-24 11:30:00 UTC
			DateTime currentDateTime = new DateTime(2015, 3, 24, 11, 30, 0);
			DateTime startDateTime = Utility.GetStartDateTime((TimePeriodEnum)timePeriod, currentDateTime);
			List<string> learningObjectives = SubmittedAnswers.Where(x => x.SubmittedDateTime >= startDateTime && x.SubmittedDateTime < currentDateTime && x.Subject == subject && x.Domain == domain)
															.Select(x => x.LearningObjective).Distinct().ToList<string>();

			List<SelectListItem> learningObjectivesSelectListItems = new List<SelectListItem>();
			if (learningObjectives.Count != 1)
				learningObjectivesSelectListItems.Add(new SelectListItem { Text = "Alles", Value = "All" });

			foreach (string learningObjective in learningObjectives)
				learningObjectivesSelectListItems.Add(new SelectListItem { Text = learningObjective, Value = learningObjective });

			return Json(new SelectList(learningObjectivesSelectListItems, "Value", "Text"));
		}

		public JsonResult GetAnswerStatistics(int timePeriod, string subject, string domain, string learningObjective)
		{
			//Set time to 2015-03-24 11:30:00 UTC
			DateTime currentDateTime = new DateTime(2015, 3, 24, 11, 30, 0);
			DateTime startDateTime = Utility.GetStartDateTime((TimePeriodEnum)timePeriod, currentDateTime);
			var filteredAnswers = SubmittedAnswers.Where(x => x.SubmittedDateTime >= startDateTime && x.SubmittedDateTime < currentDateTime && (subject == "All" ? 1 == 1 : x.Subject == subject) && (domain == "All" ? 1 == 1 : x.Domain == domain) && (learningObjective == "All" ? 1 == 1 : x.LearningObjective == learningObjective));

			int numberOfStudents = 0;
			int numberOfAnswers = 0;
			int numberOfCorrectAnswers = 0;
			double percentCorrectAnswers = 0;
			double averageAnswersPerStudent = 0;
			double averageCorrectAnswersPerStudent = 0;
			double highestDifficulty = 0;
			double lowestDifficulty = 0;
			double averageDifficulty = 0;

			BarChartData<double> answersPerStudentPerDayData = new BarChartData<double>();
			BarChartData<double> percentCorrectPerDayData = new BarChartData<double>();
			BarChartData<int> progressPerStudentData = new BarChartData<int>();
			BarChartData<double> averageDifficultyPerStudentData = new BarChartData<double>();
			BarChartData<double> percentCorrectPerStudentData = new BarChartData<double>();
			BarChartData<int> studentsWithAnswersPerDayData = new BarChartData<int>();

			PieChartData < double > answerBreakdownData = new PieChartData<double>();

			if (filteredAnswers != null && filteredAnswers.Count() > 0)
			{
				WorkAnalysis workAnalysis = new WorkAnalysis(filteredAnswers);

				numberOfStudents = workAnalysis.GetNumberOfStudents();
				numberOfAnswers = filteredAnswers.Count();
				numberOfCorrectAnswers = workAnalysis.GetNumberOfCorrectAnswers();
				percentCorrectAnswers = ((double)numberOfCorrectAnswers / (double)numberOfAnswers) * 100;
				averageAnswersPerStudent = (double)numberOfAnswers / (double)numberOfStudents;
				averageCorrectAnswersPerStudent = (double)numberOfCorrectAnswers / (double)numberOfStudents;
				averageCorrectAnswersPerStudent = (double)numberOfCorrectAnswers / (double)numberOfStudents;
				highestDifficulty = workAnalysis.GetHighestDifficulty();
				lowestDifficulty = workAnalysis.GetLowestDifficulty();
				averageDifficulty = workAnalysis.GetAverageDifficulty();

				answersPerStudentPerDayData = workAnalysis.GetAnswersPerStudentPerDayChartData();
				percentCorrectPerDayData = workAnalysis.GetPercentCorrectPerDayChartData();
				progressPerStudentData = workAnalysis.GetProgressPerStudentChartData();
				percentCorrectPerStudentData = workAnalysis.GetPercentCorrectPerStudentChartData();
				averageDifficultyPerStudentData = workAnalysis.GetAverageDifficultyPerStudentChartData();
				studentsWithAnswersPerDayData = workAnalysis.GetStudentsWithAnswersPerDayChartData();

				DataLevelEnum dataLevel = DataLevelEnum.TimePeriod;
				if (subject == "All")
					dataLevel = DataLevelEnum.TimePeriod;
				else if (domain == "All")
					dataLevel = DataLevelEnum.Subject;
				else if (learningObjective == "All")
					dataLevel = DataLevelEnum.Domain;
				else
					dataLevel = DataLevelEnum.LearningObjective;
				answerBreakdownData = workAnalysis.GetAnswerBreakdownChartData(dataLevel);
			}

			return Json(new
			{
				numberOfStudents = numberOfStudents,
				numberOfAnswers = numberOfAnswers,
				numberOfCorrectAnswers = numberOfCorrectAnswers,
				percentCorrectAnswers = percentCorrectAnswers,
				averageAnswersPerStudent = averageAnswersPerStudent,
				averageCorrectAnswersPerStudent = averageCorrectAnswersPerStudent,
				highestDifficulty = highestDifficulty,
				lowestDifficulty = lowestDifficulty,
				averageDifficulty = averageDifficulty,
				answersPerStudentPerDayData = answersPerStudentPerDayData,
				percentCorrectPerDayData = percentCorrectPerDayData,
				percentCorrectPerStudentData = percentCorrectPerStudentData,
				progressPerStudentData = progressPerStudentData,
				averageDifficultyPerStudentData = averageDifficultyPerStudentData,
				studentsWithAnswersPerDayData = studentsWithAnswersPerDayData,
				answerBreakdownData = answerBreakdownData
			});
		}
	}
}


