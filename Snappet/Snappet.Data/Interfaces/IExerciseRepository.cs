using System;
using System.Collections.Generic;

namespace Snappet.Data.Interfaces
{
    public interface IExerciseRepository
    {
        IFrom<TEntity> Get<TEntity>() where TEntity : new();
    }

    public interface IFrom<TEntity> : IListable<TEntity>
    {
        ITo<TEntity> From(DateTime from);
    }

    public interface ITo<TEntity> : IListable<TEntity>
    {
        IListable<TEntity> To(DateTime to);
    }

    public interface IListable<TEntity>
    {
        IList<TEntity> ToList();
    }
}
