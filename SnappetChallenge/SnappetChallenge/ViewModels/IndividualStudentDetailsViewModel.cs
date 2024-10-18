using SnappetChallenge.Models;

namespace SnappetChallenge.ViewModels
{
    public class IndividualStudentDetailsViewModel
    {
        private readonly StudentData _student;

        public StudentData Student
        {
            get { return _student; }
        }
        
        public IndividualStudentDetailsViewModel(StudentData selectedStudent) 
        {
            _student = selectedStudent;
        }
    }
}