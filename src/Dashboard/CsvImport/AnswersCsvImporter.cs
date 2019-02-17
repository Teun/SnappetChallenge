using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Dashboard.Domain;

namespace Dashboard.CsvImport
{
    public class AnswersCsvImporter
    {
        public IEnumerable<Answer> Import(string fileName)
        {
            var fieldMap = new AnswerCsvFieldMap();

            using (var streamReader = new StreamReader(fileName))
            {
                // skip headers
                streamReader.ReadLine();

                for (; ;)
                {
                    string line = streamReader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    if (line[0] == '%')
                    {
                        continue;
                    }

                    string[] fields = line.Split(',');

                    var answer = new Answer();

                    answer.SubmittedAnswerId = int.Parse(fields[fieldMap.SubmittedAnswerId]);
                    answer.SubmitDateTime = DateTimeOffset.Parse(fields[fieldMap.SubmitDateTime], null, DateTimeStyles.AssumeUniversal);
                    answer.IsCorrect = int.Parse(fields[fieldMap.IsCorrect]) == 1;
                    answer.Progress = int.Parse(fields[fieldMap.Progress]);
                    answer.UserId = int.Parse(fields[fieldMap.UserId]);
                    answer.ExerciseId = int.Parse(fields[fieldMap.ExerciseId]);
                    answer.Difficulty = (fields[fieldMap.Difficulty] != "NULL") ?
                        float.Parse(fields[fieldMap.Difficulty])
                        : (float?)null;
                    answer.Subject = fields[fieldMap.Subject];
                    answer.Domain = fields[fieldMap.Domain];
                    answer.LearningObjective = fields[fieldMap.LearningObjective];

                    yield return answer;
                }
            }
        }
    }
}
