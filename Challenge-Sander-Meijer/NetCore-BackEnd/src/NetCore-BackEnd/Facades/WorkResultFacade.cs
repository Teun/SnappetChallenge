using System;
using System.Collections.Generic;
using System.Linq;
using NetCore.BackEnd.Facades.Factories;
using NetCore.BackEnd.Models.Dto;
using NetCore.BackEnd.Models.Poco;
using NetCore.BackEnd.Repositories;

namespace NetCore.BackEnd.Facades
{
	public class WorkResultFacade : IWorkResultFacade
	{
		private readonly IWorkResultRepository _workResultRepository;
		private readonly IFactory<IGrouping<int, WorkResult>, UserDto> _userDtoFactory;

		public WorkResultFacade(
			IWorkResultRepository workResultRepository,
			IFactory<IGrouping<int, WorkResult>, UserDto> userDtoFactory)
		{
			if (workResultRepository == null)
			{
				throw new ArgumentNullException(nameof(workResultRepository));
			}
			if (userDtoFactory == null)
			{
				throw new ArgumentNullException(nameof(userDtoFactory));
			}

			_workResultRepository = workResultRepository;
			_userDtoFactory = userDtoFactory;
		}

		public IEnumerable<UserDto> GetAllForPeriod(DateTime startTimeUtc, DateTime endTimeUtc)
		{
			if (endTimeUtc.Equals(DateTime.MinValue))
			{
				endTimeUtc = DateTime.MaxValue;
			}

			var items = _workResultRepository.GetWorkResultsForPeriod(startTimeUtc, endTimeUtc);

			return items
				.GroupBy(item => item.UserId)
				.Select(grouping => _userDtoFactory.Create(grouping));
		}
	}
}