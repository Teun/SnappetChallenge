using BlCore.DataProviders;
using BlCore.DataProviders.Models;

namespace Database.DataProviders.Csv
{
    public class CsvDataProvider : IDataProvider
    {
        public IRepository<ExerciseExecutionEntity> Executions { get; }

        public CsvDataProvider(string filePath)
        {
            Executions = new CsvExerciseExecutionRepository(filePath);
        }
    }
}