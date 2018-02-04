namespace SnappetChallenge.WebUI.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    using SnappetChallenge.WebUI.Models;

    public class StudentResultViewModel
    {
        public StudentResultViewModel() { }
        public StudentResultViewModel(StudentResultModel student)
        {
            if (student != null)
            {
                this.Id = student.Id;
                this.Subjects = student.Subjects.Select(item => new SubjectViewModel(item));
            }
        }

        public int Id { get; set; }

        public IEnumerable<SubjectViewModel> Subjects { get; set; }
    }
}
