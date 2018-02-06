using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Snappet.Assignment.Data.Configurations;
using Snappet.Assignment.Data.Interfaces;
using Snappet.Assignment.Entities.DomainObjects;
using Snappet.Assignment.Data.Extensions;

namespace Snappet.Assignment.Data.Context
{
    public class SchoolDbContext : DbContext,ISchoolDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Exercise> Exercises { get; set; }


        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("School");

            builder.ApplyConfiguration(new WorkConfiguration());

            builder.ApplyConfiguration(new UserConfiguration());

            builder.ApplyConfiguration(new ExerciseConfiguration());


        }

        public async Task<IQueryable<TEntity>> QueryAsync<TEntity>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class
        {

            return await Task.Run(() =>
            {

                return predicate != null ?
                                           Set<TEntity>().AsNoTracking().Where(predicate).IncludeMultiple(includeProperties) :
                                           Set<TEntity>().AsNoTracking().IncludeMultiple(includeProperties);
            });

        }
    }
}
