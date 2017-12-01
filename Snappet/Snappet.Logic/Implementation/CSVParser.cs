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

        IDictionary<int, IEnumerable<Record>> _studentRecords;
        public IDictionary<int, IEnumerable<Record>> Parse(string path)
        {
            lock (this)
            {
                if (_studentRecords == null)
                {
                    List<Record> records = new List<Record>();
                    string[] lines = File.ReadAllLines(path);
                    for (int i = 1; i < lines.Length; i++)
                    {
                        records.Add(ParseLine(lines[i]));
                    }

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
        private Record ParseLine(string line)
        {
            var values = line.Split(',');
            //Console.WriteLine(line);
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
