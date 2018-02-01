namespace SnappetChallenge
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    using CsvHelper.Configuration;

    using SnappetChallenge.Models;
    using SnappetChallenge.Models.Interfaces;

    public class CsvReader : ICsvReader
    {
        internal sealed class MockDataMap : ClassMap<ClassAssignment>
        {
            public MockDataMap()
            {
                Map(m => m.SubmittedAnswerId).Name("SubmittedAnswerId");
                //2015-03-02T07:35:38.740
                Map(m => m.SubmitDateTime).ConvertUsing(x => DateTime.Parse(x.GetField<string>("SubmitDateTime"), null, DateTimeStyles.AssumeUniversal));
                //Map(m => m.SubmitDateTime).Name("SubmitDateTime");
                Map(m => m.Correct).ConvertUsing(x => String.CompareOrdinal((x.GetField("Correct") ?? String.Empty).Trim(), "1") == 0);
                Map(m => m.Progress).Name("Progress");
                Map(m => m.UserId).Name("UserId");
                Map(m => m.ExerciseId).Name("ExerciseId");
                Map(m => m.Difficulty).ConvertUsing(
                    x =>
                        {
                            Decimal.TryParse(x.GetField("Difficulty"), out decimal value);
                            return value;
                        });
                Map(m => m.Subject).Name("Subject");
                Map(m => m.Domain).Name("Domain");
                Map(m => m.LearningObjective).Name("LearningObjective");
            }
        }

        public List<ClassAssignment> ReadFile(string filePath)
        {
            List<ClassAssignment> classAssignments;
            using (var csvReader = new CsvHelper.CsvReader(new StreamReader(filePath), new Configuration() { IgnoreBlankLines = true, HasHeaderRecord = true, }))
            {
                csvReader.Configuration.RegisterClassMap<MockDataMap>();
                classAssignments = csvReader.GetRecords<ClassAssignment>().ToList();
            }
            return classAssignments;
        }
    }
}