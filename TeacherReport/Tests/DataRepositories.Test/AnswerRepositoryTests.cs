using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Moq;
using NUnit.Framework;

using DataRepositories.Data;
using DataRepositories.Data.DailySummary;
using DataRepositories.Implementations;
using DataRepositories.Interfaces;
using DataRepositories.Test.Comparers;

namespace DataRepositories.Test
{
    /// <summary>
    /// Contains unit tests for the AnswerRepository class
    /// </summary>
    public class AnswerRepositoryTests
    {
        /// <summary>
        /// Contains tests for the GetDailyStudentSummary method
        /// </summary>
        [TestFixture]
        public class GetDailyStudentSummaryTests
        {
             /// <summary>
            /// Tests retrieving a daily student summary with a typical scenario
            /// </summary>
            /// <remarks>
            /// A typical scenario is where some of the data falls within range of the daily
            /// student summary and some does not. The data that does fall within the daily student
            /// summary involves multiple students with multiple subjects per student and multiple
            /// answers per subject, and multiple learning objectives per subject.
            /// </remarks>
            [Test]
            public void TestGetStudentSummaryTestsWithTypicalScenario()
            {
                //Create the test data for the typical scenario
                List<Answer> typicalScenarioTestData = CreateTypicalScenarioTestData();

                //Run the test with the test data
                RunStudentSummaryTestWithData(typicalScenarioTestData);
            }

            /// <summary>
            /// Runs a student summary test with a particular test of test data
            /// </summary>
            /// <param name="testData">The set of test data to use when running the test</param>
            private void RunStudentSummaryTestWithData(List<Answer> testData)
            {
                //Define the target date/time when the summary is created
                DateTime targetDateTime = DateTime.Parse("2018-01-30T12:39:00");

                //Calculate the expected daily summary
                DailyStudentSummary expectedSummary = CalculateExpectedSummaryData(testData, targetDateTime);

                //Create the mock answer DB
                Mock<IAnswerDB> mockAnswerDB = CreateMockAnswerDB(testData);

                //Create an instance of the answer repository
                IAnswerRepository answerRepository = new AnswerRepository(mockAnswerDB.Object);

                //Retrieve the daily student summary
                DailyStudentSummary actualSummary = answerRepository.GetDailyStudentSummary(targetDateTime);

                //Compare the actual summary to the expected summary to see if they match
                DataComparers.CompareDailyStudentSummaries(actualSummary, expectedSummary);
            }

            /// <summary>
            /// Calculates the expected summary data based on a set of test data and a particular date/time
            /// when the summary is generated
            /// </summary>
            /// <remarks>
            /// I'm deliberately calculating the expected data in a different manner than how the method
            /// will be implemented so that I'm not repeating the same mistakes. I consider this to
            /// be the less optimal method. Using grouping would be much more readable.
            /// </remarks>
            /// <param name="testData">The test data</param>
            /// <param name="summaryGenDateTime">The date/time the daily summary was generated</param>
            /// <returns>The expected daily summary</returns>
            private DailyStudentSummary CalculateExpectedSummaryData(List<Answer> testData, DateTime summaryGenDateTime)
            {
                DailyStudentSummary expectedSummary = new DailyStudentSummary();

                //Calculate the summary date/time range
                DateTime minDateTime = summaryGenDateTime.Date;
                DateTime maxDateTime = summaryGenDateTime;

                //Create a queryable that only contains answers within the date range
                IQueryable<Answer> relevantAnswers = testData
                    .Where(answer => answer.SubmitDateTime >= minDateTime &&
                        answer.SubmitDateTime <= maxDateTime)
                    .AsQueryable();

                //Calculate the unique subjects within the date range
                expectedSummary.Subjects = relevantAnswers
                    .Where(answer => answer.SubmitDateTime >= minDateTime &&
                        answer.SubmitDateTime <= maxDateTime)
                    .Select(answer => answer.Subject)
                    .Distinct()
                    .ToList();

                //Get the unique students that have data within the date range
                List<int> expectedStudents = relevantAnswers
                    .Where(answer => answer.SubmitDateTime >= minDateTime &&
                        answer.SubmitDateTime <= maxDateTime)
                    .Select(answer => answer.UserId)
                    .Distinct()
                    .ToList();

                //Map each student to a summary row
                expectedSummary.SummaryRows = expectedStudents
                    .Select(currentUserId =>
                    {
                        StudentSummaryRow studentSummary = new StudentSummaryRow()
                        {
                            UserId = currentUserId,
                            Name = currentUserId.ToString()
                        };

                        //Map each subject to an average progress value. Some values may be null,
                        //since not all students may have done exercises in the same subjects
                        studentSummary.AverageSubjectProgress = expectedSummary.Subjects
                            .Where(subject => relevantAnswers.Any(answer => answer.Subject == subject &&
                                answer.UserId == currentUserId))
                            .Select(targetSubject =>
                            {
                                decimal averageProgress = relevantAnswers
                                    .Where(answer => answer.Subject == targetSubject)
                                    .Where(answer => answer.UserId == currentUserId)
                                    .Select(answer => (decimal)answer.Progress)
                                    .Average();

                                return Tuple.Create(targetSubject, averageProgress);
                            })
                            .ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2);

                        return studentSummary;
                    })
                    .ToList();

