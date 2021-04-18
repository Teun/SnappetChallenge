using System.Linq;
using BlCore.DataProviders;

namespace Database.DataProviders.Json
{
    public abstract class JsonRepositoryBase<T> : IRepository<T>
    {
        protected readonly string _filePath;

        protected JsonRepositoryBase(string filePath)
        {
            _filePath = filePath;
        }

        public abstract IQueryable<T> Get();
    }
}