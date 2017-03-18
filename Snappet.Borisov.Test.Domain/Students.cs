using System;
using System.Collections.Generic;
using Snappet.Borisov.Test.Domain.Reporting;

namespace Snappet.Borisov.Test.Domain
{
    public class Students: ISubmitAnswers, IProvideStudents
    {
        private readonly IGenerateStudentNames _names;
        private readonly Dictionary<int, Student> _students;

        public Students(IGenerateStudentNames names)
        {
            _names = names;
            _students = new Dictionary<int, Student>();
        }

        public IEnumerable<Student> GetAll() => _students.Values;

        public void Submit(SubmittedAnswer answer)
        {
            if (answer == null) throw new ArgumentNullException(nameof(answer));
            var student = FindStudent(answer.UserId);
            if (student == null)
            {
                var name = _names.Generate();
                student = new Student(answer.UserId, name);
                _students.Add(answer.UserId, student);
            }
            student.SubmitAnswer(answer);
        }

        private Student FindStudent(int userId)
        {
            Student student;
            return _students.TryGetValue(userId, out student) ? student : null;
        }

        public override string ToString()
        {
            return $"Students {_students.Values.Count}";
        }
    }
}