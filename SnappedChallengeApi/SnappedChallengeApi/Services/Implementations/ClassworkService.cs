using SnappedChallengeApi.DAL;
using SnappedChallengeApi.DAL.Models;
using SnappedChallengeApi.Models.Bussiness;
using SnappedChallengeApi.Models.Commons.ApiCommons;
using SnappedChallengeApi.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SnappedChallengeApi.Services.Implementations
{
    /// <summary>
    /// Classworks Service for the backend
    /// </summary>
    public class ClassworkService : IClassworkService
    {
        /// <summary>
        /// DAL Layer instance
        /// </summary>
        private DatabaseContext _dbContext = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public ClassworkService()
        {
            _dbContext = new DatabaseContext();
        }

        /// <summary>
        /// Exercise Records Fetch Method
        /// </summary>
        /// <param name="qp"></param>
        /// <returns></returns>
        public List<ExerciseResult> GetExerciseRecords(QueryParameter qp)
        {
            List<ExerciseResult> records = null;
            try
            {
                records = _dbContext.GetExerciseResults(qp.Offset, qp.Limit);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return records;
        }

        /// <summary>
        /// Eercise Summary Preparation Method
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<ClassworkSummary> GetClassworkSummary(DateTime startDate, DateTime endDate)
        {
            List<ClassworkSummary> records = null;
            try
            {
                records = _dbContext.GetClassworkSummary(startDate, endDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return records;
        }
    }
}
