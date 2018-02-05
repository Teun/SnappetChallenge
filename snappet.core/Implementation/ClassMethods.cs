using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using snappet.core.Contracts;
using snappet.core.Models.EF;
using snappet.core.Models.ViewModels;

namespace snappet.core.Implementation
{
    public class ClassMethods : IClassMethods
    {

        private readonly SnappetEntities db;

        public ClassMethods()
        {
            db = new SnappetEntities();
        }

        /// <summary>
        /// Returns a list of DateTime object with the available dates
        /// </summary>
        /// <returns>List of DateTime objects</returns>
        public List<DateTime> GetAvailableDates()
        {
            var end = Convert.ToDateTime("2015-03-24 11:30:00");
            var start = Convert.ToDateTime("2015-02-24 11:30:00");
            List<DateTime> list = Enumerable.Range(0, 1 + end.Subtract(start).Days).Select(offset => start.AddDays(offset)).ToList();
            return list;
        }

        /// <summary>
        /// Gets a list of LearningObjectives containing all the data for a specific date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<LearningObjectiveVM> GetClassReport(DateTime date, DateTime? startDate)
        {
            try
            {
                List<ExerciseVM> exerciseVms = new List<ExerciseVM>();
                List<SubmittedAnswerVM> submittedAnswerVms = new List<SubmittedAnswerVM>();
                List<LearningObjectiveVM> result = new List<LearningObjectiveVM>();

                IQueryable<SubmittedAnswer> dbData;

                if (startDate.HasValue)
                {
                    DateTime endDate = Convert.ToDateTime("2015-03-24 11:30:00");

                    dbData = db.SubmittedAnswers.Where(x => DbFunctions.TruncateTime(x.SubmittedAnswerDateTime) >= startDate.Value &&
                        DbFunctions.TruncateTime(x.SubmittedAnswerDateTime) <= endDate);
                }
                else
                {
                    dbData = db.SubmittedAnswers.Where(x => DbFunctions.TruncateTime(x.SubmittedAnswerDateTime) == date.Date);
                }

                foreach (SubmittedAnswer submittedAnswer in dbData)
                {
                    submittedAnswerVms.Add(new SubmittedAnswerVM()
                    {
                        UserID = submittedAnswer.UserID,
                        Correct = submittedAnswer.Correct,
                        ExerciseID = submittedAnswer.ExerciseID,
                        SubmittedAnswerID = submittedAnswer.SubmittedAnswerID
                    });
                }

                //get unique list of Exercise IDs 
                List<int> exerciseIDs = submittedAnswerVms.GroupBy(x => x.ExerciseID).Select(m => m.First()).Select(x => x.ExerciseID).ToList();

                foreach (Exercise item in db.Exercises.Where(x => exerciseIDs.Contains(x.ID)))
                {
                    List<SubmittedAnswerVM> userAnswers = submittedAnswerVms.Where(x => x.ExerciseID == item.ID).ToList();

                    int numberOfUsers = userAnswers.GroupBy(x => x.UserID).Select(x => x.First()).ToList().Count;
                    exerciseVms.Add(new ExerciseVM()
                    {
                        ExerciseID = item.ID,
                        Difficulty = item.Difficulty,
                        LearningObjectiveID = item.LearningObjectiveID,
                        UserAnswers = userAnswers,
                        NumberOfUsers = numberOfUsers
                    });
                }

                //get unique list of Learning Objectives
                List<int> learningObjectivesIDs = exerciseVms.GroupBy(x => x.LearningObjectiveID).Select(x => x.First()).Select(x => x.LearningObjectiveID).ToList();

                foreach (var item in db.LearningObjectives.Where(x => learningObjectivesIDs.Contains(x.LearningObjectiveID)).OrderBy(x => x.LearningObjective1))
                {
                    var exerc = exerciseVms.Where(x => x.LearningObjectiveID == item.LearningObjectiveID).ToList();
                    result.Add(new LearningObjectiveVM()
                    {
                        LearningObjectiveID = item.LearningObjectiveID,
                        LearningObjective = item.LearningObjective1,
                        Exercises = exerc
                    });
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of LearningObjectes containing all the data for a specific week
        /// </summary>
        /// <param name="Weeks"></param>
        /// <returns></returns>
        public List<LearningObjectiveVM> GetWeekReport(int Weeks)
        {
            DateTime endDate = Convert.ToDateTime("2015-03-24 11:30:00");
            DateTime startDate = endDate.AddDays((Weeks * -1 * 7));

            return GetClassReport(endDate, startDate);
        }
    }
}