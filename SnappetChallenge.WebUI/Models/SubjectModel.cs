namespace SnappetChallenge.WebUI.Models
{
    using System.Collections.Generic;

    public class SubjectModel
    {
        public string Name { get; set; }

        public IEnumerable<ExerciseResultModel> Answers { get; set; }
    }
}
