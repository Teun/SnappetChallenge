
using System.Collections.Generic;
using System.Linq;

namespace Snappet.DataAccess
{
    public interface ILearningObjectiveRepository
    {
        void Save(List<string> learnings);
        IEnumerable<LearningObjectiveEntity> GetAll();
        void DeleteAll();
    }

    public class LearningObjectiveRepository: BaseRepository<LearningObjectiveEntity>, ILearningObjectiveRepository
    {
        public LearningObjectiveRepository(SnappetContext dbContext) : base(dbContext)
        {
        }
        public void Save(List<string> learnings)
        {
            var entities = learnings.Select(x => new LearningObjectiveEntity() { Name = x });
            base.Add(entities.ToList());
            base.Save();
        }

        public IEnumerable<LearningObjectiveEntity> GetAll()
        {
            return base.GetAll();
        }
        public void DeleteAll()
        {
            base.DeleteAll("LearningObjective");
        }

    }
}
