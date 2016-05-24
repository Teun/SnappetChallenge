using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Models
{
    public class ClassClass
    {
        public List<UserClass> Students { get; set; }
        public string TeacherName { get; set; }

        public ClassClass(string teacherName)
        {
            this.TeacherName = teacherName;
            this.Students = new List<UserClass>();
        }
    }
}
