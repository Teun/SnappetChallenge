using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Moq;
using NUnit.Framework;

using DataRepositories.Data;
using DataRepositories.Implementations;
using DataRepositories.Interfaces;
using DataRepositories.Test.Comparers;

namespace DataRepositories.Test
{
    /// <summary>
    /// Contains unit tests for the AnswerDB class
    /// </summary>
    public class AnswerDBTests
    {
        /// <summary>
        /// Contains tests for the GetAnswerQueryable method
        /// </summary>
        [TestFixture]
        public class GetAnswerQueryableTests
        {
            const string TestDataFileName = "TestDataFile.json";

            /// <summary>
            /// Tests retrieving a queryable when the data file has not already been loaded
            /// </summary>
            [Test]
            public void TestRetrieveQueryableDataFileNotLoaded()
            {
                //Create the mock file loader
                Mock<IAnswerDataJsonFileLoader> mockFileLoader = CreateMockFileLoader();

                //Create an AnswerDB instance
                AnswerDB testAnswerDB = new AnswerDB(mockFileLoader.Object, TestDataFileName);

                //Retrieve the test data, which will be our expected data
                List<Answer> expectedAnswers = CreateTestData();

                //Retrieve the Querable from the DB
                IQueryable<Answer> answerQueryable = testAnswerDB.GetAnswerQueryable();

                //Verify that we actually got a queryable
                Assert.That(answerQueryable, Is.Not.Null);

                //Verify that the queryable returns the correct data
                List<Answer> actualAnswers = answerQueryable.ToList();

                expectedAnswers.Zip(actualAnswers, Tuple.Create)
                    .ToList()
                    .ForEach(answerTuple => DataComparers.CompareAnswers(answerTuple.Item1, answerTuple.Item2));

                //Verify that the file loader was called correctly
                mockFileLoader.Verify(mock => mock.LoadAnswerDataFromFile(
                    It.Is<string>(fileName => fileName == TestDataFileName)), Times.Once);
            }

            /// <summary>
            /// Tests retrieving a queryable when the data file has already been loaded
            /// </summary>
            [Test]
            public void TestRetrieveQueryableDataFileAlreadyLoaded()
            {
                //Create the mock file loader
                Mock<IAnswerDataJsonFileLoader> mockFileLoader = CreateMockFileLoader();

                //Create an AnswerDB instance
                AnswerDB testAnswerDB = new AnswerDB(mockFileLoader.Object, TestDataFileName);

                //Retrieve the test data, which will be our expected data
                List<Answer> expectedAnswers = CreateTestData();

                //Retrieve the Querable from the DB
                IQueryable<Answer> answerQueryable = testAnswerDB.GetAnswerQueryable();

                //Verify that the file loader was called correctly
                mockFileLoader.Verify(mock => mock.LoadAnswerDataFromFile(
                    It.Is<string>(fileName => fileName == TestDataFileName)), Times.Once);

                //That should have loaded the file to the DB. Retrieve the queryable again.
                answerQueryable = testAnswerDB.GetAnswerQueryable();

                //Verify that we actually got a queryable
                Assert.That(answerQueryable, Is.Not.Null);

                //Verify that the queryable returns the correct data
                List<Answer> actualAnswers = answerQueryable.ToList();

                expectedAnswers.Zip(actualAnswers, Tuple.Create)
                    .ToList()
                    .ForEach(answerTuple => DataComparers.CompareAnswers(answerTuple.Item1, answerTuple.Item2));

                //Verify that the file loader was not called again
                mockFileLoader.Verify(mock => mock.LoadAnswerDataFromFile(It.IsAny<string>()), Times.Once);
            }

            /// <summary>
            /// Creates a set of answer test data to use in the tests
            /// </summary>
            /// <returns>A collection of test data</returns>
            private List<Answer> CreateTestData()
            {
                List<Answer> testData = new List<Answer>()
                {
                    new Answer()
                    {
                        SubmittedAnswerId = 12345,
                        SubmitDateTime = DateTime.Parse("2018-01-30T08:57:00.00"),
                        Correct = 1,
                        Progress = 0,
                        UserId = 56789,
                        ExerciseId = 23,
                        Difficulty = "5",
                        Subject = "Geschiedenis",
                        Domain = "-",
                        LearningObjective = "Industrial Revolution"
                    },
                    new Answer()
                    {
                        SubmittedAnswerId = 23456,
                        SubmitDateTime= DateTime.Parse("2018-01-30T09:02:00.00"),
                        Correct = 0,
                        Progress = -10,
                        UserId = 65342,
                        ExerciseId = 875,
                        Difficulty = "-20",
                        Subject = "Wiskunde",
                        Domain = "Geometry",
                        LearningObjective = "Calculating Area of a Triangle"
                    }
                };

                return testData;
            }

            /// <summary>
            /// Creates a mock file loader that returns a set of test data
            /// </summary>
            /// <returns>The mock file loader</returns>
            private Mock<IAnswerDataJsonFileLoader> CreateMockFileLoader()
            {
                //Mock the data file loader
                Mock<IAnswerDataJsonFileLoader> mockFileLoader = new Mock<IAnswerDataJsonFileLoader>();

                //Create the test data
                List<Answer> testData = CreateTestData();

                //Mock the LoadAnswerDataFromFile method to return the set of test data
                mockFileLoader.Setup(mock => mock.LoadAnswerDataFromFile(It.IsAny<string>()))
                    .Returns(testData);

                return mockFileLoader;
            }
        }
    }
}
