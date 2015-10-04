using Snappet.DataAccess;
using Snappet.Domain.Contracts;

namespace Snappet.Domain.Mappers
{

    public interface IExerciseResultMapper{
        ExerciseResult Map(ExerciseResultEntity entity);
        ExerciseResultEntity Map(ExerciseResult entity);

    }
    public class ExerciseResultMapper : IExerciseResultMapper
    {
        public ExerciseResultEntity Map(ExerciseResult domain)
        {
            return new ExerciseResultEntity()
            {
                Difficulty = domain.Difficulty.GetValueOrDefault(),
                DomainId = domain.DomainId,
                ExerciseId = domain.ExerciseId,
                IsCorrect = domain.Correct,
                LearningObjectiveId = domain.LearningObjectiveId,
                SubjectId = domain.SubjectId,
                SubmitDateTime = domain.SubmitDateTime,
                SubmittedAnswerId = domain.SubmittedAnswerId,
                Progress = domain.Progress,
                UserId = domain.UserId
                
            };
        }

        public ExerciseResult Map(ExerciseResultEntity entity)
        {
            return new ExerciseResult() {
                Id = entity.Id,
                Difficulty = entity.Difficulty,
                Domain = entity.Domain.Name,
                ExerciseId = entity.ExerciseId,
                Correct = entity.IsCorrect,
                LearningObjective = entity.LearningObjective.Name,
                Subject = entity.Subject.Name,
                SubmitDateTime = entity.SubmitDateTime,
                SubmittedAnswerId = entity.SubmittedAnswerId,
                UserId = entity.UserId,
                SubjectId = entity.SubjectId,
                LearningObjectiveId = entity.LearningObjectiveId,
                Progress = entity.Progress
            };
        }
    }
}
