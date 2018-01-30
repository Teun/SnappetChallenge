using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

using DataRepositories.Data;
using DataRepositories.Implementations;
using DataRepositories.Interfaces;
using DataRepositories.Test.Comparers;

namespace DataRepositories.Test
{
    /// <summary>
    /// Contains unit tests for the JsonFileAnswerDataLoader
    /// </summary>
    public class AnswerDataJsonFileLoaderTests
    {
        /// <summary>
        /// Contains tests for the LoadAnswerDataFromFile method
        /// </summary>
        [TestFixture]
        public class LoadAnswerDataFromFileTests
        {
            const string NoRecordsFileName = "DataFiles/NoRecords.json";
            const string SingleAnswerFileName = "DataFiles/SingleAnswer.json";
            const string MultipleAnswersFileName = "DataFiles/MultipleAnswers.json";
            const string NonExistentFileName = "DataFiles/NonExistentFile.json";

            /// <summary>
            /// Tests loading data from a JSON file with no records
            /// </summary>
            [Test]
            public void TestLoadingFileWithNoData()
            {
                //Define the expected data
                List<Answer> expectedData = new List<Answer>();

                //Create the JSON file loader
                IAnswerDataJsonFileLoader fileLoader = new AnswerDataJsonFileLoader();

                //Load the test file
                List<Answer> actualData = fileLoader.LoadAnswerDataFromFile(NoRecordsFileName);

                Assert.That(actualData.Count, Is.EqualTo(expectedData.Count));
            }

            /// <summary>
            /// Tests loading data from a file with a single record
            /// </summary>
            [Test]
            public void TestLoadingFileWithSingleRecord()
            {
                //Define the expected data
                List<Answer> expectedData = new List<Answer>()
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
                    }
                };

                //Create the JSON file loader
                IAnswerDataJsonFileLoader fileLoader = new AnswerDataJsonFileLoader();

                //Load the test file
                List<Answer> actualData = fileLoader.LoadAnswerDataFromFile(SingleAnswerFileName);

                //Compare the actual data to the expected data
                Assert.That(actualData.Count, Is.EqualTo(expectedData.Count));

                expectedData.Zip(actualData, Tuple.Create)
                    .ToList()
                    .ForEach(dataTuple => DataComparers.CompareAnswers(dataTuple.Item1, dataTuple.Item2));
            }

            /// <summary>
            /// Tests loading data from a file with multiple records
            /// </summary>
            [Test]
            public void TestLoadingFileWithMultipleRecords()
            {
                //Define the expected data
                List<Answer> expectedData = new List<Answer>()
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

                //Create the JSON file loader
                IAnswerDataJsonFileLoader fileLoader = new AnswerDataJsonFileLoader();

                //Load the test file
                List<Answer> actualData = fileLoader.LoadAnswerDataFromFile(MultipleAnswersFileName);

                //Compare the actual data to the expected data
                Assert.That(actualData.Count, Is.EqualTo(expectedData.Count));

                expectedData.Zip(actualData, Tuple.Create)
                    .ToList()
                    .ForEach(dataTuple => DataComparers.CompareAnswers(dataTuple.Item1, dataTuple.Item2));
            }

            /// <summary>
            /// Tests loading data from a non-existent JSON file
            /// </summary>
            [Test]
            public void TestLoadingNonExistentFile()
            {
                //Create the JSON file loader
                IAnswerDataJsonFileLoader fileLoader = new AnswerDataJsonFileLoader();

                //Attempts to load the test file, which should result in a FileNotFound exception
                Assert.That(fileLoader.LoadAnswerDataFromFile(NoRecordsFileName), 
                    Throws.InstanceOf<FileNotFoundException>());
            }
        }
    }
}
