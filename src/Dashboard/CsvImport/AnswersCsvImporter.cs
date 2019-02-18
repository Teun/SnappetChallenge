using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using Dashboard.Domain;

namespace Dashboard.CsvImport
{
    public class AnswersCsvImporter : IDisposable
    {
        private readonly StreamReader _streamReader;

        private readonly CsvReader _csv;

        public AnswersCsvImporter(string fileName)
        {
            _streamReader = new StreamReader(fileName, new UTF7Encoding());
            _csv = new CsvReader(_streamReader);
        }

        public IEnumerable<Answer> Import()
        {
            var rows = _csv.GetRecords<AnswerCsvRow>();

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

            return answers;
        }

        public void Dispose()
        {
            _csv?.Dispose();
            _streamReader?.Dispose();
        }
    }
}
