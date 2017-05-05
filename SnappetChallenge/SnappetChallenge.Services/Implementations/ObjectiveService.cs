namespace SnappetChallenge.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    
    using DAL.Entities;
    using DAL.Repository;
    using Interfaces;

    public class ObjectiveService : IObjectiveService
    {
        private readonly IUnitOfWork unitOfWork;

        public ObjectiveService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public List<Objective> Get(Expression<Func<Objective, bool>> whereClause)
        {
            return unitOfWork.ObjectiveRepository.Get(whereClause).ToList();
        }

        public IEnumerable<Objective> GetObjectivesInRange(DateTime start, DateTime end)
        {
            var objectiveIds = unitOfWork.AnswerRepository
                .Get(a => a.SubmitDateTime >= start && a.SubmitDateTime <= end)
                .Select(a => a.Exercise.Objective.Id).Distinct();

            return unitOfWork.ObjectiveRepository.Get(o => objectiveIds.Contains(o.Id)).ToList();
        }
    }
}
