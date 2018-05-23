using System.Collections.Generic;
using System.Linq;

namespace SnappetChallenge.Core.Entities
{
    public class Exercises
    {
        public Exercises(IEnumerable<Exercise> exercises)
        {
            All = exercises;
            Subjects = new Subjects(exercises);
        }

        public IEnumerable<Exercise> All { get; private set; }

        public int TotalCorrect => All.Sum(x => x.Answers.TotalCorrect);
        public int TotalIncorrect => All.Sum(x => x.Answers.TotalIncorrect);
        public decimal CorrectnessAverage => All.Average(x => x.Answers.CorrectnessAverage);

        public Subjects Subjects { get; private set; }
    }

    public class Exercise
    {
        public int Id { get; set; }
        public Answers Answers { get; set; }

        public string Difficulty { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
    }
}
