using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using DataRepositories.Data;
using DataRepositories.Data.DailySummary;

namespace DataRepositories.Test.Comparers
{
    /// <summary>
    /// Compares data objects using NUnit assertions
    /// </summary>
    public static class DataComparers
    {
        /// <summary>
        /// Compares an expected answer object to the actual answer object
        /// </summary>
        /// <remarks>
        /// For reasons of time constraints, this method assumes that neither object is null.
        /// </remarks>
        /// <param name="expectedAnswer">The expected answer object</param>
        /// <param name="actualAnswer">The actual answer object</param>
        public static void CompareAnswers(Answer expectedAnswer, Answer actualAnswer)
        {
            Assert.That(actualAnswer.Correct, Is.EqualTo(expectedAnswer.Correct));
            Assert.That(actualAnswer.Difficulty, Is.EqualTo(expectedAnswer.Difficulty));
            Assert.That(actualAnswer.Domain, Is.EqualTo(expectedAnswer.Domain));
            Assert.That(actualAnswer.ExerciseId, Is.EqualTo(expectedAnswer.ExerciseId));
            Assert.That(actualAnswer.LearningObjective, Is.EqualTo(expectedAnswer.LearningObjective));
            Assert.That(actualAnswer.Progress, Is.EqualTo(expectedAnswer.Progress));
            Assert.That(actualAnswer.Subject, Is.EqualTo(expectedAnswer.Subject));
            Assert.That(actualAnswer.SubmitDateTime, Is.EqualTo(expectedAnswer.SubmitDateTime));
            Assert.That(actualAnswer.SubmittedAnswerId, Is.EqualTo(expectedAnswer.SubmittedAnswerId));
            Assert.That(actualAnswer.UserId, Is.EqualTo(expectedAnswer.UserId));
        }

        /// <summary>
        /// Compares an expected daily student summary object to the actual daily student summary object
        /// </summary>
        /// <remarks>
        /// For reasons of time constraints, this method assumes that neither object is null.
        /// </remarks>
        /// <param name="expectedSummary">The expected daily student summary object</param>
        /// <param name="actualSummary">The actual daily student summary object</param>
        public static void CompareDailyStudentSummaries(DailyStudentSummary expectedSummary, DailyStudentSummary actualSummary)
        {
            Assert.That(actualSummary.Subjects, Is.EquivalentTo(expectedSummary.Subjects));

            Assert.That(actualSummary.SummaryRows.Count, Is.EqualTo(expectedSummary.SummaryRows.Count));

            //We need to have the rows in a consistent order so that we can compare the same rows to each other
            var expectedSortedRows = expectedSummary.SummaryRows.OrderBy(row => row.UserId);
            var actualSortedRows = actualSummary.SummaryRows.OrderBy(row => row.UserId);

            expectedSortedRows.Zip(actualSortedRows, Tuple.Create)
                .ToList()
                .ForEach(rowTuple => CompareDailyStudentSummaries(rowTuple.Item1, rowTuple.Item2));
        }

        /// <summary>
        /// Compares an expected student summary row object to the actual student summary row object
        /// </summary>
        /// <remarks>
        /// For reasons of time constraints, this method assumes that neither object is null.
        /// </remarks>
        /// <param name="expectedRow">The expected student summary row object</param>
        /// <param name="actualRow">The actual student summary row object</param>
        public static void CompareDailyStudentSummaries(StudentSummaryRow expectedRow, StudentSummaryRow actualRow)
        {
            Assert.That(actualRow.UserId, Is.EqualTo(expectedRow.UserId));
            Assert.That(actualRow.Name, Is.EqualTo(expectedRow.Name));
            Assert.That(actualRow.AverageSubjectProgress.Keys, Is.EquivalentTo(expectedRow.AverageSubjectProgress.Keys));
            Assert.That(actualRow.AverageSubjectProgress.Values, Is.EquivalentTo(expectedRow.AverageSubjectProgress.Values));
        }
    }
}
