using CsvHelper;
using System.Globalization;
using System.IO;

namespace SnappetChallenge.Services
{
    public class CSVReader<T> : ICSVReader<T>
    {
        public async Task<IEnumerable<T>> ReadCSV(string filePath)
        {
            var output = new List<T>();
            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
                {
                    var records = csvReader.GetRecordsAsync<T>();
                    await foreach (var row in records)
                    {
                        if (row != null)
                        {
                            output.Add(row);
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

            return output;
        }
    }
}