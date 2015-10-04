using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;
using Snappet.DataAccess.Entities;

namespace Snappet.DataAccess
{
    public interface IExerciseResultRepository
    {
        IEnumerable<ExerciseResultEntity> GetByDate();
        void Save(List<ExerciseResultEntity> entities);

        List<ExerciseResultEntity> GetExerciseResults(int domainId,int userId, int page, int count, string searchText,
            string orderedcolumn, string orderDirection);

        int GetExerciseResultsCount(int domainId,int userId ,string searchText);

        void DeleteAll();
        IEnumerable<UserEntity> GetUsers(int domainId);
    }
    public class ExerciseResultRepository : BaseRepository<ExerciseResultEntity>,  IExerciseResultRepository
    {
        private SnappetContext _dbContext;

        public ExerciseResultRepository(SnappetContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ExerciseResultEntity> GetExerciseResults(int domainId, int userId, int page, int count, string searchText, 
            string orderedcolumn, string orderDirection)
        {
            var endTime = new DateTime(2015, 3, 24, 11, 30, 0);
            var startTime = new DateTime(2015, 3, 24, 0, 0, 0);
            var exerciseResults = (from result in _dbContext.ExerciseResults
                    where result.SubmitDateTime > startTime &&
                    result.SubmitDateTime < endTime && result.DomainId== domainId 
                    && result.UserId == userId
                    select result);
            if (!string.IsNullOrEmpty(searchText))
            {
                exerciseResults = exerciseResults.FullTextSearch(searchText, false).AsNoTracking();

            }
            switch (orderedcolumn)
            {
                case "Id":
                    return (orderDirection == "asc") ? exerciseResults.OrderBy(x => x.Id).Skip((page) * count).Take(count)
                        .ToList() : exerciseResults.OrderByDescending(x => x.Id).Skip((page) * count).Take(count)
               .ToList();
                case "UserId":
                    return (orderDirection == "asc") ? exerciseResults.OrderBy(x => x.UserId).Skip((page) * count).Take(count)
                        .ToList() : exerciseResults.OrderByDescending(x => x.UserId).Skip((page) * count).Take(count)
               .ToList();
                case "Subject":
                    return (orderDirection == "asc") ? exerciseResults.OrderBy(x => x.SubjectId).Skip((page) * count).Take(count)
                        .ToList() : exerciseResults.OrderByDescending(x => x.SubjectId).Skip((page) * count).Take(count)
               .ToList();
                case "ExerciseId":
                    return (orderDirection == "asc") ? exerciseResults.OrderBy(x => x.ExerciseId).Skip((page) * count).Take(count)
                       .ToList() : exerciseResults.OrderByDescending(x => x.ExerciseId).Skip((page) * count).Take(count)
              .ToList();
                case "LearningObjective":
                    return (orderDirection == "asc") ? exerciseResults.OrderBy(x => x.LearningObjectiveId).Skip((page) * count).Take(count)
                        .ToList() : exerciseResults.OrderByDescending(x => x.LearningObjectiveId).Skip((page) * count).Take(count)
                .ToList();
                default:
                    return exerciseResults.OrderByDescending(x => x.Id).Skip((page) * count).Take(count)
              .ToList();

            }

        }
        public int GetExerciseResultsCount(int domainId, int userId,string searchText)
        { 
            var endTime = new DateTime(2015, 3, 24, 11, 30, 0);
            var startTime= new DateTime(2015,3,24,0,0,0);

            var results = (from result in _dbContext.ExerciseResults
                        where startTime < result.SubmitDateTime  && result.SubmitDateTime < endTime
                        && result.DomainId== domainId && result.UserId == userId
                        select result); 
            if (!string.IsNullOrEmpty(searchText))
            {
                results = results.FullTextSearch(searchText, false);
            }
            var count = results.Count();
            return count;

        }

        public IEnumerable<UserEntity> GetUsers(int domainId)
        {
            var endTime = new DateTime(2015, 3, 24, 11, 30, 0);
            var startTime = new DateTime(2015, 3, 24, 0, 0, 0);

            //return (from result in _dbContext.ExerciseResults
            //    where
            //        result.SubmitDateTime > startTime && result.SubmitDateTime < endTime && result.DomainId == domainId
            //    select result).
            //    GroupBy(x => x.UserId).Select(x => new UserEntity()
            //    {
            //        UserId = x.Key,
            //        UserResults = x.GroupBy(y => y.SubjectId).Select(z => new UserResultEntity()
            //        {
            //            TotalAnswers = z.Count(),
            //            SubjectId = z.Key
            //        }).ToList()
            //    }).ToList();

            return _dbContext.GetUsers(startTime, endTime, domainId);
        }

        public IEnumerable<ExerciseResultEntity> GetByDate()
        {
            var today = new DateTime(2015, 3, 24, 11, 30, 0);
            return (from result in _dbContext.ExerciseResults
                    where result.SubmitDateTime< today
                    select result);
        }

        public IEnumerable<DomainEntity> GetDomains()
        {
            return _dbContext.Domains;

        }
        public IEnumerable<SubjectEntity> GetSubjects()
        {
            return _dbContext.Subjects;
        }
        public IEnumerable<LearningObjectiveEntity> GetLearningObjectives()
        {
            return _dbContext.LearningObjectives;
        }

        public void DeleteAll()
        {
            _dbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE ExerciseResult");
            _dbContext.SaveChanges();
        }

        public void Save(List<ExerciseResultEntity> exerciseResults)
        {
            _dbContext.ExerciseResults.AddRange(exerciseResults);
            _dbContext.SaveChanges();
           
                _dbContext.Dispose();
                _dbContext = new SnappetContext();
                _dbContext.Configuration.AutoDetectChangesEnabled = false;
            
        }
    }
}
