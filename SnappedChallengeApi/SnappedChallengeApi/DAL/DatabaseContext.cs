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
    /// <summary>
    /// Database Context simulation model class for the exercise
    /// usually this kind of data is stored a relational db like sql server or no sql like mongo etc.
    /// if releational db is being used it is a good idea to code provider model for the support of multiple dbs etc.
    /// But for keeping short i just coded a clean easy apporach with in memory json parse fetch.
    /// </summary>
    public class DatabaseContext
    {
        /// <summary>
        /// Initialization fetch flag
        /// </summary>
        private static bool _isInitialized = false;
        /// <summary>
        /// In memory data storage for the exercise for preventing constant io read
        /// </summary>
        private static List<ExerciseResult> _database;
        /// <summary>
        /// lock object for first initialization
        /// </summary>
        private object _lockObject = new object();

        /// <summary>
        /// Constructor
        /// </summary>
        public DatabaseContext()
        {
            lock (_lockObject)
            {
                if (!_isInitialized)
                {
                    InitializeDbContext();
                    _isInitialized = true;
                }
            }
        }

        /// <summary>
        /// Exercise data fetch method
        /// </summary>
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

        /// <summary>
        /// DAL method for classwork summary
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Another DAL method for exercise result usually odata or similar custom implementation through the dal layer methods 
        /// are widely used. I just implemented a basic ones to show the idea
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public List<ExerciseResult> GetExerciseResults(int offset, int limit)
        {
            return _database.Skip(offset).Take(limit).ToList();
        }
    }
}