                return expectedSummary;
            }

            /// <summary>
            /// Creates a set of answer test data to use when testing a typical scenario
            /// </summary>
            /// <returns>A collection of test data</returns>
            private List<Answer> CreateTypicalScenarioTestData()
            {
                //Create data for four students, all of whom have data on multiple days and data
                //before and after the target date/time, which is 2018-01-30 at 12:39.
                //This makes the target date/time range 2018-01-30T00:00:00 to 2018-01-30T12:39:00.
                //One student should have an average progress of 0 in one particular subject.
                //The fourth student will not have any data during the target date/time range
                List<Answer> testData = new List<Answer>();

                //Add the test data for student 1
                testData.AddRange(CreateTypicalScenarioStudent1TestData());
                //Add the test data for student 2
                testData.AddRange(CreateTypicalScenarioStudent2TestData());
                //Add the test data for student 3
                testData.AddRange(CreateTypicalScenarioStudent3TestData());
                //Add the test data for student 4
                testData.AddRange(CreateTypicalScenarioStudent4TestData());

                return testData;
            }

            /// <summary>
            /// Creates test data for student 1 in the typical test scenario
            /// </summary>
            /// <returns>The test data for student 1</returns>
            private List<Answer> CreateTypicalScenarioStudent1TestData()
            {
                const int Student1UserId = 56789;

                List<Answer> testData = new List<Answer>()
                {
                    //Geschiedenis exercise within the target date/time
                    new Answer()
                    {
                        SubmittedAnswerId = 12345,
                        SubmitDateTime = DateTime.Parse("2018-01-30T08:57:00.00"),
                        Correct = 1,
                        Progress = 0,
                        UserId = Student1UserId,
                        ExerciseId = 23,
                        Difficulty = "5",
                        Subject = "Geschiedenis",
                        Domain = "-",
                        LearningObjective = "Industrial Revolution"
                    },
                    new Answer()
                    {
                        SubmittedAnswerId = 12346,
                        SubmitDateTime = DateTime.Parse("2018-01-30T08:58:00.00"),
                        Correct = 0,
                        Progress = 0,
                        UserId = Student1UserId,
                        ExerciseId = 23,
                        Difficulty = "5",
                        Subject = "Geschiedenis",
                        Domain = "-",
                        LearningObjective = "Industrial Revolution"
                    },
                    //Wiskunde Exercise within the target date/time
                    new Answer()
                    {
                        SubmittedAnswerId = 12701,
                        SubmitDateTime = DateTime.Parse("2018-01-30T09:41:00.00"),
                        Correct = 1,
                        Progress = 22,
                        UserId = Student1UserId,
                        ExerciseId = 456,
                        Difficulty = "34",
                        Subject = "Wiskunde",
                        Domain = "Geometry",
                        LearningObjective = "Areas of Shapes"
                    },
                    new Answer()
                    {
                        SubmittedAnswerId = 12702,
                        SubmitDateTime = DateTime.Parse("2018-01-30T09:42:00.00"),
                        Correct = 0,
                        Progress = -8,
                        UserId = Student1UserId,
                        ExerciseId = 456,
                        Difficulty = "34",
                        Subject = "Wiskunde",
                        Domain = "Geometry",
                        LearningObjective = "Areas of Shapes"
                    },
                    new Answer()
                    {
                        SubmittedAnswerId = 12703,
                        SubmitDateTime = DateTime.Parse("2018-01-30T09:43:00.00"),
                        Correct = 0,
                        Progress = -10,
                        UserId = Student1UserId,
                        ExerciseId = 456,
                        Difficulty = "34",
                        Subject = "Wiskunde",
                        Domain = "Geometry",
                        LearningObjective = "Areas of Shapes"
                    },
                    //Wiskunde Exercise past the target date/time
                    new Answer()
                    {
                        SubmittedAnswerId = 12734,
                        SubmitDateTime = DateTime.Parse("2018-01-30T13:05:00.00"),
                        Correct = 1,
                        Progress = 14,
                        UserId = Student1UserId,
                        ExerciseId = 456,
                        Difficulty = "34",
                        Subject = "Wiskunde",
                        Domain = "Geometry",
                        LearningObjective = "Areas of Shapes"
                    },
                    new Answer()
                    {
                        SubmittedAnswerId = 12735,
                        SubmitDateTime = DateTime.Parse("2018-01-30T13:06:00.00"),
                        Correct = 1,
                        Progress = 2,
                        UserId = Student1UserId,
                        ExerciseId = 456,
                        Difficulty = "34",
                        Subject = "Wiskunde",
                        Domain = "Geometry",
                        LearningObjective = "Areas of Shapes"
                    },
                    //Geschiedenis exercise before the target date/time
                    new Answer()
                    {
                        SubmittedAnswerId = 84354344,
                        SubmitDateTime = DateTime.Parse("2018-01-28T09:45:00.00"),
                        Correct = 1,
                        Progress = 10,
                        UserId = Student1UserId,
                        ExerciseId = 2343,
                        Difficulty = "100",
                        Subject = "Geschiedenis",
                        Domain = "Nederland",
                        LearningObjective = "The Dutch Golden Age"
                    },
                    new Answer()
                    {
                        SubmittedAnswerId = 43534543,
                        SubmitDateTime = DateTime.Parse("2018-01-28T09:45:00.00"),
                        Correct = 1,
                        Progress = 12,
                        UserId = Student1UserId,
                        ExerciseId = 2343,
                        Difficulty = "100",
                        Subject = "Geschiedenis",
                        Domain = "Nederland",
                        LearningObjective = "The Dutch Golden Age"
                    },
                    //Geschiedenis exercise during the target date/time
                    new Answer()
                    {
                        SubmittedAnswerId = 84354863,
                        SubmitDateTime = DateTime.Parse("2018-01-30T10:03:00.00"),
                        Correct = 1,
                        Progress = 25,
                        UserId = Student1UserId,
                        ExerciseId = 2344,
                        Difficulty = "100",
                        Subject = "Geschiedenis",
                        Domain = "Nederland",
                        LearningObjective = "The Dutch Golden Age"
                    },
                    new Answer()
                    {
                        SubmittedAnswerId = 43538543,
                        SubmitDateTime = DateTime.Parse("2018-01-30T10:03:30.00"),
                        Correct = 1,
                        Progress = 43,
                        UserId = Student1UserId,
                        ExerciseId = 2344,
                        Difficulty = "100",
                        Subject = "Geschiedenis",
                        Domain = "Nederland",
                        LearningObjective = "The Dutch Golden Age"
                    },
                };

                return testData;
            }

