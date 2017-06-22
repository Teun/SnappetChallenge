using System;
using System.Collections.Generic;
using System.Linq;
using NetCore.BackEnd.Models.Dto;
using NetCore.BackEnd.Models.Poco;

namespace NetCore.BackEnd.Facades.Mappers
{
	public class WorkResultDtoMapper : IMapper<WorkResult, WorkResultDto>
	{
		public IEnumerable<WorkResultDto> Map(IEnumerable<WorkResult> item)
		{
			return item.Select(Map);
		}

		public WorkResultDto Map(WorkResult item)
		{
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item));
			}

			return new WorkResultDto
			{
				Correct = item.Correct,
				ExcerciseId = item.ExerciseId,
				Domain = item.Domain,
				LearningObjective = item.LearningObjective
			};
		}
	}
}