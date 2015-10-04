using System.Collections.Generic;
using System.Linq;


namespace Snappet.DataAccess
{
    public interface IDomainRepository
    {
        void Save(List<string> domains );
        IEnumerable<DomainEntity> GetAll();
        void DeleteAll();
    }

    public class DomainRepository: BaseRepository<DomainEntity>, IDomainRepository
    {
        public DomainRepository(SnappetContext dbContext) : base(dbContext)
        {
        }
        public void Save(List<string> domains)
        {
            var entities = domains.Select(x => new DomainEntity() { Name = x });
            base.Add(entities.ToList());
            base.Save();
        }

        public IEnumerable<DomainEntity> GetAll()
        {
            return base.GetAll();
        }
        public void DeleteAll()
        {
            base.DeleteAll("Domain");
        }
    }
}
