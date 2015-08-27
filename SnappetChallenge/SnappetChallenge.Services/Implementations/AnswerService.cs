

namespace SnappetChallenge.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    
    using DAL.Entities;
    using DAL.Repository;
    using Enums;
    using Interfaces;

    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork unitOfWork;

        public AnswerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Answer> Get(Expression<Func<Answer, bool>> whereClause)
        {
            return this.unitOfWork.AnswerRepository.Get(whereClause).ToList();
        }

        public List<AnswerResult> GetAnswersByStudentAndExerciseInRange(long studentId, long[] exerciseIds, DateTime start, DateTime end)
        {
            var result = new List<AnswerResult>();

            // per exerciseId ophalen
            foreach (var exerciseId in exerciseIds)
            {
                var answer = unitOfWork.AnswerRepository
                    .Get(
                        a => a.StudentId == studentId &&
                        a.ExerciseId == exerciseId &&
                        a.SubmitDateTime >= start &&
                        a.SubmitDateTime <= end)
                    .FirstOrDefault();

                if (answer != null)
                {
                    result.Add(answer.Correct ? AnswerResult.Correct : AnswerResult.Incorrect);
                }
                else
                {
                    result.Add(AnswerResult.NotMade);
                }
                
            }



            return result;
        }
    }
}
