using System.Linq;
using BlCore.DataProviders;

namespace Database.DataProviders.Csv
{
    public abstract class CsvRepositoryBase<T> : IRepository<T>
    {
        protected readonly string _filePath;

        protected CsvRepositoryBase(string filePath)
        {
            _filePath = filePath;
        }

        public abstract IQueryable<T> Get();
    }
}