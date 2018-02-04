namespace SnappetChallenge.WebApi.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class SubjectModel
    {
        public SubjectModel() { }

        public SubjectModel(string name, IEnumerable<ExerciseResultJsonDeserializeModel> groupedList)
        {
            this.Name = name;
            if (groupedList != null)
            {
                this.Answers = groupedList.Select(item => new ExerciseResultModel(item));
            }
        }

        public string Name { get; set; }

        public IEnumerable<ExerciseResultModel> Answers { get; set; }
    }
}
