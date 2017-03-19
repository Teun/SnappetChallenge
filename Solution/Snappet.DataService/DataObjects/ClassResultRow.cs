namespace Snappet.Data.DataObjects
{
    public struct ClassResultRow
    {
        public string Subject { get; set; }
        public string LearningObjective { get; set; }
        public int Count { get; set; }
        public int Correct { get; set; }
        public int Incorrect { get; set; }
        public int PercentCorrect { get; set; }
    }
}