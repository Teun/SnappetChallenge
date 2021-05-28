using Snappet.Application.Dtos;
using System.Collections.Generic;

public class DailyStatsSummary
{
    public List<DomainStats> Domains { get; set; }
    public List<LearningObjectiveStats> LearningObjectives { get; set; }
    public List<SubjectStats> Subjects { get; set; }

    public List<IndividualStudentStats> Students { get; set; }
}
