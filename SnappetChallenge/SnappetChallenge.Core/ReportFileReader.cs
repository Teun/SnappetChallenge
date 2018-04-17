namespace SnappetChallenge.Core
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using EFGetStarted.AspNetCore.NewDb.Models;
    using Newtonsoft.Json;

    /// <summary>
    /// Class for reading and adding records to DB
    /// </summary>
    public class ReportFileReader
    {
        /// <summary>
        /// The report database layer
        /// </summary>
        private readonly IReportDatabaseLayer reportDatabaseLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportFileReader"/> class.
        /// </summary>
        public ReportFileReader()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportFileReader"/> class.
        /// </summary>
        /// <param name="_reportDatabaseLayer">The report database layer.</param>
        public ReportFileReader(IReportDatabaseLayer databaseLayer)
        {
            this.reportDatabaseLayer = databaseLayer;
        }

        /// <summary>
        /// Reads the big json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonDataPath">The json data path.</param>
        /// <returns>Task result</returns>
        public async Task ReadBigJson<T>(string jsonDataPath = FileReaderConstants.JsonDataPath)
        {
            var desList = new List<ReportItem>();

            using (FileStream s = File.Open(jsonDataPath, FileMode.Open))
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                while (await reader.ReadAsync())
                {
                    await this.CheckAndAddReport<T>(desList, reader);
                }

                if (desList.Count > 0)
                {
                    await this.SafeAddReport(desList);
                }
            }
        }

        /// <summary>
        /// Checks the and add report.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="desList">The DES list.</param>
        /// <param name="reader">The reader.</param>
        /// <returns>Task result</returns>
        private async Task CheckAndAddReport<T>(List<ReportItem> desList, JsonReader reader)
        {
            var serializer = new JsonSerializer();
            if (reader.TokenType == JsonToken.StartObject)
            {
                var o = serializer.Deserialize<T>(reader);
                desList.Add(o as ReportItem);
                if (desList.Count == FileReaderConstants.SerializeNumber)
                {
                    await this.SafeAddReport(desList);
                    desList.Clear();
                }
            }
        }

        /// <summary>
        /// Safes the add report.
        /// </summary>
        /// <param name="desList">The DES list.</param>
        /// <returns>Task result</returns>
        private async Task SafeAddReport(List<ReportItem> desList)
        {
            if (this.reportDatabaseLayer != null)
            {
                await this.reportDatabaseLayer.AddClassReportItem(desList);
            }
            else
            {
                using (var reportDatabaseLayer = new ReportDatabaseLayer())
                {
                    await reportDatabaseLayer.AddClassReportItem(desList);
                }
            }
        }
    }
}
