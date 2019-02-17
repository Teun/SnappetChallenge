using System;
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

            var row = new Row(worksheet, 1);
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

            ShowSliceStatisticsRecursive(dashboard.SlicedStatistics, dashboard.StudentsPresent, row, 16);

            worksheet.Cells.AutoFitColumns();

            return excelPackage;
        }

        private void ShowSliceStatisticsRecursive(AnswersSlice slice, int totalStudentsCount, Row row, int headerFontSize)
        {
            var stats = slice.GetStatistics();

            row.Cell(1).Value = slice.Name;
            row.Cell(1).Style.Font.Size = headerFontSize;

            row.Cell(2).Value = stats.ExerciseCount;

            row.Cell(3).Value = stats.CorrectAnswersShare;
            row.Cell(3).Style.Numberformat.Format = "0%";

            row.Cell(4).Value = (float)stats.StudentsCount / totalStudentsCount;
            row.Cell(4).Style.Numberformat.Format = "0%";

            row.Next();

            foreach (AnswersSlice subslice in slice.Subslices)
            {
                ShowSliceStatisticsRecursive(subslice, totalStudentsCount, row, headerFontSize - 2);
            }
        }

        private class Row
        {
            private readonly ExcelWorksheet _worksheet;

            private int _row;

            public Row(ExcelWorksheet worksheet, int row)
            {
                _worksheet = worksheet;
                _row = row;
            }

            public ExcelRange Cell(int column)
            {
                return _worksheet.Cells[_row, column];
            }

            public void Next()
            {
                ++_row;
            }
        }
    }
}
