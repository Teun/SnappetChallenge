using System;
using System.Data;
using System.Linq;

namespace SchoolMaster.Database.Repositories
{
    public class BaseRepository
    {
        protected WorkDbContext DbContext { get; }

        public BaseRepository(WorkDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}