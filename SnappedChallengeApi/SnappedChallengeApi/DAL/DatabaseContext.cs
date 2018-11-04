using Newtonsoft.Json;
using SnappedChallengeApi.DAL.Models;
using SnappedChallengeApi.Models.Bussiness;
using SnappedChallengeApi.Models.Commons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SnappedChallengeApi.DAL
{
    public class DatabaseContext
    {
        private static bool IsInitialized = false;
        private static List<ExerciseResult> _database;
        private object _lockObject = new object();

        public DatabaseContext()
        {
            lock (_lockObject)
            {
                if (!IsInitialized)
                {
                    InitializeDbContext();
                    IsInitialized = true;
                }
            }
        }
        private void InitializeDbContext()
        {
            try
            {
                if (File.Exists(ServiceSettings.DataPath))
                {
                    var fileContent = File.ReadAllText(ServiceSettings.DataPath);
                    _database = JsonConvert.DeserializeObject<List<ExerciseResult>>(fileContent);
                }
                else
                {
                    throw new Exception(string.Format("DataFile is not found at {0}", ServiceSettings.DataPath));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<ClassworkSummary> GetClassworkSummary(DateTime startDate, DateTime endDate)
        {
            List<ClassworkSummary> classworkSummary = null;

            classworkSummary = (from record in _database
                                where record.SubmitDateTime.Date >= startDate && record.SubmitDateTime.Date <= endDate
                                group record by new
                                {
                                    record.SubmitDateTime.Date,
                                    record.Subject,
                                    record.Domain,
                                    record.LearningObjective
                                } into gcs
                                select new ClassworkSummary()
                                {
                                    Date = gcs.Key.Date,
                                    Subject = gcs.Key.Subject,
                                    Domain = gcs.Key.Domain,
                                    LearningObjective = gcs.Key.LearningObjective,
                                    ExerciseCount = gcs.Count(),
                                    WrongAnswerCount = gcs.Count(f => f.Correct == 0),
                                    CorrectAnswerCount = gcs.Count(f => f.Correct == 1),
                                    StudentCount = gcs.Select(f => f.UserId).Distinct().Count(),
                                    TotalProgress = gcs.Sum(f => f.Progress)
                                }).ToList();

            classworkSummary.AsParallel().ForAll(f => f.Analyze());

            return classworkSummary;
        }

        public List<ExerciseResult> GetExerciseResults(int offset, int limit)
        {
            return _database.Skip(offset).Take(limit).ToList();
        }
    }
}
