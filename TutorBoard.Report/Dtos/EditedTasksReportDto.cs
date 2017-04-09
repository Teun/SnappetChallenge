using System.Collections.Generic;

namespace TutorBoard.Report.Dtos
{
    public class EditedTasksReportDto
    {
        public int Summary { get; set; }

        public IEnumerable<SubjectEditedTasksCountDto> SubjectCounts { get; set; }
    }
}
