#region Imports
using System.Collections.Generic;
#endregion

#region namespace
namespace Assignment.ViewModel
{
    #region class

    /// <summary>
    /// Class DataViewModel to bind the data with View
    /// </summary>
    public class ClassDataViewModel
    {
        public string CurrentDateTime { get; set; }
        public long CurrentAnswerCount { get; set; }
        public int CurrentCorrectCount { get; set; }
        public int CurrentInCorrectCount { get; set; }
        public double CurrentProgressAvg { get; set; }
        public long CurrentUserIdCount { get; set; }
        public long CurrentExerciseIdCount { get; set; }
        public string CurrentDifficulty { get; set; }
        public List<string> CurrentSubjectList { get; set; }
        public List<string> CurrentDomainList { get; set; }
        public List<string> CurrentLearningObjectiveList { get; set; }

        public long WeeklyAnswerCount { get; set; }
        public int WeeklyCorrectCount { get; set; }
        public int WeeklyInCorrectCount { get; set; }
        public double WeeklyProgressAvg { get; set; }
        public long WeeklyUserIdCount { get; set; }
        public long WeeklyExerciseIdCount { get; set; }
        public string WeeklyDifficulty { get; set; }
        public List<string> WeeklySubjectList { get; set; }
        public List<string> WeeklyDomainList { get; set; }
        public List<string> WeeklyLearningObjectiveList { get; set; }

        public long MonthlyAnswerCount { get; set; }
        public int MonthlyCorrectCount { get; set; }
        public int MonthlyInCorrectCount { get; set; }
        public double MonthlyProgressAvg { get; set; }
        public long MonthlyUserIdCount { get; set; }
        public long MonthlyExerciseIdCount { get; set; }
        public string MonthlyDifficulty { get; set; }
        public List<string> MonthlySubjectList { get; set; }
        public List<string> MonthlyDomainList { get; set; }
        public List<string> MonthlyLearningObjectiveList { get; set; }

    }
    #endregion
}
#endregion