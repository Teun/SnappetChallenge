namespace SnappetChallenge.WebUI.Models
{
    using System.Collections.Generic;

    public class StudentModel
    {
        public int Id { get; set; }

        public IEnumerable<SubjectModel> Subjects { get; set; }
    }
}
