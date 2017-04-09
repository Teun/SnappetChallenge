using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorBoard.Report.Dtos
{
    public class UserProgressReportDto
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public int Progress { get; set; }
    }
}
