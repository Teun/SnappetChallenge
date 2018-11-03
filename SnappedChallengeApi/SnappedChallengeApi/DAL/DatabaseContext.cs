using Newtonsoft.Json;
using SnappedChallengeApi.Models.Bussiness;
using SnappedChallengeApi.Models.Commons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SnappedChallengeApi.DAL
{
    public class DatabaseContext
    {
        private static List<ExerciseResult> _database;

        public static void InitializeDbContext(ServiceSettings settings)
        {
            try
            {
                if (File.Exists(settings.DataPath))
                {
                    var fileContent = File.ReadAllText(settings.DataPath);
                    _database = JsonConvert.DeserializeObject<List<ExerciseResult>>(fileContent);
                }
                else
                {
                    throw new Exception(string.Format("DataFile is not found at {0}", settings.DataPath));
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<ExerciseResult> GetExerciseResults(int offset, int limit)
        {
            return _database.Skip(offset).Take(limit).ToList();
        }
    }
}
