using System.Collections.Generic;
using FluentAssertions;
using Snappet.Data.DataObjects;
using Snappet.Website.Mappers;
using Snappet.Website.Models;
using Xunit;

namespace Snappet.Website.Tests.Mappers
{
    public class TableViewModelMapperTests
    {
        readonly ITableViewModelMapper _mapper = new TableViewModelMapper();
        private readonly TableViewModel _tableViewModel;
        public TableViewModelMapperTests()
        {
            _tableViewModel = _mapper.CreateTableViewModel("Hello world", new List<ClassResultRow>() { CreateClassResultRow(2, 1), CreateClassResultRow(6, 4) });
        }

        [Fact]
        public void ShouldCreateCorrectNumberOfRows()
        {
            _tableViewModel.Rows.Should().HaveCount(3);
        }

        public void ShouldCreateTitle()
        {
            _tableViewModel.Title.Should().Be("Hello world");
        }

        [Fact]
        public void ShouldCreateValidRow()
        {
            _tableViewModel.Rows[1].LearningObjective.Should().Be("xyz");
            _tableViewModel.Rows[1].Subject.Should().Be("aabbcc");
            _tableViewModel.Rows[1].Correct.Should().Be("6");
            _tableViewModel.Rows[1].Incorrect.Should().Be("4");
            _tableViewModel.Rows[1].Count.Should().Be("10");
            _tableViewModel.Rows[1].PercentCorrect.Should().Be("60");
            _tableViewModel.Rows[1].PercentCssClass.Should().Be("danger");
        }

        [Fact]
        public void LastRowShouldBeAggregation()
        {
            _tableViewModel.Rows[2].LearningObjective.Should().BeNull();
            _tableViewModel.Rows[2].Subject.Should().Be("Totalen");
            _tableViewModel.Rows[2].Correct.Should().Be("8");
            _tableViewModel.Rows[2].Incorrect.Should().Be("5");
            _tableViewModel.Rows[2].Count.Should().Be("13");
            _tableViewModel.Rows[2].PercentCorrect.Should().BeNull();
            _tableViewModel.Rows[2].PercentCssClass.Should().BeNull();
        }

        private static ClassResultRow CreateClassResultRow(int correct, int incorrect)
        {
            var classResultRow = new ClassResultRow();
            classResultRow.Correct = correct;
            classResultRow.Incorrect = incorrect;
            classResultRow.Count = correct + incorrect;
            classResultRow.LearningObjective = "xyz";
            classResultRow.Subject = "aabbcc";
            classResultRow.PercentCorrect = (correct * 100) / (correct + incorrect);
            return classResultRow;
        }
    }
}
