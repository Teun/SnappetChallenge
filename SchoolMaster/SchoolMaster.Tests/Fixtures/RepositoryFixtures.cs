using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolMaster.Database;
using SchoolMaster.Database.Repositories;
using Xunit;

namespace SchoolMaster.Tests.Fixtures
{
    public class RepositoryFixtures
    {
        private WorkDbContext _workDbContext;
        public IWorkRepository WorkRepository { get; private set; }

        public RepositoryFixtures()
        {
            Setup();
        }

        private void Setup()
        {
            _workDbContext = (new WorkDbContextFixture()).DbContext;
            WorkRepository = new WorkRepository(_workDbContext);
        }
    }
}
