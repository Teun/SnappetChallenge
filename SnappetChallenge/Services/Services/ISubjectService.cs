using Services.Dto;
using System.Collections.Generic;

namespace Services.Services
{
    public interface ISubjectService
    {
        IReadOnlyCollection<Subject> GetSubjects();

        SubjectStatistics GetSubject(string subject);
    }
}
