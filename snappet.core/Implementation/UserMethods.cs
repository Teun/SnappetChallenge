using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using snappet.core.Contracts;
using snappet.core.Models.EF;
using snappet.core.Models.ViewModels;

namespace snappet.core.Implementation
{
    public class UserMethods : IUserMethods
    {
        private readonly SnappetEntities db;

        public UserMethods()
        {
            db = new SnappetEntities();
        }
        public List<UserVM> GetAllUsers()
        {
            return db.Users.Select(dbUser => new UserVM() { UserID = dbUser.UserID }).ToList();
        }

        public UserVM GetSpecificUser(int UserID, int Weeks = 1)
        {
            DateTime endData = Convert.ToDateTime("2015-03-24 11:30:00");
            DateTime startDate = endData.AddDays((Weeks * -1 * 7));

            try
            {

                User data = db.Users.Find(UserID);
                if (data == null)
                {
                    return null;
                }

                UserVM result = new UserVM
                {
                    UserID = data.UserID,
                    LearningObjectives = new List<LearningObjectiveVM>(),
                    UserHistory = new List<UserHistoryVM>(),
                    UserLearningObjData = new List<UserLearningObjectDataItemVM>()
                };

                List<ExerciseVM> exerciseVms = new List<ExerciseVM>();
                List<SubmittedAnswerVM> submittedAnswerVms = new List<SubmittedAnswerVM>();
                foreach (var submittedAnswer in data.SubmittedAnswers.Where(x => x.SubmittedAnswerDateTime >= startDate && x.SubmittedAnswerDateTime <= endData))
                {
                    submittedAnswerVms.Add(new SubmittedAnswerVM()
                    {
                        UserID = submittedAnswer.UserID,
                        Correct = submittedAnswer.Correct,
                        ExerciseID = submittedAnswer.ExerciseID,
                        SubmittedAnswerID = submittedAnswer.SubmittedAnswerID,
                        DateAnswered = submittedAnswer.SubmittedAnswerDateTime,
                        Progress = submittedAnswer.Progress
                    });
                }

                List<int> exerciseIDs = submittedAnswerVms.GroupBy(x => x.ExerciseID).Select(m => m.First()).Select(x => x.ExerciseID).ToList();

                foreach (var item in db.Exercises.Where(x => exerciseIDs.Contains(x.ID)))
                {
                    var userAnswers = submittedAnswerVms.Where(x => x.ExerciseID == item.ID).ToList();

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
                    result.LearningObjectives.Add(new LearningObjectiveVM()
                    {
                        LearningObjectiveID = item.LearningObjectiveID,
                        LearningObjective = item.LearningObjective1,
                        Exercises = exerc
                    });
                }


                foreach (var resultLearningObjective in result.LearningObjectives)
                { 
                    result.UserLearningObjData.Add(new UserLearningObjectDataItemVM()
                    {
                        LearningObjectiveID = resultLearningObjective.LearningObjectiveID,
                        LearningObjective = resultLearningObjective.LearningObjective,
                        NumberOfTimesAnswered = resultLearningObjective.Exercises.Sum(x => x.UserAnswers.Count),
                        TotalProgress = resultLearningObjective.Exercises.SelectMany(itemExercise => itemExercise.UserAnswers).Sum(itemExerciseSubmittedAnswer => itemExerciseSubmittedAnswer.Progress)
                    });
                }

                List<DateTime> dates = new List<DateTime>();

                foreach (var resultLearningObjective in result.LearningObjectives)
                {
                    dates.AddRange(resultLearningObjective.Exercises.SelectMany(x => x.UserAnswers.Select(t => t.DateAnswered.Date)).ToList());
                }
                dates = dates.Distinct().OrderBy(x => x.Date).ToList();
                foreach (var date in dates)
                {
                    var dateData = new UserHistoryVM()
                    {
                        Date = date.ToLongDateString()
                    };

                    foreach (var resultLearningObjective in result.LearningObjectives)
                    {
                        foreach (var exerciseVm in resultLearningObjective.Exercises)
                        {
                            dateData.QuestionsAnsweredCount += exerciseVm.UserAnswers.Count(x => x.DateAnswered.Date == date);
                        }
                    }

                    result.UserHistory.Add(dateData);
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
