using System;
using System.Linq.Expressions;

namespace Domain.Specifications
{
    public class AdHocSpecification<TEntity> : Specification<TEntity>
	{
		public AdHocSpecification(
			Expression<Func<TEntity, bool>> predicate,
			string name)
		{
			Predicate = predicate;
			Name = name;
		}

		public override Expression<Func<TEntity, bool>> Predicate { get; }
		public override string Name { get; }
	}
}