            /// <summary>
            /// Creates test data for student 2 in the typical test scenario
            /// </summary>
            /// <returns>The test data for student 2</returns>
            private List<Answer> CreateTypicalScenarioStudent2TestData()
            {
                const int Student2UserId = 34542;

                List<Answer> testData = new List<Answer>()
                {
                    //Geschiedenis exercise within the target date/time
                    new Answer()
                    {
                        SubmittedAnswerId = 8554653,
                        SubmitDateTime = DateTime.Parse("2018-01-30T08:57:00.00"),
                        Correct = 1,
                        Progress = 48,
                        UserId = Student2UserId,
                        ExerciseId = 23,
                        Difficulty = "5",
                        Subject = "Geschiedenis",
                        Domain = "-",
                        LearningObjective = "Industrial Revolution"
                    },
                    new Answer()
                    {
                        SubmittedAnswerId = 3534534,
                        SubmitDateTime = DateTime.Parse("2018-01-30T08:58:00.00"),
                        Correct = 0,
                        Progress = -5,
                        UserId = Student2UserId,
                        ExerciseId = 23,
                        Difficulty = "5",
                        Subject = "Geschiedenis",
                        Domain = "-",
                        LearningObjective = "Industrial Revolution"
                    },
                    //Taalkunde Exercise within the target date/time
                    new Answer()
                    {
                        SubmittedAnswerId = 78678,
                        SubmitDateTime = DateTime.Parse("2018-01-30T09:15:00.00"),
                        Correct = 1,
                        Progress = 125,
                        UserId = Student2UserId,
                        ExerciseId = 488,
                        Difficulty = "34",
                        Subject = "Taalkunde",
                        Domain = "Duits",
                        LearningObjective = "Dative Case"
                    },
                    new Answer()
                    {
                        SubmittedAnswerId = 456352,
                        SubmitDateTime = DateTime.Parse("2018-01-30T09:15:23.00"),
                        Correct = 0,
                        Progress = -41,
                        UserId = Student2UserId,
                        ExerciseId = 488,
                        Difficulty = "34",
                        Subject = "Taalkunde",
                        Domain = "Duits",
                        LearningObjective = "Dative Case"
                    },
                    new Answer()
                    {
                        SubmittedAnswerId = 12703,
                        SubmitDateTime = DateTime.Parse("2018-01-30T09:43:00.00"),
                        Correct = 1,
                        Progress = 10,
                        UserId = Student2UserId,
                        ExerciseId = 488,
                        Difficulty = "34",
                        Subject = "Taalkunde",
                        Domain = "Duits",
                        LearningObjective = "Dative Case"
                    },
                    //Taalkunde Exercise past the target date/time
                    new Answer()
                    {
                        SubmittedAnswerId = 12734,
                        SubmitDateTime = DateTime.Parse("2018-01-30T14:05:00.00"),
                        Correct = 1,
                        Progress = 14,
                        UserId = Student2UserId,
                        ExerciseId = 456,
                        Difficulty = "34",
                        Subject = "Taalkunde",
                        Domain = "Duits",
                        LearningObjective = "Dative Case"
                    },
                    new Answer()
                    {
                        SubmittedAnswerId = 12735,
                        SubmitDateTime = DateTime.Parse("2018-01-30T14:06:00.00"),
                        Correct = 1,
                        Progress = 2,
                        UserId = Student2UserId,
                        ExerciseId = 456,
                        Difficulty = "34",
                        Subject = "Taalkunde",
                        Domain = "Duits",
                        LearningObjective = "Dative Case"
                    },
                    //Geschiedenis exercise before the target date/time
                    new Answer()
                    {
                        SubmittedAnswerId = 84354344,
                        SubmitDateTime = DateTime.Parse("2018-01-29T15:45:00.00"),
                        Correct = 1,
                        Progress = 10,
                        UserId = Student2UserId,
                        ExerciseId = 2343,
                        Difficulty = "100",
                        Subject = "Geschiedenis",
                        Domain = "Nederland",
                        LearningObjective = "The Dutch Golden Age"
                    },
                    new Answer()
                    {
                        SubmittedAnswerId = 43534543,
                        SubmitDateTime = DateTime.Parse("2018-01-29T15:45:00.00"),
                        Correct = 1,
                        Progress = 12,
                        UserId = Student2UserId,
                        ExerciseId = 2343,
                        Difficulty = "100",
                        Subject = "Geschiedenis",
                        Domain = "Nederland",
                        LearningObjective = "The Dutch Golden Age"
                    },
                    //Geschiedenis exercise during the target date/time
                    new Answer()
                    {
                        SubmittedAnswerId = 84354863,
                        SubmitDateTime = DateTime.Parse("2018-01-30T10:03:00.00"),
                        Correct = 1,
                        Progress = 25,
                        UserId = Student2UserId,
                        ExerciseId = 2344,
                        Difficulty = "100",
                        Subject = "Geschiedenis",
                        Domain = "Nederland",
                        LearningObjective = "The Dutch Golden Age"
                    },
                    new Answer()
                    {
                        SubmittedAnswerId = 43538543,
                        SubmitDateTime = DateTime.Parse("2018-01-30T10:03:30.00"),
                        Correct = 1,
                        Progress = 43,
                        UserId = Student2UserId,
                        ExerciseId = 2344,
                        Difficulty = "100",
                        Subject = "Geschiedenis",
                        Domain = "Nederland",
                        LearningObjective = "The Dutch Golden Age"
                    },
                };

                return testData;
            }

