using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
