using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

using DataRepositories.Data;

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
    }
}