            /// <summary>
            /// Creates test data for student 3 in the typical test scenario
            /// </summary>
            /// <returns>The test data for student 3</returns>
            private List<Answer> CreateTypicalScenarioStudent3TestData()
            {
                const int Student3UserId = 34542;

                List<Answer> testData = new List<Answer>()
                {
                    //Geschiedenis exercise within the target date/time
                    new Answer()
                    {
                        SubmittedAnswerId = 8554653,
                        SubmitDateTime = DateTime.Parse("2018-01-30T08:57:00.00"),
                        Correct = 1,
                        Progress = 0,
                        UserId = Student3UserId,
                        ExerciseId = 23,
                        Difficulty = "5",
                        Subject = "Geschiedenis",
                        Domain = "-",
                        LearningObjective = "Industrial Revolution"
                    },
                    new Answer()
                    {
                        SubmittedAnswerId = 3534534,
                        SubmitDateTime = DateTime.Parse("2018-01-30T08:58:00.00"),
                        Correct = 0,
                        Progress = 0,
                        UserId = Student3UserId,
                        ExerciseId = 23,
                        Difficulty = "5",
                        Subject = "Geschiedenis",
                        Domain = "-",
                        LearningObjective = "Industrial Revolution"
                    },
                    //Taalkunde Exercise within the target date/time
                    new Answer()
                    {
                        SubmittedAnswerId = 78678,
                        SubmitDateTime = DateTime.Parse("2018-01-30T09:15:00.00"),
                        Correct = 1,
                        Progress = 5,
                        UserId = Student3UserId,
                        ExerciseId = 488,
                        Difficulty = "34",
                        Subject = "Taalkunde",
                        Domain = "Duits",
                        LearningObjective = "Dative Case"
                    },
                    new Answer()
                    {
                        SubmittedAnswerId = 456352,
                        SubmitDateTime = DateTime.Parse("2018-01-30T09:15:23.00"),
                        Correct = 0,
                        Progress = -5,
                        UserId = Student3UserId,
                        ExerciseId = 488,
                        Difficulty = "34",
                        Subject = "Taalkunde",
                        Domain = "Duits",
                        LearningObjective = "Dative Case"
                    },
                    new Answer()
                    {
                        SubmittedAnswerId = 12703,
                        SubmitDateTime = DateTime.Parse("2018-01-30T09:43:00.00"),
                        Correct = 1,
                        Progress = 5,
                        UserId = Student3UserId,
                        ExerciseId = 488,
                        Difficulty = "34",
                        Subject = "Taalkunde",
                        Domain = "Duits",
                        LearningObjective = "Dative Case"
                    },
                    //Wiskunde Exercise past the target date/time
                    new Answer()
                    {
                        SubmittedAnswerId = 12734,
                        SubmitDateTime = DateTime.Parse("2018-01-30T14:05:00.00"),
                        Correct = 1,
                        Progress = 14,
                        UserId = Student3UserId,
                        ExerciseId = 458,
                        Difficulty = "34",
                        Subject = "Wiskunde",
                        Domain = "Geometry",
                        LearningObjective = "Parabolas"
                    },
                    new Answer()
                    {
                        SubmittedAnswerId = 12735,
                        SubmitDateTime = DateTime.Parse("2018-01-30T14:06:00.00"),
                        Correct = 1,
                        Progress = 2,
                        UserId = Student3UserId,
                        ExerciseId = 458,
                        Difficulty = "34",
                        Subject = "Wiskunde",
                        Domain = "Geometry",
                        LearningObjective = "Parabolas"
                    },
                    //Geschiedenis exercise before the target date/time
                    new Answer()
                    {
                        SubmittedAnswerId = 84354344,
                        SubmitDateTime = DateTime.Parse("2018-01-29T15:45:00.00"),
                        Correct = 1,
                        Progress = 10,
                        UserId = Student3UserId,
                        ExerciseId = 2343,
                        Difficulty = "100",
                        Subject = "Geschiedenis",
                        Domain = "Nederland",
                        LearningObjective = "The Dutch Golden Age"
                    },
                    new Answer()
                    {
                        SubmittedAnswerId = 43534543,
                        SubmitDateTime = DateTime.Parse("2018-01-29T15:45:00.00"),
                        Correct = 1,
                        Progress = 12,
                        UserId = Student3UserId,
                        ExerciseId = 2343,
                        Difficulty = "100",
                        Subject = "Geschiedenis",
                        Domain = "Nederland",
                        LearningObjective = "The Dutch Golden Age"
                    },
                    //Geschiedenis exercise during the target date/time
                    new Answer()
                    {
                        SubmittedAnswerId = 84354863,
                        SubmitDateTime = DateTime.Parse("2018-01-30T10:03:00.00"),
                        Correct = 1,
                        Progress = 25,
                        UserId = Student3UserId,
                        ExerciseId = 2344,
                        Difficulty = "100",
                        Subject = "Geschiedenis",
                        Domain = "Nederland",
                        LearningObjective = "The Dutch Golden Age"
                    },
                    new Answer()
                    {
                        SubmittedAnswerId = 43538543,
                        SubmitDateTime = DateTime.Parse("2018-01-30T10:03:30.00"),
                        Correct = 1,
                        Progress = 43,
                        UserId = Student3UserId,
                        ExerciseId = 2344,
                        Difficulty = "100",
                        Subject = "Geschiedenis",
                        Domain = "Nederland",
                        LearningObjective = "The Dutch Golden Age"
                    },
                };

                return testData;
            }

