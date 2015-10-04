using Snappet.DataAccess;
using Snappet.Domain.Contracts;

namespace Snappet.Domain.Mappers
{
    public interface IRelatedDataMapper
    {
        Contracts.Domain Map(DomainEntity entity);
        Subject Map(SubjectEntity entity);
        LearningObjective Map(LearningObjectiveEntity entity);
    }

    public class RelatedDataMapper: IRelatedDataMapper
    {
        public Contracts.Domain Map(DomainEntity entity)
        {
            return new Contracts.Domain()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Subject Map(SubjectEntity entity)
        {
            return new Subject()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public LearningObjective Map(LearningObjectiveEntity entity)
        {
            return new Contracts.LearningObjective()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
