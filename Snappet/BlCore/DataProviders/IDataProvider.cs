using BlCore.DataProviders.Models;

namespace BlCore.DataProviders
{
    public interface IDataProvider
    {
        IRepository<ExerciseExecutionEntity> Executions { get;  }
    }
}
