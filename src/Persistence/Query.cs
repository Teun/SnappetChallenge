namespace Persistence
{
	using System;
	using Domain.Specifications;
	using System.Collections.Generic;
	using System.Linq.Expressions;
	public class Query<TEntity> where TEntity : class
	{
		private readonly List<Specification<TEntity>> _specifications;

		private readonly List<SortDefinition> _sortDefinitions;

		private readonly List<LambdaExpression> _includes;

		// private PageDefinition _paging;

		public Query()
		{
			_specifications = new List<Specification<TEntity>>();
			_sortDefinitions = new List<SortDefinition>();
			_includes = new List<LambdaExpression>();
		}

		public IEnumerable<Specification<TEntity>> Specifications
		{
			get
			{
				return _specifications;
			}
		}

		public IEnumerable<SortDefinition> SortDefinitions
		{
			get
			{
				return _sortDefinitions;
			}
		}

		//public PageDefinition Paging
		//{
		//	get
		//	{
		//		return _paging;
		//	}
		//}

		public IEnumerable<LambdaExpression> Includes
		{
			get
			{
				return _includes;
			}
		}

		public Query<TEntity> Filter(Specification<TEntity> specification)
		{
			_specifications.Add(specification);
			return this;
		}
		/*
		public Query<TEntity> WithPaging(int pageNumber, int pageSize)
		{
			Contract.Ensures(Contract.Result<Query<TEntity>>() != null);

			_paging = new PageDefinition
			{
				PageNumber = pageNumber,
				PageSize = pageSize
			};
			return this;
		}

		*/

		public Query<TEntity> WithSorting<TProperty>(
			Expression<Func<TEntity, TProperty>> sortExpression,
			SortDirection direction)
		{
			_sortDefinitions.Add(
				new SortDefinition
				{
					Expression = sortExpression,
					Direction = direction
				});
			return this;
		}

		public Query<TEntity> SortAscending<TProperty>(
			Expression<Func<TEntity, TProperty>> sortExpression)
		{
			return WithSorting(sortExpression, SortDirection.Ascending);
		}

		public Query<TEntity> SortDescending<TProperty>(
			Expression<Func<TEntity, TProperty>> sortExpression)
		{
			return WithSorting(sortExpression, SortDirection.Descending);
		}

		public Query<TEntity> Include<TProperty>(
			Expression<Func<TEntity, TProperty>> path)
		{
			_includes.Add(path);
			return this;
		}
	}
}