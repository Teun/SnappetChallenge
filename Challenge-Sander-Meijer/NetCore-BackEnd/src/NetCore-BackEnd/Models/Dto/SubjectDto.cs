using System.Collections.Generic;

namespace NetCore.BackEnd.Models.Dto
{
	public class SubjectDto
	{
		public string Subject { get; set; }

		public IEnumerable<WorkResultDto> WorkResults { get; set; }
	}
}