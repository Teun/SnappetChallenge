using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using Dashboard.Domain;

namespace Dashboard.CsvImport
{
    public class AnswersCsvImporter
    {
        public IReadOnlyCollection<Answer> Import(string fileName)
        {
            using (var streamReader = new StreamReader(fileName, new UTF7Encoding()))
            using (var csv = new CsvReader(streamReader))
            {
                var rows = csv.GetRecords<AnswerCsvRow>();

                var answers = rows.Select(row => new Answer(
                    submittedAnswerId: row.SubmittedAnswerId,
                    submitDateTime: row.SubmitDateTime,
                    isCorrect: row.Correct,
                    progress: row.Progress,
                    userId: row.UserId,
                    exerciseId: row.ExerciseId,
                    difficulty: row.Difficulty,
                    subject: row.Subject,
                    domain: row.Domain,
                    learningObjective: row.LearningObjective
                    )
                );

                return answers.ToList();
            }
        }
    }
}
