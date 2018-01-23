using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IWorkResultRepository : IRepository<WorkResult>
    {
        List<string> GetLearningObjectivesBySubjectAndDomain(string subject,string domain);
        List<string> GetDomainsBySubject(string subject);
        List<string> GetAllSubjects();

        List<WorkResult> SearchWorkResults(DateTime? startDateTime,
            DateTime? endDateTime,
            bool? Correct,
            int? Progress,
            int? UserId,
            int? ExerciseId,
            string Subject,
            string Domain,
            string LearningObjective);

        List<string> GetAllStudents();
        List<string> GetAllDomains();
        List<string> GetAllLearningObjectives();
    }
}
