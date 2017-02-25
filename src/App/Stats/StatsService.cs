namespace App.Users
{
	using App.Exceptions;
	using Domain;
	using Persistence;
	using Persistence.Users;
	using System;
	using System.Collections.Generic;

	public interface IStatsService
	{
		UserStatsCollectionDto GetAllUsersStats(int startDateIndex);
	}

	public class StatsService : IStatsService
	{
		private IUserStatsRepository _repo;

		public StatsService(IUnitOfWork uow)
		{
			_repo = uow.UserStatsRepository;
		}

		public UserStatsCollectionDto GetAllUsersStats(int startDateIndex)
		{
			if (startDateIndex > 0 || startDateIndex < -21)
			{
				throw new ValidationException("startDateIndex out of range [-21; 0].");
			}

			var today = new DateTimeOffset(2015, 3, 24, 11, 30, 00, TimeSpan.Zero);
			DateTimeOffset endDate = today.AddDays(startDateIndex);
			DateTimeOffset startDate = endDate.AddDays(-7);
			IEnumerable<UserStats> stats = _repo.GetStats(startDate, endDate);
			return UserStatsCollectionDto.FromModel(stats, startDate, endDate);
		}
	}
}
