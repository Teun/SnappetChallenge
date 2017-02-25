namespace Persistence {
	using System.Collections.Generic;
	using System.Linq;
	using Microsoft.EntityFrameworkCore;

	public abstract class Repository<TEntity>
		where TEntity: class
	{
		public Repository(DbSet<TEntity> set)
		{
			Set = set;
		}
		public DbSet<TEntity> Set { get; }

		public IEnumerable<TEntity> GetAll()
		{
			return GetAllEntities();
		}

		public void Add(TEntity entity)
		{
			Set.Add(entity);
		}

		public TEntity Find(params object[] keyValues)
		{
			return Set.Find(keyValues);
		}

		public void Remove(TEntity entity)
		{
			Set.Remove(entity);
		}

		public int Count(Query<TEntity> query)
		{
			IQueryable<TEntity> result = ApplyQuery(query, GetAllEntities());
			int count = result.Count();
			return count;
		}

		public IEnumerable<TEntity> Get(Query<TEntity> query)
		{
			IEnumerable<TEntity> result = ApplyQuery(query, GetAllEntities());
			return result;
		}

		public TEntity GetOne(Query<TEntity> query)
		{
			IQueryable<TEntity> result = ApplyQuery(query, GetAllEntities());
			return result.FirstOrDefault();
		}

		protected virtual IQueryable<TEntity> GetAllEntities()
		{
			return Set;
		}

		private static IQueryable<TEntity> ApplyQuery(
			Query<TEntity> query,
			IQueryable<TEntity> entities)
		{
			IQueryable<TEntity> set = entities;

			// TODO: Apply query.Includes using DbExtensions.Include.
			set = query.Specifications.Aggregate(
				set,
				(current, specification) => current.Where(specification.Predicate));

			// TODO: Apply query.SortDefinitions.
			// TODO: Apply query.Paging.

			return set;
		}
	}
}