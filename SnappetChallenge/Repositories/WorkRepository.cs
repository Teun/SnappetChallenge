using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using SnappetChallenge.Models;

namespace SnappetChallenge.Repositories
{
    public class WorkRepository
    {
        public List<Subject> GetExcercisesForStudent(Int64 userId)
        {
            IEnumerable<Work> workByStudent = GetResults(userId);
            IEnumerable<Work> subjects = workByStudent.DistinctBy(x => x.LearningObjective);
            IEnumerable<Subject> results = GetResultsOfSubjects(subjects, workByStudent);

            return results.OrderBy(x => x.SubjectName).ThenBy(x => x.Domain).ToList();
        }

        private static IEnumerable<Subject> GetResultsOfSubjects(IEnumerable<Work> subjects, IEnumerable<Work> workByStudent)
        {
            return subjects.Select(work => new Subject
            {
                SubjectName = work.Subject, Domain = work.Domain, LearningObjective = work.LearningObjective, TotalAnswered = GetTotalAnsweredPerLearningObjective(workByStudent, work.LearningObjective), CorrectAnswered = GetCorrectAnsweredPerLearningObjective(workByStudent, work.LearningObjective)
            }).ToList();
        }

        private static int GetTotalAnsweredPerLearningObjective(IEnumerable<Work> subjects, string learningObjective)
        {
            IEnumerable<Work> exercises = subjects.Where(x => x.LearningObjective == learningObjective);
            return exercises.DistinctBy(x => x.ExerciseId).Count();
        }

        private static int GetCorrectAnsweredPerLearningObjective(IEnumerable<Work> subjects, string learningObjective)
        {
            IEnumerable<Work> exercises = subjects.Where(x => x.LearningObjective == learningObjective);
            return exercises.Where(x => x.Correct == 1).DistinctBy(x => x.ExerciseId).Count();
        }

        private static List<Work> GetResults(Int64 userId)
        {
            List<Work> results = GetDataFromJson();
            DateTime today = new DateTime(2015, 3, 24);
            List<Work> workDone = results.Where(x => x.SubmitDateTime.Date == today.Date && x.UserId == userId).ToList();
            
            return workDone;
        }

        private static List<Work> GetDataFromJson()
        {
            List<Work> results;
            using (StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/work.json")))
            {
                results = JsonConvert.DeserializeObject<List<Work>>(sr.ReadToEnd());
            }
            return results;
        }
    }
}