            /// <summary>
            /// Creates test data for student 4 in the typical test scenario
            /// </summary>
            /// <remarks>
            /// Student 4 does not have any data in the target summary range
            /// </remarks>
            /// <returns>The test data for student 4</returns>
            private List<Answer> CreateTypicalScenarioStudent4TestData()
            {
                const int Student4UserId = 34542;

                List<Answer> testData = new List<Answer>()
                {
                    //Wiskunde Exercise past the target date/time
                    new Answer()
                    {
                        SubmittedAnswerId = 12734,
                        SubmitDateTime = DateTime.Parse("2018-01-30T14:05:00.00"),
                        Correct = 1,
                        Progress = 14,
                        UserId = Student4UserId,
                        ExerciseId = 458,
                        Difficulty = "34",
                        Subject = "Wiskunde",
                        Domain = "Geometry",
                        LearningObjective = "Parabolas"
                    },
                    new Answer()
                    {
                        SubmittedAnswerId = 12735,
                        SubmitDateTime = DateTime.Parse("2018-01-30T14:06:00.00"),
                        Correct = 1,
                        Progress = 2,
                        UserId = Student4UserId,
                        ExerciseId = 458,
                        Difficulty = "34",
                        Subject = "Wiskunde",
                        Domain = "Geometry",
                        LearningObjective = "Parabolas"
                    },
                    //Geschiedenis exercise before the target date/time
                    new Answer()
                    {
                        SubmittedAnswerId = 84354344,
                        SubmitDateTime = DateTime.Parse("2018-01-29T15:45:00.00"),
                        Correct = 1,
                        Progress = 10,
                        UserId = Student4UserId,
                        ExerciseId = 2343,
                        Difficulty = "100",
                        Subject = "Geschiedenis",
                        Domain = "Nederland",
                        LearningObjective = "The Dutch Golden Age"
                    },
                    new Answer()
                    {
                        SubmittedAnswerId = 43534543,
                        SubmitDateTime = DateTime.Parse("2018-01-29T15:45:00.00"),
                        Correct = 1,
                        Progress = 12,
                        UserId = Student4UserId,
                        ExerciseId = 2343,
                        Difficulty = "100",
                        Subject = "Geschiedenis",
                        Domain = "Nederland",
                        LearningObjective = "The Dutch Golden Age"
                    },
                };

                return testData;
            }

            /// <summary>
            /// Creates a mock answer DB that returns a set of test data as a queryable
            /// </summary>
            /// <param name="testData">The test data to be accessed from the answer DB</param>
            /// <returns>The mock answer DB</returns>
            private Mock<IAnswerDB> CreateMockAnswerDB(List<Answer> testData)
            {
                //Mock the answer DB
                Mock<IAnswerDB> mockAnswerDB = new Mock<IAnswerDB>();

                //Mock the GetAnswerQueryable method to return a queryable interface to
                //the set of test data
                mockAnswerDB.Setup(mock => mock.GetAnswerQueryable())
                    .Returns(testData.AsQueryable());

                return mockAnswerDB;
            }
        }
    }
}
