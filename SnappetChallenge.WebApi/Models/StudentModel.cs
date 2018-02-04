namespace SnappetChallenge.WebApi.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class StudentModel
    {
        public StudentModel() { }

        public StudentModel(int userId, IEnumerable<ExerciseResultJsonDeserializeModel> groupedList)
        {
            this.Id = userId;

            if (groupedList != null)
            {
                this.Subjects = groupedList.GroupBy(x => x.Subject, (key, group) => new SubjectModel(key, group));
            }
        }

        public int Id { get; set; }

        public IEnumerable<SubjectModel> Subjects { get; set; }
    }
}
