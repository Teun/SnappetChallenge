using System.Collections.Generic;

namespace Snappet.TestData.Builders
{
    internal interface IEntityBuilder
    {

    }

    internal abstract class EntityBuilder<TDataRecord, TEntity> where TEntity : new()
    {
        public abstract IList<TEntity> BuildEntities(IEnumerable<TDataRecord> records);
    }
}
