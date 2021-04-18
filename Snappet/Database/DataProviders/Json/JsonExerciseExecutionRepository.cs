using System.Collections.Generic;
using System.IO;
using System.Linq;
using BlCore.DataProviders.Models;
using Newtonsoft.Json;

namespace Database.DataProviders.Json
{
    public class JsonExerciseExecutionRepository : JsonRepositoryBase<ExerciseExecutionEntity>
    {
        public JsonExerciseExecutionRepository(string filePath) : base(filePath)
        {

        }

        public override IQueryable<ExerciseExecutionEntity> Get()
        {
            List<ExerciseExecutionEntity> data = ReadData(_filePath);
            return data.AsQueryable();
        }

        private List<ExerciseExecutionEntity> ReadData(string filePath)
        {
            var data = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<ExerciseExecutionEntity>>(data);
        }
    }
}