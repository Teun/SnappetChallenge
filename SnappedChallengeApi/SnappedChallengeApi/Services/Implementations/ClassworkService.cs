using SnappedChallengeApi.DAL;
using SnappedChallengeApi.DAL.Models;
using SnappedChallengeApi.Models.Bussiness;
using SnappedChallengeApi.Models.Commons.ApiCommons;
using SnappedChallengeApi.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SnappedChallengeApi.Services.Implementations
{
    public class ClassworkService : IClassworkService
    {
        private DatabaseContext _dbContext = null;


        public ClassworkService()
        {
            _dbContext = new DatabaseContext();
        }

        public List<ExerciseResult> GetExerciseRecords(QueryParameter qp)
        {
            List<ExerciseResult> records = null;
            try
            {
                records = _dbContext.GetExerciseResults(qp.Offset, qp.Limit);
            }
            catch(Exception ex)
            {
                throw;
            }

            return records;
        }

        public List<ClassworkSummary> GetClassworkSummary(DateTime startDate, DateTime endDate)
        {
            List<ClassworkSummary> records = null;
            try
            {
                records = _dbContext.GetClassworkSummary(startDate, endDate);
            }
            catch (Exception ex)
            {
                throw;
            }

            return records;
        }
    }
}
