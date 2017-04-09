using System.Collections.Generic;

namespace TutorBoard.Report.Dtos
{
    public class DailyReportDto
    {
        public EditedTasksReportDto EditedTasks { get; set; }

        public IEnumerable<UserProgressReportDto> UserProgress { get; set; }
    }
}
