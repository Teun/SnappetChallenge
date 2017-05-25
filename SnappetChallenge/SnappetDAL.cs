using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Linq;

namespace SnappetChallenge
{
    public class SnappetDAL
    {
        private static DataTable _dtWork = new DataTable();

        public static void LoadCSVDataTable()
        {
            //get csv file location
            string csvFile = @"c:\temp\work.csv";

            //open file and convert to datatable
            TextReader reader = File.OpenText(csvFile);
            var csv = new CsvReader(reader);

            _dtWork = new DataTable();
            _dtWork.Columns.Add("SubmittedAnswerId", typeof(int));
            _dtWork.Columns.Add("SubmitDateTime", typeof(DateTime));
            _dtWork.Columns.Add("Correct");
            _dtWork.Columns.Add("Progress", typeof(int));
            _dtWork.Columns.Add("UserId");
            _dtWork.Columns.Add("ExerciseId");
            _dtWork.Columns.Add("Difficulty");
            _dtWork.Columns.Add("Subject");
            _dtWork.Columns.Add("Domain");
            _dtWork.Columns.Add("LearningObjective");

            while (csv.Read())
            {
                var row = _dtWork.NewRow();
                foreach (DataColumn column in _dtWork.Columns)
                {
                    row[column.ColumnName] = csv.GetField(column.DataType, column.ColumnName);
                }
                _dtWork.Rows.Add(row);
            }
        }

        public static Answer GetAnswer(int answerID)
        {
            //load Datatable if needed
            if (_dtWork.Rows.Count == 0) LoadCSVDataTable();

            //get correct row
            DataRow dr = _dtWork.AsEnumerable()
                .SingleOrDefault(r => r.Field<int>("SubmittedAnswerId") == answerID);

            Answer answer = null;

            answer = new Answer
            {
                SubmittedAnswerId = int.Parse(dr["SubmittedAnswerId"].ToString()),
                SubmitDateTime = DateTime.Parse(dr["SubmitDateTime"].ToString()),
                Correct = null,
                Progress = null,
                UserId = null,
                ExerciseId = null,
                Difficulty = null,
                Subject = null,
                Domain = null,
                LearningObjective = null
            };

            return answer;
        }

        public static List<Answer> GetDomainAnswersForDateTime(string UserID, string Domain, DateTime CurrentDate)
        {
            //load Datatable if needed
            if (_dtWork.Rows.Count == 0) LoadCSVDataTable();

            //filter correct rows
            DateTime startDate = new DateTime(CurrentDate.Year, CurrentDate.Month, CurrentDate.Day, 0, 0, 0);
            string filter = "UserID = '"+ UserID + "' AND Domain = '" + Domain + "' AND SubmitDateTime >= '" + startDate + "' AND SubmitDateTime <= '" + CurrentDate + "'";
            DataView dvFilteredSorted = _dtWork.DefaultView;
            dvFilteredSorted.RowFilter = filter;

            //sort by UserId, SubmitDateTime
            dvFilteredSorted.Sort = "UserId, SubmitDateTime";

            DataRow[] rows = dvFilteredSorted.ToTable().Select();

            //create List of answers
            List<Answer> answers = new List<Answer>();

            foreach(DataRow row in rows)
            {
                Answer answer = new Answer
                {
                    SubmittedAnswerId = int.Parse(row["SubmittedAnswerId"].ToString()),
                    SubmitDateTime = DateTime.Parse(row["SubmitDateTime"].ToString()),
                    Correct = row["Correct"].ToString(),
                    Progress = row["Progress"].ToString(),
                    UserId = row["UserId"].ToString(),
                    ExerciseId = row["ExerciseId"].ToString(),
                    Difficulty = row["Difficulty"].ToString(),
                    Subject = row["Subject"].ToString(),
                    Domain = row["Domain"].ToString(),
                    LearningObjective = row["LearningObjective"].ToString(),
                };
                answers.Add(answer);
            }
            
            return answers;
        }

        public static List<ProgressOverView> GetProgressOverViewDate(DateTime CurrentDate)
        {
            //load Datatable if needed
            if (_dtWork.Rows.Count == 0) LoadCSVDataTable();

            //filter correct rows
            DateTime startDate = new DateTime(CurrentDate.Year, CurrentDate.Month, CurrentDate.Day, 0, 0, 0);
            string filter = "SubmitDateTime >= '" + startDate + "' AND SubmitDateTime <= '" + CurrentDate + "'";
            DataView dvFilteredSorted = _dtWork.DefaultView;
            dvFilteredSorted.RowFilter = filter;

            //sort by UserId, SubmitDateTime
            dvFilteredSorted.Sort = "UserId, SubmitDateTime";

            DataTable dt = dvFilteredSorted.ToTable();

            //group datatable by userid/domain to get to total progress per domain 
            var result = from t in dt.AsEnumerable()
                         group t by new {UserId = t.Field<string>("UserId"), Domain = t.Field<string>("Domain")}
                         into tTotals
                         select new
                         {
                             UserId = tTotals.Key.UserId,
                             Domain = tTotals.Key.Domain,
                             TotalProgress = tTotals.Sum(r => r.Field<int>("Progress"))
                         };

            //create List of answers
            List<ProgressOverView> progoverview = new List<ProgressOverView>();

            foreach (var row in result)
            {
                ProgressOverView prog = new ProgressOverView
                {
                    UserId = row.UserId,
                    Domain = row.Domain,
                    TotalProgress = row.TotalProgress
                };
                progoverview.Add(prog);
            }

            return progoverview;
        }
    }
}