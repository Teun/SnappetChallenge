using System.Collections.Generic;
using System.Linq;

namespace Snappet.DataAccess
{
    public interface ISubjectRepository
    {
        void Save(List<string> subjects );
        IEnumerable<SubjectEntity> GetAll();
        void DeleteAll();
    }

    public class SubjectRepository: BaseRepository<SubjectEntity>,ISubjectRepository
    {
        public SubjectRepository(SnappetContext dbContext) : base(dbContext)
        {
        }

        public void Save(List<string> subjects)
        {
            var entities = subjects.Select(x => new SubjectEntity() {Name = x});
            base.Add(entities.ToList());
            base.Save();
        }

        public IEnumerable<SubjectEntity> GetAll()
        {
            return base.GetAll();
        }

        public void DeleteAll()
        {
            base.DeleteAll("Subject");
        }
    }
}
