using System.Collections.Generic;

namespace SnappetChallenge.Core.Interfaces
{
    public interface ICommands<T> where T : class
    {
        void BulkAdd(List<T> entitiesList);
        void ExecuteSqlCommand(string command);
    }
}