using SnappetReports.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Data.SqlClient;

namespace SnappetReports.Data
{
    public static class ReportData
    {
        public static string workdata = "";
        static List<ReportRecord> reportRecords = LoadData();

        //private static string datafile = Path.GetFullPath("work.json");        
        //public static string workdata = File.ReadAllText(datafile);
        //static List<ReportRecord> reportRecords =  JsonConvert.DeserializeObject<List<ReportRecord>>(workdata);

        public static List<ReportRecord> workRecords = reportRecords;


        //Use DataLoadScript.sql script to load the data into SQL Server
        private static List<ReportRecord> LoadData()
        {
            var reportsRecordData = new List<ReportRecord>();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            SqlConnection sqlConnection = new SqlConnection("Data Source=[SQL_DATABASE];Initial Catalog=[DB_NAME];Integrated Security=True;;  UID=[USERNAME]; PWD=PASSWORD");
            sqlConnection.Open();

            String sql = "SELECT * FROM [TABLE_NAME]";

            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reportsRecordData.Add(new ReportRecord
                        {
                            SubmittedAnswerId = Convert.ToInt32(reader["SubmittedAnswerId"]),
                            SubmitDateTime = Convert.ToDateTime(reader["SubmitDateTime"]),
                            Correct = Convert.ToInt32(reader["Correct"]),
                            Progress = Convert.ToInt32(reader["Progress"]),
                            UserId = Convert.ToInt32(reader["UserId"]),
                            ExerciseId = Convert.ToInt32(reader["ExerciseId"]),
                            Difficulty = reader["Difficulty"].ToString(),
                            Subject = reader["Subject"].ToString(),
                            Domain = reader["Domain"].ToString(),
                            LearningObjective = reader["LearningObjective"].ToString()
                        });
                    }
                }
            }

            return reportsRecordData;
        }
    }
}
