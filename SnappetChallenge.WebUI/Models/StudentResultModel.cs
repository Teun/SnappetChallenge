namespace SnappetChallenge.WebUI.Models
{
    using System.Collections.Generic;

    public class StudentResultModel
    {

        public int Id { get; set; }

        public IEnumerable<SubjectModel> Subjects { get; set; }
    }
}
