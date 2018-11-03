using SnappedChallengeApi.DAL;
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
    }
}
