namespace snappet.core.Models.ViewModels
{
    public class UserLearningObjectDataItemVM
    {
        public int LearningObjectiveID { get; set; }

        public string LearningObjective { get; set; }
        public int NumberOfTimesAnswered { get; set; }
        public int TotalProgress { get; set; }
    }
}