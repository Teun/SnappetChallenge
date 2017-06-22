using System;
using System.Linq;
using NetCore.BackEnd.Facades.Mappers;
using NetCore.BackEnd.Models.Dto;
using NetCore.BackEnd.Models.Poco;

namespace NetCore.BackEnd.Facades.Factories
{
	public class SubjectDtoFactory : IFactory<IGrouping<string, WorkResult>, SubjectDto>
	{
		private readonly IMapper<WorkResult, WorkResultDto> _mapper;

		public SubjectDtoFactory(IMapper<WorkResult, WorkResultDto> mapper)
		{
			if (mapper == null)
			{
				throw new ArgumentNullException(nameof(mapper));
			}
			_mapper = mapper;
		}

		public SubjectDto Create(IGrouping<string, WorkResult> item)
		{
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item));
			}

			return new SubjectDto
			{
				Subject = item.Key,
				WorkResults = _mapper.Map(item).ToList()
			};
		}
	}
}