using System;
using System.Linq;
using NetCore.BackEnd.Models.Dto;
using NetCore.BackEnd.Models.Poco;

namespace NetCore.BackEnd.Facades.Factories
{
	public class UserDtoFactory : IFactory<IGrouping<int, WorkResult>, UserDto>
	{
		private readonly IFactory<IGrouping<string, WorkResult>, SubjectDto> _subjectDtoFactory;

		public UserDtoFactory(IFactory<IGrouping<string, WorkResult>, SubjectDto> subjectDtoFactory)
		{
			if (subjectDtoFactory == null)
			{
				throw new ArgumentNullException(nameof(subjectDtoFactory));
			}
			_subjectDtoFactory = subjectDtoFactory;
		}

		public UserDto Create(IGrouping<int, WorkResult> item)
		{
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item));
			}

			var subjects = item
				.GroupBy(workResult => workResult.Subject)
				.Select(grouping => _subjectDtoFactory.Create(grouping));

			return new UserDto
			{
				UserId = item.Key,
				Subjects = subjects
			};
		}
	}
}