namespace App.Users
{
	using Domain;
	using System;
	using System.Linq;
	using System.Collections.Generic;

	public class UserStatsCollectionDto
	{
		public DateTimeOffset PeriodStart { get; set; }
		public DateTimeOffset PeriodEnd { get; set; }
		public UserStatsDto[] Stats { get; set; }

		internal static UserStatsCollectionDto FromModel(
			IEnumerable<UserStats> stats,
			DateTimeOffset startDate,
			DateTimeOffset endDate)
		{
			// Sorting here instead of on the DB for convenience.
			// If performace gets low or paging over users is needed,
			// move sorting to DB.
			IOrderedEnumerable<UserStatsDto> sorted = stats
				.Select(s => UserStatsDto.FromModel(s))
				.OrderByDescending(x => x.ExercisesSolved);
			return new UserStatsCollectionDto
			{
				PeriodStart = startDate,
				PeriodEnd = endDate,
				Stats = sorted.ToArray()
			};
		}
	}
}