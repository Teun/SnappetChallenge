namespace SchoolMaster.Database.Repositories
{
    public class BaseRepository
    {
        public BaseRepository(WorkDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected WorkDbContext DbContext { get; }
    }
}