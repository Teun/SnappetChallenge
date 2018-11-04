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
        private static bool IsInitialized = false;
        private static List<ExerciseResult> _database;

        public DatabaseContext()
        {
            if (!IsInitialized)
            {
                InitializeDbContext();
                IsInitialized = true;
            }
        }
        private void InitializeDbContext()
        {
            try
            {
                if (File.Exists(ServiceSettings.DataPath))
                {
                    var fileContent = File.ReadAllText(ServiceSettings.DataPath);
                    _database = JsonConvert.DeserializeObject<List<ExerciseResult>>(fileContent);
                }
                else
                {
                    throw new Exception(string.Format("DataFile is not found at {0}", ServiceSettings.DataPath));
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
