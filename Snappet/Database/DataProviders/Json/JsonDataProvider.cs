using BlCore.DataProviders;
using BlCore.DataProviders.Models;

namespace Database.DataProviders.Json
{
    public class JsonDataProvider : IDataProvider
    {
        public IRepository<ExerciseExecutionEntity> Executions { get; }

        public JsonDataProvider(string filePath)
        {
            Executions = new JsonExerciseExecutionRepository(filePath);
        }
    }
}
