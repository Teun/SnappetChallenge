namespace SnappetWorkApp
{
    public class Exercise
    {
        public string Domain {get;set;}
        public string LearningObjective {get;set;}
        public int Id {get;set;}
        public int TimesCorrect {get;set;}
        public int TimesIncorrect {get;set;}
        public int TotalProgress {get;set;}
        public double AverageDifficulty {get;set;}

    }
}