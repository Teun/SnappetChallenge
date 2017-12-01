using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Snappet.Logic
{
    public class CSVParser : IParser
    {
        //singeleton
        static CSVParser()
        {
            _instance = new CSVParser();
        }
        private static CSVParser _instance;
        private CSVParser()
        {

        }

        public static CSVParser Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// for Caching the records
        /// </summary>
        IDictionary<int, IEnumerable<Record>> _studentRecords;
        /// <summary>
        /// Parses the data file then caches the recors
        /// </summary>
        /// <param name="path"></param>
        /// <returns>A dictionary, where the key is the student ID and the value is the student's records.</returns>
        public IDictionary<int, IEnumerable<Record>> Parse(string path)
        {
            lock (this)
            {
                if (_studentRecords == null)
                {
                    List<Record> records = new List<Record>();
                    //reads all the lines into memory
                    string[] lines = File.ReadAllLines(path);
                    //go through the lines and convert them into Records
                    for (int i = 1; i < lines.Length; i++)
                    {
                        records.Add(ParseLine(lines[i]));
                    }
                    //groups the records of each student into a dictionary
                    _studentRecords = new Dictionary<int, IEnumerable<Record>>();
                    foreach (var item in records.OrderBy(r => r.UserId))
                    {
                        if (_studentRecords.ContainsKey(item.UserId))
                        {
                            var studentRecords = _studentRecords[item.UserId];
                            (studentRecords as List<Record>).Add(item);
                        }
                        else
                        {
                            _studentRecords.Add(item.UserId, new List<Record>() { item });
                        }
                    }
                }
                return _studentRecords;
            }
        }
        /// <summary>
        /// Parses a data line
        /// </summary>
        /// <param name="line">CSV data line</param>
        /// <returns>Student record object</returns>
        private Record ParseLine(string line)
        {
            var values = line.Split(',');
            return new Record()
            {
                SubmittedAnswerId = int.Parse(values[0]),
                SubmitDateTime = DateTime.Parse(values[1]),
                Correct = values[2] == "1",
                Progress = int.Parse(values[3]),
                UserId = int.Parse(values[4]),
                ExerciseId = int.Parse(values[5]),
                Difficulty = values[6] == "NULL" ? 0 : decimal.Parse(values[6]),
                Subject = values[7],
                Domain = values[8],
                LearningObjective = values[9],
            };
        }
    }
}
