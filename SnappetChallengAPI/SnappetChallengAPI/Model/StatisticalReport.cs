namespace SnappetChallengAPI.Model
{
    public class StatisticalReport
    {
        public int Correct { get; set; }
        public string SubmitDateTime { get; set; }
        public string Subject { get; set; }
        public int PassCount { get; set; }
        public int FailCount { get; set; }

    }
}
