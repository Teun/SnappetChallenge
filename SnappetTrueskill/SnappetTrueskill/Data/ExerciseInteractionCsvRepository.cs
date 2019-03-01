using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SnappetTrueskill.Data
{
    public class ExerciseInteractionCsvRepository : IExerciseInteractionRepository
    {
        private readonly List<ExerciseInteraction> _exerciseInteractions;

        public ExerciseInteractionCsvRepository(string filename)
        {
            // Read from local CSV file
            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader))
            {
                _exerciseInteractions = csv.GetRecords<ExerciseInteraction>().ToList();
            }

            Console.WriteLine("Read " + _exerciseInteractions.Count + " records");
        }

        public IEnumerable<ExerciseInteraction> GetAll()
        {
            return _exerciseInteractions;
        }

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
