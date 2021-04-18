using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BlCore.DataProviders.Models;

namespace Database.DataProviders.Csv
{
    public class CsvExerciseExecutionRepository : CsvRepositoryBase<ExerciseExecutionEntity>
    {
        public CsvExerciseExecutionRepository(string filePath) : base(filePath)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public override IQueryable<ExerciseExecutionEntity> Get()
        {
            List<ExerciseExecutionEntity> data = ReadData(_filePath);
            return data.AsQueryable();
        }

        private List<ExerciseExecutionEntity> ReadData(string filePath)
        {
            var result = new List<ExerciseExecutionEntity>();
            using (var reader = new StreamReader(filePath, Encoding.GetEncoding("windows-1251"), true))
            {
                reader.ReadLine(); // Skip headers
                while (!reader.EndOfStream)
                {
                    var row = reader.ReadLine();
                    var values = row.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    var item = new ExerciseExecutionEntity
                    {
                        SubmittedAnswerId = int.Parse(values[0]),
                        SubmitDateTime = DateTime.Parse(values[1]),
                        Correct = int.Parse(values[2]),
                        Progress = int.Parse(values[3]),
                        UserId = int.Parse(values[4]),
                        ExerciseId = int.Parse(values[5]),
                        Difficulty = values[6],
                        Subject = values[7],
                        Domain = values[8],
                        LearningObjective = values[9]
                    };
                    result.Add(item);
                }
            }
            return result;
        }


    }
}