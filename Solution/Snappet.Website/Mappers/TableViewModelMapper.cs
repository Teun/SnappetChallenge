using System.Collections.Generic;
using System.Linq;
using Snappet.Data.DataObjects;
using Snappet.Website.Models;

namespace Snappet.Website.Mappers
{
    public class TableViewModelMapper : ITableViewModelMapper
    {
        public TableViewModel CreateTableViewModel(string title, IList<ClassResultRow> tableRows)
        {
            TablesViewModel model = new TablesViewModel();
            var tableViewModel = new TableViewModel();
            tableViewModel.Title = title;
            tableViewModel.TableHeaders.AddRange(new[] {"Onderwerp", "Leerdoel", "Aantal opgaves", "Goed", "Fout", "% Goed"});
            foreach (ClassResultRow row in tableRows)
            {
                var tableRowViewModel = CreateTableRow(row);
                tableViewModel.Rows.Add(tableRowViewModel);
            }

            var sumRow = CreateSumRow(tableRows);
            tableViewModel.Rows.Add(sumRow);

            model.Tables.Add(tableViewModel);

            return tableViewModel;
        }

        private TableRowViewModel CreateSumRow(IList<ClassResultRow> tableRows)
        {
            return new TableRowViewModel()
            {
                Subject = "Totalen",
                Count = tableRows.Sum(_ => _.Count).ToString(),
                Correct = tableRows.Sum(_ => _.Correct).ToString(),
                Incorrect = tableRows.Sum(_ => _.Incorrect).ToString(),
            };
        }

        private TableRowViewModel CreateTableRow(ClassResultRow row)
        {
            return new TableRowViewModel()
            {
                Subject = row.Subject,
                LearningObjective = row.LearningObjective,
                Count = row.Count.ToString(),
                Correct = row.Correct.ToString(),
                Incorrect = row.Incorrect.ToString(),
                PercentCorrect = row.PercentCorrect.ToString(),
                PercentCssClass = GetCssClass(row.PercentCorrect)
            };
        }

        private string GetCssClass(int rowPercentCorrect)
        {
            string result = null;
            if (rowPercentCorrect > 90)
            {
                result = "success";
            }

            if (rowPercentCorrect < 80)
            {
                result = "warning";
            }

            if (rowPercentCorrect < 65)
            {
                result = "danger";
            }

            return result;
        }
    }
}