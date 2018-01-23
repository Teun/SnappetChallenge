using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;

namespace SnappetChallenge.Services
{
    public class WorkResultService : IWorkResultService
    {
        private readonly IWorkResultRepository _workResultRepository;

        public WorkResultService(IWorkResultRepository workResultRepository)
        {
            _workResultRepository = workResultRepository;
        }


        public List<string> GetLearningObjectivesBySubjectAndDomain(string subject, string domain)
        {
            return _workResultRepository.GetLearningObjectivesBySubjectAndDomain(subject, domain);
        }

        public List<string> GetDomainsBySubject(string subject)
        {
            return _workResultRepository.GetDomainsBySubject(subject);
        }

        public List<string> GetAllSubjects()
        {
            return _workResultRepository.GetAllSubjects();
        }

        public List<string> GetAllDomains()
        {
            return _workResultRepository.GetAllDomains();
        }

        public List<string> GetAllLearningObjectives()
        {
            return _workResultRepository.GetAllLearningObjectives();
        }

        public List<dynamic> GetStudentTodayWork(int userId)
        {
            var result = _workResultRepository.SearchWorkResults(new DateTime(2015, 3, 24, 0, 0, 0), new DateTime(2015, 3, 24, 11, 30, 0), null, null, userId, null, string.Empty, string.Empty, string.Empty);


            var s = result.GroupBy(x => new { x.ExerciseId ,x.Domain,x.Subject,x.LearningObjective})
                .Select(g =>
                    new
                    {
                        g.Key.ExerciseId,
                        g.Key.Domain,
                        g.Key.LearningObjective,
                        g.Key.Subject,
                        NumberOfQuestions = g.Count(x => x.SubmittedAnswerId > 0),
                        CorrectAnswers = g.Count(x => x.Correct),
                        IncorrectAnswers = g.Count(x => !x.Correct),
                        TotalProgress = g.Sum(x => x.Progress)
                    })
                .OrderByDescending(x => x.TotalProgress)
                .ToList();
            return ((IEnumerable<dynamic>)s).ToList();
        }

        public List<dynamic> GetStudentSummary(int userId, DateTime startDate, DateTime endDate)
        {
            List<WorkResult> result = _workResultRepository.SearchWorkResults(startDate, endDate, null, null, userId, null, string.Empty, string.Empty, string.Empty);
            var s = result.GroupBy(x => x.SubmitDateTime.Date)
                .Select(g =>
                    new
                    {
                        Date = g.Key,
                        NumberOfExcercises = g.Count(x => x.ExerciseId > 0),
                        NumberOfQuestions = g.Count(x => x.SubmittedAnswerId > 0),
                        CorrectAnswers = g.Count(x => x.Correct),
                        IncorrectAnswers = g.Count(x => !x.Correct),
                        TotalProgress = g.Sum(x => x.Progress)
                    })
                .OrderBy(x => x.Date)
                .ToList();
            return ((IEnumerable<dynamic>)s).ToList();
        }

        public List<ClassWorkResult> GetTodayWorkResults()
        {
            return GetWorkResults(new DateTime(2015, 3, 24, 0, 0, 0), new DateTime(2015, 3, 24, 11, 30, 0));
        }

        public List<ClassWorkResult> GetWorkResults(DateTime startDate, DateTime endDate)
        {
            var result = _workResultRepository.SearchWorkResults(startDate, endDate, null, null, null, null, string.Empty, string.Empty, string.Empty);


            var s = result.GroupBy(x => x.UserId)
                .Select(g =>
                    new ClassWorkResult
                    {
                        UserId = g.Key,
                        NumberOfExercises = g.Select(x => x.ExerciseId).Distinct().Count(),
                        NumberOfQuestions = g.Count(x => x.SubmittedAnswerId > 0),
                        CorrectAnswers = g.Count(x => x.Correct),
                        IncorrectAnswers = g.Count(x => !x.Correct),
                        TotalProgress = g.Sum(x => x.Progress)
                    })
                .OrderByDescending(x => x.TotalProgress)
                .ToList();
            return s;

        }

        public List<WorkResult> SearchWorkResults(DateTime? startDateTime, DateTime? endDateTime, bool? Correct, int? Progress, int? UserId,
            int? ExerciseId, string Subject, string Domain, string LearningObjective)
        {
            return _workResultRepository.SearchWorkResults(startDateTime, endDateTime, Correct, Progress, UserId, ExerciseId, Subject, Domain, LearningObjective);
        }

        public List<dynamic> GetStudentSubjects(int userId, DateTime startDate, DateTime endDate)
        {
            List<WorkResult> result = _workResultRepository.SearchWorkResults(startDate, endDate, null, null, userId, null, string.Empty, string.Empty, string.Empty);
            var s = result.GroupBy(x => x.Subject)
                .Select(g =>
                    new
                    {
                        Subject = g.Key,
                        NumberOfExercises = g.Select(x => x.ExerciseId).Distinct().Count(),
                        NumberOfQuestions = g.Count(x => x.SubmittedAnswerId > 0),
                        CorrectAnswers = g.Count(x => x.Correct),
                        IncorrectAnswers = g.Count(x => !x.Correct),
                        TotalProgress = g.Sum(x => x.Progress)
                    })
                .OrderByDescending(x => x.TotalProgress)
                .ToList();
            return ((IEnumerable<dynamic>)s).ToList(); ;
        }

        public List<string> GetAllStudents()
        {
            return _workResultRepository.GetAllStudents();
        }
    }
}
