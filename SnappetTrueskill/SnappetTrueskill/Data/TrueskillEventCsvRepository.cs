using System.Collections.Generic;
using System.IO;
using CsvHelper;
using SnappetTrueskill.Domain;

namespace SnappetTrueskill.Data
{
    public class TrueskillEventCsvRepository : ITrueskillEventRepository
    {
        private List<TrueskillEvent> _events = new List<TrueskillEvent>();
        private string _filename;

        public TrueskillEventCsvRepository(string filename)
        {
            _filename = filename;
        }

        public void Add(TrueskillEvent trueskillEvent)
        {
            _events.Add(trueskillEvent);
        }

        public void Save()
        {
            using (var writer = new StreamWriter(_filename))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(_events);
            }
        }
    }
}
