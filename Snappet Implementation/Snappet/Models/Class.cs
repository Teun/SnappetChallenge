using System.Collections.Generic;

namespace Snappet.Models
{
    public class Class
    {
        public List<User> Students { get; set; }
        public string TeacherName { get; set; }

        public Class(string teacherName)
        {
            this.TeacherName = teacherName;
            this.Students = new List<User>();
        }
    }
}
