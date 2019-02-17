using System;
using System.Drawing;
using Dashboard.Dashboard.Models;
using OfficeOpenXml;

namespace Dashboard.Dashboard
{
    public class DashboardExcelPresenter
    {
        public ExcelPackage Present(Models.Dashboard dashboard)
        {
            if (dashboard == null)
            {
                throw new ArgumentNullException(nameof(dashboard));
            }

            var excelPackage = new ExcelPackage();
            var worksheet = excelPackage.Workbook.Worksheets.Add("MySheet");

            var headerStyle = worksheet.Workbook.Styles.CreateNamedStyle("Header");
            headerStyle.Style.Font.Bold = true;
            headerStyle.Style.Font.Size = 16;

            var row = new CurrentRow(worksheet, 1);
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

            // highlight low rate of correct answers
            var correctnessRateColumn = new ExcelAddress(row.Row, 3, 65000, 3);
            var lowCorrectRateRule = worksheet.ConditionalFormatting.AddLessThan(correctnessRateColumn);
            lowCorrectRateRule.Formula = "0.7";
            lowCorrectRateRule.Style.Font.Color.Color = Color.Red;

            // highlight low rate of students who did the task
            var studentsRateColumn = new ExcelAddress(row.Row, 4, 65000, 4);
            var lowRateRule = worksheet.ConditionalFormatting.AddLessThan(studentsRateColumn);
            lowRateRule.Formula = "0.5";
            lowRateRule.Style.Font.Color.Color = Color.Red;

            ShowSliceStatisticsRecursive(dashboard.SlicedStatistics, dashboard.StudentsPresent, row, 16);

            worksheet.Cells.AutoFitColumns();

            return excelPackage;
        }

        private void ShowSliceStatisticsRecursive(AnswersSlice slice, int totalStudentsCount, CurrentRow currentRow, int headerFontSize)
        {
            var stats = slice.GetStatistics();

            currentRow.Cell(1).Value = slice.Name;
            currentRow.Cell(1).Style.Font.Size = headerFontSize;

            currentRow.Cell(2).Value = stats.ExerciseCount;

            currentRow.Cell(3).Value = stats.CorrectAnswersShare;
            currentRow.Cell(3).Style.Numberformat.Format = "0%";

            currentRow.Cell(4).Value = (float)stats.StudentsCount / totalStudentsCount;
            currentRow.Cell(4).Style.Numberformat.Format = "0%";
            
            currentRow.Next();

            foreach (AnswersSlice subslice in slice.Subslices)
            {
                ShowSliceStatisticsRecursive(subslice, totalStudentsCount, currentRow, headerFontSize - 2);
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
