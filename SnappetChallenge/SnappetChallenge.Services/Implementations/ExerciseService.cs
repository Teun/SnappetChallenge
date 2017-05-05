namespace SnappetChallenge.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repository;
    using Interfaces;
    
    public class ExerciseService : IExerciseService
    {
        private readonly IUnitOfWork unitOfWork;

        public ExerciseService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Exercise> GetExercisesByObjectiveInRange(long objectiveId, DateTime? start, DateTime end)
        {
            var exerciseIds = unitOfWork.AnswerRepository
                .Get(a => a.SubmitDateTime >= start && a.SubmitDateTime <= end && a.Exercise.ObjectiveId == objectiveId)
                .Select(a => a.Exercise.Id).Distinct();
            return unitOfWork.ExerciseRepository.Get(e => exerciseIds.Contains(e.Id)).ToList();
        }
    }
}
