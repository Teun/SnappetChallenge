using System.Collections.Generic;
using System.Linq;

namespace SnappetChallenge.Core.Entities
{
    public class Works
    {
        public Works(IEnumerable<Student> students)
        {
            Students = students;
            Subjects = new Subjects(students.SelectMany(x => x.Exercises.All));
        }

        public IEnumerable<Student> Students { get; private set; }

        public int TotalCorrect => Students.Sum(x => x.Exercises.TotalCorrect);
        public int TotalIncorrect => Students.Sum(x => x.Exercises.TotalIncorrect);
        public decimal CorrectnessAverage => Students.Average(x => x.Exercises.CorrectnessAverage);

        public Subjects Subjects { get; private set; }
    }
}
