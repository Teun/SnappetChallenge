using System;
using System.Collections.Generic;
using System.Drawing;
using Dashboard.Dashboard.Models;
using OfficeOpenXml;

namespace Dashboard.Dashboard
{
    public class DashboardExcelPresenter
    {
        public ExcelPackage Present(Models.DashboardModel dashboard)
        {
            if (dashboard == null)
            {
                throw new ArgumentNullException(nameof(dashboard));
            }

            var excelPackage = new ExcelPackage();
            var worksheet = excelPackage.Workbook.Worksheets.Add("Class activity report");
            var row = new CurrentRow(worksheet, 1);

            AddReportHeader(dashboard, worksheet, row);

            AddSliceStatistics(dashboard.Topics, worksheet, row);

            worksheet.Cells.AutoFitColumns();

            return excelPackage;
        }

        private void AddReportHeader(Models.DashboardModel dashboard, ExcelWorksheet worksheet, CurrentRow row)
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
        }

        private void AddSliceStatistics(IReadOnlyCollection<TopicModel> sliceStatistics, ExcelWorksheet worksheet, CurrentRow row)
        {
            // highlight low rate of correct answers
            var correctnessRateColumn = new ExcelAddress(row.Row, 3, row.Row + sliceStatistics.Count, 3);
            var lowCorrectRateRule = worksheet.ConditionalFormatting.AddLessThan(correctnessRateColumn);
            lowCorrectRateRule.Formula = "0.7";
            lowCorrectRateRule.Style.Font.Color.Color = Color.Red;

            // highlight low rate of students who did the task
            var studentsRateColumn = new ExcelAddress(row.Row, 4, row.Row + sliceStatistics.Count, 4);
            var lowRateRule = worksheet.ConditionalFormatting.AddLessThan(studentsRateColumn);
            lowRateRule.Formula = "0.5";
            lowRateRule.Style.Font.Color.Color = Color.Red;

            foreach (var sliceStats in sliceStatistics)
            {
                row.Cell(1).Value = sliceStats.TopicName;
                row.Cell(1).Style.Font.Size = 16 - 2 * sliceStats.Level;

                row.Cell(2).Value = sliceStats.ExerciseCount;

                row.Cell(3).Value = sliceStats.CorrectAnswersRate;
                row.Cell(3).Style.Numberformat.Format = "0%";

                row.Cell(4).Value = sliceStats.StudentsShare;
                row.Cell(4).Style.Numberformat.Format = "0%";

                row.Next();
            }
        }

        private class CurrentRow
        {
            private ExcelWorksheet Worksheet { get; }

            public int Row { get; private set; }

            public CurrentRow(ExcelWorksheet worksheet, int row)
            {
                Worksheet = worksheet;
                Row = row;
            }

            public ExcelRange Cell(int column)
            {
                return Worksheet.Cells[Row, column];
            }

            public void Next()
            {
                ++Row;
            }
        }
    }
}
