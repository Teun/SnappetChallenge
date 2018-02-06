using System;
using System.Collections.Generic;
using System.Linq;

using DataRepositories.Data;
using DataRepositories.Data.DailySummary;
using DataRepositories.Interfaces;

namespace DataRepositories.Implementations
{
    /// <summary>
    /// Implements the answer repository
    /// </summary>
    public class AnswerRepository : IAnswerRepository
    {
        private IAnswerDB answerDB = null;

        public AnswerRepository(IAnswerDB answerDB)
        {
            this.answerDB = answerDB;
        }

        public DailyStudentSummary GetDailyStudentSummary(DateTime summaryDateTime)
        {
            DailyStudentSummary dailySummary = new DailyStudentSummary();

            //Retrieve the queryable from the answer DB
            IQueryable<Answer> answerQueryable = answerDB.GetAnswerQueryable();

            //Calculate the summary date/time range
            DateTime minDateTime = summaryDateTime.Date;
            DateTime maxDateTime = summaryDateTime;

            //Create a queryable that only contains answers within the date range
            IQueryable<Answer> relevantAnswers = answerQueryable
                .Where(answer => answer.SubmitDateTime >= minDateTime &&
                    answer.SubmitDateTime <= maxDateTime)
                .AsQueryable();

            //Calculate the unique subjects within the date range
            dailySummary.Subjects = relevantAnswers
                .Where(answer => answer.SubmitDateTime >= minDateTime)
                .Where(answer => answer.SubmitDateTime <= maxDateTime)
                .Select(answer => answer.Subject)
                .Distinct()
                .ToList();

            //Retrieve the students and their average subject progress scores
            dailySummary.SummaryRows = relevantAnswers
                //Group the answers into users
                .GroupBy(answer => answer.UserId)
                //Create a student summary row for each user group
                .Select(userAnswerGroup => new StudentSummaryRow()
                {
                    UserId = userAnswerGroup.Key,
                    Name = userAnswerGroup.Key.ToString(),
                    AverageSubjectProgress = userAnswerGroup
                        //Group the user answers by subject
                        .GroupBy(answer => answer.Subject)
                        //Convert each subject group into a collection of tuples containing the subject name and the 
                        //average progress score
                        .Select(subjectGroup => Tuple.Create(subjectGroup.Key, 
                            subjectGroup.Select(answer => (decimal)answer.Progress).Average()))
                        //Convert that collection to a dictionary with the subject as the key and the average progress score
                        //as the value
                        .ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2)
                })
                .ToList();
               
            return dailySummary;
        }
    }
}
