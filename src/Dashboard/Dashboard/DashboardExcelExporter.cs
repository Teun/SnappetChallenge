using System;
using System.Collections.Generic;
using System.Drawing;
using Dashboard.Dashboard.Models;
using OfficeOpenXml;

namespace Dashboard.Dashboard
{
    public class DashboardExcelExporter
    {
        public ExcelPackage Export(DashboardModel dashboard)
        {
            if (dashboard == null)
            {
                throw new ArgumentNullException(nameof(dashboard));
            }

            var excelPackage = new ExcelPackage();
            var worksheet = excelPackage.Workbook.Worksheets.Add("Class activity report");
            var row = new CurrentRow(worksheet, 1);

            AddReportHeader(dashboard, worksheet, row);

            AddTopicStatistics(dashboard.Topics, worksheet, row);

            row.Next();

            AddStudentsStatistics(dashboard.Students, worksheet, row);

            worksheet.Cells.AutoFitColumns();

            return excelPackage;
        }

        private void AddReportHeader(DashboardModel dashboard, ExcelWorksheet worksheet, CurrentRow row)
        {
            var headerStyle = worksheet.Workbook.Styles.CreateNamedStyle("Header");
            headerStyle.Style.Font.Bold = true;
            headerStyle.Style.Font.Size = 16;
            
            row.Cell(1).Value = "Class activity report";
            row.Cell(1).StyleName = headerStyle.Name;
            row.Next();
            row.Next();

            row.Cell(1).Value = "Start date";
            row.Cell(2).Value = dashboard.Start;
            row.Next();

            row.Cell(1).Value = "End date";
            row.Cell(2).Value = dashboard.End;
            row.Next();

            row.Cell(1).Value = "Students present";
            row.Cell(2).Value = dashboard.StudentsPresent;
            row.Next();
            row.Next();
        }

        private void AddTopicStatistics(IReadOnlyCollection<TopicModel> topics, ExcelWorksheet worksheet, CurrentRow row)
        {
            var tableHeaderStyle = worksheet.Workbook.Styles.CreateNamedStyle("Table header");
            tableHeaderStyle.Style.Font.Bold = true;
            tableHeaderStyle.Style.Font.Size = 14;

            row.Cell(1).Value = "Section";
            row.Cell(1).StyleName = tableHeaderStyle.Name;

            row.Cell(2).Value = "Exercise count";
            row.Cell(2).StyleName = tableHeaderStyle.Name;

            row.Cell(3).Value = "Correct answers, %";
            row.Cell(3).StyleName = tableHeaderStyle.Name;

            row.Cell(4).Value = "Students participated, %";
            row.Cell(4).StyleName = tableHeaderStyle.Name;

            row.Next();

            foreach (var topic in topics)
            {
                string name = topic.Level == DashboardModel.ROOT_TOPIC_LEVEL ? "Overall" : topic.TopicName;
                row.Cell(1).Value = name;
                row.Cell(1).Style.Font.Size = 16 - 2 * topic.Level;

                row.Cell(2).Value = topic.ExerciseCount;

                row.Cell(3).Value = topic.CorrectAnswersRate;
                row.Cell(3).Style.Numberformat.Format = "0%";

                row.Cell(4).Value = topic.StudentsShare;
                row.Cell(4).Style.Numberformat.Format = "0%";

                row.Next();
            }

            // highlight the low rate of correct answers
            var correctnessRateColumn = new ExcelAddress(row.Row - topics.Count, 3, row.Row, 3);
            var lowCorrectRateRule = worksheet.ConditionalFormatting.AddLessThan(correctnessRateColumn);
            lowCorrectRateRule.Formula = "0.7";
            lowCorrectRateRule.Style.Font.Color.Color = Color.Red;

            // highlight low rate of students who did the task
            var studentsRateColumn = new ExcelAddress(row.Row - topics.Count, 4, row.Row, 4);
            var lowRateRule = worksheet.ConditionalFormatting.AddLessThan(studentsRateColumn);
            lowRateRule.Formula = "0.5";
            lowRateRule.Style.Font.Color.Color = Color.Red;
        }

        private void AddStudentsStatistics(IReadOnlyCollection<StudentModel> students, ExcelWorksheet worksheet, CurrentRow row)
        {
            var tableHeaderStyle = worksheet.Workbook.Styles.CreateNamedStyle("Students table header");
            tableHeaderStyle.Style.Font.Bold = true;
            tableHeaderStyle.Style.Font.Size = 14;

            row.Cell(1).Value = "Students";
            row.Cell(1).StyleName = tableHeaderStyle.Name;
            row.Next();

            row.Cell(1).Value = "Name";
            row.Cell(1).StyleName = tableHeaderStyle.Name;

            row.Cell(2).Value = "Exercise count";
            row.Cell(2).StyleName = tableHeaderStyle.Name;

            row.Cell(3).Value = "Correct answers, %";
            row.Cell(3).StyleName = tableHeaderStyle.Name;

            row.Cell(4).Value = "Exercises covered, %";
            row.Cell(4).StyleName = tableHeaderStyle.Name;

            row.Next();

            foreach (StudentModel student in students)
            {
                row.Cell(1).Value = student.Name;

                row.Cell(2).Value = student.ExerciseCount;

                row.Cell(3).Value = student.CorrectAnswersRatio;
                row.Cell(3).Style.Numberformat.Format = "0%";

                row.Cell(4).Value = student.FinishedExerciseShare;
                row.Cell(4).Style.Numberformat.Format = "0%";

                row.Next();
            }

            // highlight the low rate of correct answers
            var correctnessRateColumn = new ExcelAddress(row.Row - students.Count, 3, row.Row, 3);
            var lowCorrectRateRule = worksheet.ConditionalFormatting.AddLessThan(correctnessRateColumn);
            lowCorrectRateRule.Formula = "0.7";
            lowCorrectRateRule.Style.Font.Color.Color = Color.Red;

            // highlight the low rate of exercises covered (logical, but the data suggest maybe not)
            var exerciseRateColumn = new ExcelAddress(row.Row - students.Count, 4, row.Row, 4);
            var lowExerciseRateRule = worksheet.ConditionalFormatting.AddLessThan(exerciseRateColumn);
            lowExerciseRateRule.Formula = "0.4";
            lowExerciseRateRule.Style.Font.Color.Color = Color.Red;
        }

        private class CurrentRow
        {
            private readonly ExcelWorksheet _worksheet;

            public int Row { get; private set; }

            public CurrentRow(ExcelWorksheet worksheet, int row)
            {
                _worksheet = worksheet;
                Row = row;
            }

            public ExcelRange Cell(int column)
            {
                return _worksheet.Cells[Row, column];
            }

            public void Next()
            {
                ++Row;
            }
        }
    }
}
