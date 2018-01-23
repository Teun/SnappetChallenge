using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces.Services
{
    public interface IWorkResultService
    {
        List<string> GetLearningObjectivesBySubjectAndDomain(string subject, string domain);
        List<string> GetDomainsBySubject(string subject);
        List<string> GetAllSubjects();
        List<string> GetAllDomains();
        List<string> GetAllLearningObjectives();
        List<ClassWorkResult> GetTodayWorkResults();
        List<WorkResult> SearchWorkResults(DateTime? startDateTime,
            DateTime? endDateTime,
            bool? Correct,
            int? Progress,
            int? UserId,
            int? ExerciseId,
            string Subject,
            string Domain,
            string LearningObjective);

        List<dynamic> GetStudentTodayWork(int userId);
        List<dynamic> GetStudentSummary(int userId, DateTime starDate, DateTime endDate);
        List<dynamic> GetStudentSubjects(int userId, DateTime startDate, DateTime endDate);
        List<string> GetAllStudents();
    }
}
