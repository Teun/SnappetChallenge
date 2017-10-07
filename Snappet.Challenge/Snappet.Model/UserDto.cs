using Snappet.Model;
using System.Collections.Generic;

namespace Snappet.Model
{
    public class UserDto
    {
        public int UserId { get; set; }
        public IEnumerable<SubjectDto> Subjects { get; set; }
    }
}