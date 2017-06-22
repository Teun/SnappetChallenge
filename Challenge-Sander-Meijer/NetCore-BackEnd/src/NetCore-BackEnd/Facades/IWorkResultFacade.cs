using System;
using System.Collections.Generic;
using NetCore.BackEnd.Models.Dto;

namespace NetCore.BackEnd.Facades
{
	public interface IWorkResultFacade
	{
		IEnumerable<UserDto> GetAllForPeriod(DateTime startTimeUtc, DateTime endTimeUtc);
	}
}