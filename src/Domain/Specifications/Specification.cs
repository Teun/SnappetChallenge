using System;
using System.Linq.Expressions;

namespace Domain.Specifications
{
    public abstract class Specification<TEntity>
	{
		public abstract Expression<Func<TEntity, bool>> Predicate
		{
			get;
		}

		public virtual string Name => this.GetType().Name;
	}
}