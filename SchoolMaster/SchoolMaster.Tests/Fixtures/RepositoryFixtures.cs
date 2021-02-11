using SchoolMaster.Database;
using SchoolMaster.Database.Repositories;

namespace SchoolMaster.Tests.Fixtures
{
    public class RepositoryFixtures
    {
        private WorkDbContext _workDbContext;

        public RepositoryFixtures()
        {
            Setup();
        }

        public IWorkRepository WorkRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        private void Setup()
        {
            _workDbContext = new WorkDbContextFixture().DbContext;
            WorkRepository = new WorkRepository(_workDbContext);
            UserRepository = new UserRepository(_workDbContext);
        }
    }
}