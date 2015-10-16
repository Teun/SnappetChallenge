using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Web.Data;
using Web.ViewModels;

namespace Web.Controllers
{
	[RoutePrefix("api/result")]
	public class ResultController : ApiController
	{
		[HttpGet]
		[Route("overview")]
		public IHttpActionResult GetOverview()
		{
			var dates = new List<DateTime>();

			using (var db = new SnappetContext())
			{
				var ndates = db.SubmittedAnswers.Where(sa => DbFunctions.TruncateTime(sa.SubmitDateTime) < new DateTime(2015, 3, 24)).Select(sa => DbFunctions.TruncateTime(sa.SubmitDateTime)).Distinct().ToList();

				foreach (var date in ndates.OrderBy(d => d.Value).ToList())
				{
					if (!date.HasValue) continue;
					dates.Add(date.Value);
				}
			}

			return Json(new { dates = dates });
		}

		[HttpGet]
		[Route("day-overview")]
		public IHttpActionResult GetDayOverview(DateTime date)
		{
			if (date > new DateTime(2015, 3, 24))
			{
				date = new DateTime(2015, 3, 24);
			}

			var studentOverviews = new List<StudentOverview>();
			var dates = new List<DateTime>();

			using (var db = new SnappetContext())
			{
				var dayAnswers = db.SubmittedAnswers.Where(sa => DbFunctions.TruncateTime(sa.SubmitDateTime) == date.Date).ToList();

				var userIds = dayAnswers.Select(sa => sa.UserId).Distinct();

				foreach (var userId in userIds)
				{
					var studentOverview = new StudentOverview();

					var studentDayAnswers = dayAnswers.Where(sa => sa.UserId == userId);

					studentOverview.UserId = userId;
					studentOverview.Date = date.Date;

					var learningObjectives = studentDayAnswers.OrderBy(sa => sa.LearningObjective).Select(sa => sa.LearningObjective).Distinct();

					studentOverview.LearningObjectives = new List<LearningObjectiveOverview>();

					foreach (var learningObjective in learningObjectives)
					{
						var learningObjectiveOverview = new LearningObjectiveOverview();
						
						studentOverview.LearningObjectives.Add(learningObjectiveOverview);
					}

					studentOverview.CorrectAnswers = studentDayAnswers.Where(sa => sa.Correct == 1).Count();
					studentOverview.IncorrectAnswers = studentDayAnswers.Where(sa => sa.Correct == 0).Count();
					studentOverview.Progress = studentDayAnswers.Select(sa => sa.Progress).Sum();

					studentOverviews.Add(studentOverview);
				}
			}

			return Json(studentOverviews);
		}

		[HttpGet]
		[Route("day-detail")]
		public IHttpActionResult GetDayDetail(DateTime date, int userId)
		{
			var studentOverview = new StudentOverview();

			var dates = new List<DateTime>();

			using (var db = new SnappetContext())
			{
				var studentAnswers = db.SubmittedAnswers.Where(sa => sa.UserId == userId).ToList();
				
				var studentDayAnswers = studentAnswers.Where(sa => sa.SubmitDateTime.Date == date.Date).ToList();
				
				studentOverview.UserId = userId;
				studentOverview.Date = date.Date;

				var learningObjectives = studentDayAnswers.OrderBy(sa => sa.LearningObjective).Select(sa => sa.LearningObjective).Distinct();

				studentOverview.LearningObjectives = new List<LearningObjectiveOverview>();

				foreach (var learningObjective in learningObjectives)
				{
					var learningObjectiveOverview = new LearningObjectiveOverview();

					var learningObjectiveAnswers = studentDayAnswers.Where(sa => sa.LearningObjective == learningObjective).ToList();

					learningObjectiveOverview.LearningObjective = learningObjective;
					learningObjectiveOverview.UserId = userId;
					learningObjectiveOverview.Progress = learningObjectiveAnswers.Select(sa => sa.Progress).Sum();

					learningObjectiveOverview.CorrectAnswers = learningObjectiveAnswers.Where(sa => sa.Correct == 1).Count();
					learningObjectiveOverview.IncorrectAnswers = learningObjectiveAnswers.Where(sa => sa.Correct == 0).Count();

					studentOverview.LearningObjectives.Add(learningObjectiveOverview);
				}

				studentOverview.CorrectAnswers = studentDayAnswers.Where(sa => sa.Correct == 1).Count();
				studentOverview.IncorrectAnswers = studentDayAnswers.Where(sa => sa.Correct == 0).Count();
				studentOverview.Progress = studentDayAnswers.Select(sa => sa.Progress).Sum();
			}

			return Json(studentOverview);
		}


	}
}
