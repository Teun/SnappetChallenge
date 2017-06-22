using System.Collections.Generic;

namespace NetCore.BackEnd.Models.Dto
{
	public class UserDto
	{
		public int UserId { get; set; }

		public IEnumerable<SubjectDto> Subjects { get; set; }
	}
}