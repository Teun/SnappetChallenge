namespace Persistence.Users {
	using System.Collections.Generic;
	using Domain;
	using Microsoft.EntityFrameworkCore;
	using System.Linq;
	using System;

	public interface IUserStatsRepository {
		IEnumerable<UserStats> GetStats(
			DateTimeOffset startDate,
			DateTimeOffset endDate);
	}

	public class UserStatsRepository : IUserStatsRepository
	{
		private SchoolContext _db;

		public UserStatsRepository(SchoolContext dbContext)
		{
			_db = dbContext;
		}

		public IEnumerable<UserStats> GetStats(
			DateTimeOffset startDate,
			DateTimeOffset endDate)
		{
			/* If EF Core implemented GroupBy,
			 * we could write something like this in LINQ:

			from sa in SubmittedAnswers
			where sa.SubmittedAt <= end
				&& sa.SubmittedAt > start
			group sa by sa.User into userAnswers
			let u = userAnswers.Key
			let ExercisesAttempted =
				(from usa in userAnswers select usa.Exercise.Id).Distinct().Count()
			let ExercisesSolvedOnFirstTry = (
				from xsa in SubmittedAnswers
				where xsa.User == u
					&& userAnswers.Select(ua => ua.ExerciseId).Contains(xsa.ExerciseId)
				group xsa by xsa.ExerciseId into g2
				let firstAnswer = g2.OrderBy(a => a.Id).First()
				where firstAnswer.SubmittedAt <= end
					&& firstAnswer.SubmittedAt > start
				select firstAnswer.Correct ? 1 : 0
				).Sum()
			orderby ExercisesSolvedOnFirstTry descending
			select new {UserName = u.Name, ExercisesAttempted , ExercisesSolvedOnFirstTry}
			
			The EF Core team says it's on their backlog:
			https://github.com/aspnet/EntityFramework/issues/2341

			At the moment we have to write SQL.
			*/

			var ungrouped = _db.UserStats.AsNoTracking().FromSql(@"
select
	0 as Id -- Must either be unique for each record or used with AsNoTracking().
	, UserId
	, UserName
	, ExercisesAttempted
	, ExercisesSolvedOnFirstTry
	, ExercisesSolved
	, TriesCount / ExercisesAttempted as AvgTriesPerExercise
	, CAST(ExercisesSolvedOnFirstTry AS FLOAT) / ExercisesSolved as CorrectFirstTryRate
	, TotalProgress / CAST(ExercisesAttempted AS FLOAT) as AvgProgressPerExercise
	, TotalProgress
	, ProgressValue
from (
	select
		UserId
		, u.[Name] as UserName
		, COUNT(distinct ExerciseId) as ExercisesAttempted
		, SUM(IsCorrectOnFirstTry) as ExercisesSolvedOnFirstTry
		, COUNT(distinct IIF(Correct = 1, ExerciseId, NULL)) as ExercisesSolved
		, SUM(Progress) as TotalProgress
		, CAST(COUNT(*) AS FLOAT) as TriesCount
	from 
	(
		select
			Id
			, UserId
			, ExerciseId
			, Progress
			, SubmittedAt
			, Correct
-- This gives a false negative when the user solved solved the exercise before
-- the period start and the first try was successful.
-- We work around this by defining 'solved on the first try within period'
-- so that the first try must be within the period.
			, IIF(Correct = 1 and (ROW_NUMBER()
				OVER(PARTITION BY UserId, ExerciseId ORDER BY sa.Id)) = 1, 1, 0)
				as IsCorrectOnFirstTry
		from SubmittedAnswers sa
	) as q
	inner join Users u on q.UserId = u.Id
	where SubmittedAt > {0} and SubmittedAt <= {1}
	group by UserId, u.[Name]
) as q1
cross apply (
	select top(10) Progress as ProgressValue
	from SubmittedAnswers sa
	where Progress != 0 and sa.UserId = q1.UserId
		and SubmittedAt > {0} and SubmittedAt <= {1}
	order by sa.Id
) as LatestProgress
			", startDate, endDate)
			.ToList();
			return
				from x in ungrouped
				group x by x.UserId into g
				select Combine(g.First(), g.Select(s => s.ProgressValue).ToArray());
		}

		private static UserStats Combine(UserStats stats, int[] latestProgress)
		{
			stats.LatestProgress = latestProgress;
			return stats;
		}
	}
}